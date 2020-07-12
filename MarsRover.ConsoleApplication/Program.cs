using BusinessLayer;
using BusinessLayer.Enums;
using BusinessLayer.Helpers;
using BusinessLayer.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var provider = serviceProvider.GetService<IProvider<Rover>>();

            var plato = SetPlatoCoordinate("Plato nun x ve y koordinatını giriniz:");

            for (int i = 1; i <= 2; i++)
            {
                var rover = SetRoverInformation(plato, $"{i}.Rover'ın x,y koordinatını ve yönünü giriniz:");
                Calculate(provider, rover, $"{i}.Rover'ın hareketlerini giriniz:");
                Console.WriteLine(rover.GetRoverLocationInformation());
            }
        }

        private static Plato SetPlatoCoordinate(string text)
        {
            Console.WriteLine(text);
            var value = Console.ReadLine();
            var coordinates = value.Split(" ");

            if (coordinates.Length != 2 || !coordinates[0].IsNumberAndBiggerThanZero() || !coordinates[1].IsNumberAndBiggerThanZero())
            {
                Console.WriteLine("Değerleri yanlış girdiniz lütfen tekrar giriniz. Örn : 5 5");
                return SetPlatoCoordinate(text);
            }

            return new Plato(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));
        }

        private static Rover SetRoverInformation(Plato plato, string text)
        {
            Console.WriteLine(text);
            var value = Console.ReadLine();
            var coordinates = value.Split(" ");

            if (coordinates.Length != 3 || !coordinates[0].IsNumberAndBiggerThanZero() || !coordinates[1].IsNumberAndBiggerThanZero() || !coordinates[2].EnumControl<DirectionEnum>())
            {
                Console.WriteLine("Değerleri yanlış girdiniz lütfen tekrar giriniz. Örn : 3 3 N");
                return SetRoverInformation(plato, text);
            }

            DirectionEnum direction;
            Enum.TryParse(coordinates[2], out direction);

            return new Rover(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]), direction, plato);
        }

        private static Rover Calculate(IProvider<Rover> provider, Rover rover, string text)
        {
            Console.WriteLine(text);
            var values = Console.ReadLine();

            foreach (var item in values)
            {
                if (!item.ToString().EnumControl<MoveEnum>())
                {
                    Console.WriteLine("Değerleri yanlış girdiniz lütfen tekrar giriniz. Örn : 3 3 N");
                    return Calculate(provider, rover, text);
                }
            }

            rover.MovementInformation = values;
            provider.Execute(rover);

            return rover;
        }
    }
}