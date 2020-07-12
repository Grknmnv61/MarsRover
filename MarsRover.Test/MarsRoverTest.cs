using BusinessLayer;
using BusinessLayer.Provider;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace MarsRover.Test
{
    public class Tests
    {
        IProvider<Rover> _provider;
        public Tests()
        {
            IServiceCollection services = new ServiceCollection();
            Startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            _provider = serviceProvider.GetService<IProvider<Rover>>();
        }

        [Test]
        public void Test1()
        {
            var rover = new Rover(1, 2, BusinessLayer.Enums.DirectionEnum.N, new Plato(5, 5), "LMLMLMLMM");
            _provider.Execute(rover);
            var comingResult = rover.GetRoverLocationInformation();
            var expectedResult = "(1,3) N";
            Assert.AreEqual(comingResult, expectedResult);
        }

        [Test]
        public void Test2()
        {
            var rover = new Rover(3, 3, BusinessLayer.Enums.DirectionEnum.E, new Plato(5, 5), "MMRMMRMRRM");
            _provider.Execute(rover);
            var comingResult = rover.GetRoverLocationInformation();
            var expectedResult = "(5,1) E";
            Assert.AreEqual(comingResult, expectedResult);
        }
    }
}