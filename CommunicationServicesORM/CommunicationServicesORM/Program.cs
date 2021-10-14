using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServicesORM
{
    class Program
    {
        /// <summary>
        /// Главный метод
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var operators = new CommunicationServicesORM.Operators(1, "Мегафон");
            Console.WriteLine(operators);

            var services = new CommunicationServicesORM.Services(1, "Пакет СМС", 50);
            Console.WriteLine(services);

            var Subscribers1 = new CommunicationServicesORM.Subscribers(1, "Рябова", "Дария", "Кирилловна", 1990, 04, 30);
            Console.WriteLine(Subscribers1);
            var Subscribers2 = new CommunicationServicesORM.Subscribers(2, "Уварова", "Вероника", "", 1997, 06, 04);
            Console.WriteLine(Subscribers2);
            Console.ReadKey();
        }
    }
}