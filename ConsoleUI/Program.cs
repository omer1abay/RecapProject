using Businness.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager car = new CarManager(new InMemoryCarDal());

            //Console.WriteLine(car.GetAllCars()); 

            foreach (var item in car.GetAllCars())
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
