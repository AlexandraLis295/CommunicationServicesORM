namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Staff.Extensions;
    /// <summary>
    /// Тариф
    /// </summary>
    public class Tariff
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Tariff"/>.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="tariffName"> Название. </param>
        /// <param name="subscribers"> А,jytyns. </param>
        public Tariff(int id, string tariffName, params Subscriber[] subscribers)
            : this(id, tariffName, new HashSet<Subscriber>(subscribers))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Tariff"/>.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="tariffName"> Название. </param>
        /// <param name="subscribers"> Множество абонентов. </param>
        public Tariff(int id, string tariffName, ISet<Subscriber> subscribers = null)
        {
            this.ID = id;
            this.TariffName = tariffName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(tariffName));

            foreach (var subscriber in subscribers ?? Enumerable.Empty<Subscriber>())
            {
                this.Subscribers.Add(subscriber);
                subscriber.AddTariff(this);
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Tariff"/>.
        /// </summary>
        [Obsolete("For ORM", true)]
        protected Tariff()
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public virtual int ID { get; protected set; }
        /// <summary>
        /// Название
        /// </summary>
        public virtual string TariffName { get; protected set; }
        /// <summary>
        /// Абоненты
        /// </summary>
        public virtual ISet<Subscriber> Subscribers { get; protected set; } = new HashSet<Subscriber>();

        /// <inheritdoc/>
        public override string ToString() => $"{this.TariffName} {this.Subscribers.Join()}".Trim();

    }
}
