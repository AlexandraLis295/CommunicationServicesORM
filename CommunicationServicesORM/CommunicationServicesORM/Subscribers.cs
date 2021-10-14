using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationServicesORM
{
    class Subscribers
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="yearOfBirth">Год рождения</param>
        /// <param name="monthOfBirth">Месяц рождения</param>
        /// <param name="dayOfBirth">День рождения</param>
        public Subscribers(int id, string lastName, string firstName, string patronymic, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            ID = id;
            if (lastName == null)
                throw new ArgumentNullException(nameof(lastName), "LastName cannot be null");
            LastName = lastName;
            if (firstName == null)
                throw new ArgumentNullException(nameof(firstName), "FirstName cannot be null");
            FirstName = firstName;
            Patronymic = patronymic;
            YearOfBirth = yearOfBirth;
            MonthOfBirth = monthOfBirth;
            DayOfBirth = dayOfBirth;
        }
        public int ID { get; protected set; }
        public string LastName { get; protected set; }
        public string FirstName { get; protected set; }
        public string Patronymic { get; protected set; }
        public int YearOfBirth { get; protected set; }
        public int MonthOfBirth { get; protected set; }
        public int DayOfBirth { get; protected set; }
        /// <summary>
        /// Переопределение метода
        /// </summary>
        /// <returns>Возвращает строковое представление значения, представляемого объектом. Учтена возможность отсутствия у абонента отчества</returns>
        public override string ToString()
        {
            if (Patronymic == null)
                return String.Format("ID: {0}, Фамилия: {1}, Имя: {2}, Дата рождения: {3}.{4}.{5}\n", ID, LastName, FirstName, YearOfBirth, MonthOfBirth, DayOfBirth);
            return String.Format("ID: {0}, Фамилия: {1}, Имя: {2}, Отчество: {3}, Дата рождения: {4}.{5}.{6}\n", ID, LastName, FirstName, Patronymic, YearOfBirth, MonthOfBirth, DayOfBirth);
        }

    }
}

