namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;
    /// <summary>
    /// Абонент
    /// </summary>
    public class Subscriber : IEquatable<Subscriber>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Subscriber"/>
        /// </summary>
        /// <param name="id"> Идентефикатор </param>
        /// <param name="lastName"> Фамилия </param>
        /// <param name="firstName"> Имя </param>
        /// <param name="patronymic"> Отчество </param>
        /// <param name="dateOfBirth"> День рождения </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В случае если <paramref name="lastName"/> или <paramref name="firstName"/> или <paramref name="dateOfBirth"/> <see langword="null"/>, 
        /// пустая строка или строка, содержащая только пробельные символы.
        /// </exception>
        public Subscriber(int id, string lastName, string firstName, string patronymic, string dateOfBirth)
        {
            this.ID = id;
            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(lastName));
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));
            this.Patronymic = patronymic.TrimOrNull();
            this.DateOfBirth = dateOfBirth.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(dateOfBirth));
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Subscriber"/>
        /// </summary>
        [Obsolete("For ORM", true)]
        protected Subscriber()
        {
        }
        /// <summary>
        /// Уникальный идентефикатор
        /// </summary>
        public virtual int ID { get; protected set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public virtual string LastName { get; protected set; }
        /// <summary>
        /// Имя
        /// </summary>
        public virtual string FirstName { get; protected set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public virtual string Patronymic { get; protected set; }
        /// <summary>
        /// День рождения
        /// </summary>
        public virtual string DateOfBirth { get; protected set; }
        /// <summary>
        /// Полная информация об абоненте
        /// </summary>
        public virtual string FullData => $"{this.LastName} {this.FirstName[0]}. {this.Patronymic?[0]}. {this.DateOfBirth[0]}.".Trim();

        /// <summary>
        /// Множество тарифов
        /// </summary>
        public virtual ISet<Tariff> Tariffs { get; protected set; } = new HashSet<Tariff>();

        /// <summary>
        /// Метод, добавляющий тариф абоненту.
        /// </summary>
        /// <param name="book"> Добавляемый тариф. </param>
        /// <returns>
        /// Флаг успешности выполнения операции:
        /// <see langword="true"/> – тариф был успешно добавлена,
        /// <see langword="false"/> в противном случае.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="tariff"/> – <see langword="null"/>.
        /// </exception>
        public virtual bool AddTariff(Tariff tariff)
        {
            return tariff == null
                ? throw new ArgumentNullException(nameof(tariff))
                : this.Tariffs.Add(tariff);
        }

        public override string ToString() => this.FullData;

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || this.Equals(obj as Subscriber));
        }

        public virtual bool Equals(Subscriber other)
        {
            return !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || this.ID == other.ID);
        }

        public override int GetHashCode() => this.ID;
    }
}

