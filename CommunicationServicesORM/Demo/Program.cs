namespace Demo
{
    using System;
    using System.Linq;
    using DataAccess;
    using DataAccess.Repositories;
    using Domain;

    internal class Program
    {
        /// <summary>
        /// Главный метод
        /// </summary>
        /// <param name="args"></param>
        private static void Main()
        {
            var subscriber = new Subscriber(1, "Рябова", "Дария", "1990.04.30", "Кирилловна");
            var subscriber1 = new Subscriber(2, "Уварова", "Вероника", "1997.06.04");

            var tariff = new Tariff(1, "Оптимальный", subscriber);
            var tariff1 = new Tariff(2, "Стандартный", subscriber1);

            Console.WriteLine($"{tariff} {subscriber}");

            var settings = new Settings();

            settings.AddDatabaseServer(@"LAPTOP-57BV0I6T\SQLEXPRESS");

            settings.AddDatabaseName("CommunicationServ");

            using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                session.Save(tariff);
                session.Save(tariff1);

                session.Save(subscriber);
                session.Save(subscriber1);
                session.Flush();
            }

            using (var session = sessionFactory.OpenSession())
            {
                var repoTariff = new TariffRepository();
                Console.WriteLine("All tariffs:");
                repoTariff.GetAll(session)
                    .ToList().ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));

                var repoSubscriber = new SubscriberRepository();
                Console.WriteLine("All sibscribers:");
                repoSubscriber.GetAll(session)
                    .ToList().ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));
            }
        }
    }
}
