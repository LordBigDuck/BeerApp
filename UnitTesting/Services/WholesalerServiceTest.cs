using BeerApp.Core.Commands;
using BeerApp.Core.Exceptions;
using BeerApp.Core.Models;
using BeerApp.Infrastructure.Database;
using BeerApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting.Services
{
    public class WholesalerServiceTest : ServiceContext
    {
        public WholesalerServiceTest(): base(
            new DbContextOptionsBuilder<BeerContext>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {

        }

        [Fact]
        public async Task GetQuote_NotOk_ListIsNull()
        {
            using (var context = new BeerContext(ContextOptions))
            {
                var service = new WholesalerService(context);
                var quoteCommand = new GetQuoteCommand
                {
                };

                await Assert.ThrowsAsync<CustomBadRequestException>(() => service.GetQuote(1, quoteCommand));
            }
        }

        [Fact]
        public async Task GetQuote_NotOk_EmptyList()
        {
            using (var context = new BeerContext(ContextOptions))
            {
                var service = new WholesalerService(context);
                var quoteCommand = new GetQuoteCommand
                {
                    CommandLines = new List<BeerQuantity>()
                };

                await Assert.ThrowsAsync<CustomBadRequestException>(() => service.GetQuote(1, quoteCommand));
            }
        }

        [Fact]
        public async Task GetQuote_NotOk_ListContainsDuplicate()
        {
            using (var context = new BeerContext(ContextOptions))
            {
                var service = new WholesalerService(context);
                var quoteCommand = new GetQuoteCommand
                {
                    CommandLines = new List<BeerQuantity>()
                    {
                        new BeerQuantity{ BeerId = 1, Quantity = 3},
                        new BeerQuantity{ BeerId = 2, Quantity = 4},
                        new BeerQuantity{ BeerId = 1, Quantity = 2}
                    }
                };

                await Assert.ThrowsAsync<CustomBadRequestException>(() => service.GetQuote(1, quoteCommand));
            }
        }

        [Fact]
        public async Task GetQuote_NotOk_WholesalerNotFound()
        {
            using (var context = new BeerContext(ContextOptions))
            {
                var service = new WholesalerService(context);
                var quoteCommand = new GetQuoteCommand
                {
                    CommandLines = new List<BeerQuantity>()
                    {
                        new BeerQuantity{ BeerId = 1, Quantity = 3},
                        new BeerQuantity{ BeerId = 2, Quantity = 4}
                    }
                };

                await Assert.ThrowsAsync<CustomBadRequestException>(() => service.GetQuote(5, quoteCommand));
            }
        }

        [Fact]
        public async Task GetQuote_NotOk_BeerNotSellByWholesaler()
        {
            using (var context = new BeerContext(ContextOptions))
            {
                var service = new WholesalerService(context);
                var quoteCommand = new GetQuoteCommand
                {
                    CommandLines = new List<BeerQuantity>()
                    {
                        new BeerQuantity{ BeerId = 1, Quantity = 3},
                        new BeerQuantity{ BeerId = 6, Quantity = 4}
                    }
                };

                await Assert.ThrowsAsync<CustomBadRequestException>(() => service.GetQuote(1, quoteCommand));
            }
        }

        [Fact]
        public async Task GetQuote_NotOk_NotEnoughtStock()
        {
            using (var context = new BeerContext(ContextOptions))
            {
                var service = new WholesalerService(context);
                var quoteCommand = new GetQuoteCommand
                {
                    CommandLines = new List<BeerQuantity>()
                    {
                        new BeerQuantity{ BeerId = 1, Quantity = 100}
                    }
                };

                await Assert.ThrowsAsync<CustomBadRequestException>(() => service.GetQuote(1, quoteCommand));
            }
        }

        [Fact]
        public async Task GetQuote_ReturnOkNoDiscount()
        {
            using (var context = new BeerContext(ContextOptions))
            {
                var service = new WholesalerService(context);
                var quoteCommand = new GetQuoteCommand
                {
                    CommandLines = new List<BeerQuantity>()
                    {
                        new BeerQuantity{ BeerId = 1, Quantity = 3},
                        new BeerQuantity{ BeerId = 2, Quantity = 4} 
                    }
                };

                var quote = await service.GetQuote(1, quoteCommand);

                Assert.Equal(0, quote.Discount);
                Assert.Equal(17.8, quote.Total);
                Assert.Equal(17.8, quote.Price);
            }
        }

        [Fact]
        public async Task GetQuote_ReturnOkDiscount10()
        {
            using (var context = new BeerContext(ContextOptions))
            {
                var service = new WholesalerService(context);
                var quoteCommand = new GetQuoteCommand
                {
                    CommandLines = new List<BeerQuantity>()
                    {
                        new BeerQuantity{ BeerId = 1, Quantity = 6},
                        new BeerQuantity{ BeerId = 2, Quantity = 5}
                    }
                };

                var quote = await service.GetQuote(1, quoteCommand);

                Assert.Equal(2.72, quote.Discount);
                Assert.Equal(27.2, quote.Total);
                Assert.Equal(24.48, quote.Price);
            }
        }

        [Fact]
        public async Task GetQuote_ReturnOkDiscount20()
        {
            using (var context = new BeerContext(ContextOptions))
            {
                var service = new WholesalerService(context);
                var quoteCommand = new GetQuoteCommand
                {
                    CommandLines = new List<BeerQuantity>()
                    {
                        new BeerQuantity{ BeerId = 1, Quantity = 12},
                        new BeerQuantity{ BeerId = 2, Quantity = 12} 
                    }
                };

                var quote = await service.GetQuote(1, quoteCommand);

                Assert.Equal(12, quote.Discount);
                Assert.Equal(60, quote.Total);
                Assert.Equal(48, quote.Price);
            }
        }

        [Fact]
        public async Task Quote_GetDiscount_NoDiscount()
        {
            var quote = new Quote
            {
                Total = 50,
                Items = new List<CommandLine>
                {
                    new CommandLine{ Beer = new Beer{ Id = 1}, Quantity = 4},
                    new CommandLine{ Beer = new Beer{ Id = 2}, Quantity = 5}
                }
            };

            var discount = quote.GetQuantityDiscount();

            Assert.Equal(0, discount);
        }

        [Fact]
        public async Task Quote_GetDiscount10_Ok()
        {
            var quote = new Quote
            {
                Total = 50,
                Items = new List<CommandLine>
                {
                    new CommandLine{ Beer = new Beer{ Id = 1}, Quantity = 6},
                    new CommandLine{ Beer = new Beer{ Id = 2}, Quantity = 5}
                }
            };

            var discount = quote.GetQuantityDiscount();

            Assert.Equal(5, discount);
        }

        [Fact]
        public async Task Quote_GetDiscount20_Ok()
        {
            var quote = new Quote
            {
                Total = 50,
                Items = new List<CommandLine>
                {
                    new CommandLine{ Beer = new Beer{ Id = 1}, Quantity = 15},
                    new CommandLine{ Beer = new Beer{ Id = 2}, Quantity = 10}
                }
            };

            var discount = quote.GetQuantityDiscount();

            Assert.Equal(10, discount);
        }
    }
}
