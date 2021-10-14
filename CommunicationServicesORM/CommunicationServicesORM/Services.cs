using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationServicesORM
{
    class Services
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="serviceName">Название услуги</param>
        /// <param name="price">Цена услуги</param>
        public Services(int id, string serviceName, int price)
        {
            ID = id;
            ServiceName = serviceName;
            Price = price;
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; protected set; }
        public string ServiceName { get; protected set; }
        public int Price { get; protected set; }
        /// <summary>
        /// переопределение метода
        /// </summary>
        /// <returns>Возвращает строковое представление значения, представляемого объектом</returns>
        public override string ToString()
        {
            return String.Format("ID: {0}, Услуга: {1}, Цена: {2}\n", ID, ServiceName, Price);
        }

    }
}
