using BeerApp.Core.Models;
using BeerApp.Infrastructure.Database;
using BeerApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTesting.Services
{
    public class BrewerServiceTest : TestingContext<BrewerService>
    {
        //public BrewerServiceTest() : base(new DbContextOptionsBuilder<BeerContext>().UseSqlite("Filename=Test.db").Options)
        //{

        //}

        //[Fact]
        //public void GetAll_ReturnAll()
        //{
        //    GetMockFor<BrewerService>().Setup()
        //}
    }
}
