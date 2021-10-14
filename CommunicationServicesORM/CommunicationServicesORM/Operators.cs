using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationServicesORM
{
    class Operators
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="NameOfOperator">Название оператора</param>
        public Operators(int id, string NameOfOperator)
        {
            ID = id;
            OperatorName = NameOfOperator;
        }
        public int ID { get; protected set; }
        public string OperatorName { get; protected set; }
        /// <summary>
        /// Переопределение метода
        /// </summary>
        /// <returns>Возвращает строковое представление значения, представляемого объектом</returns>
        public override string ToString()
        {
            return String.Format("ID: {0}, Оператор: {1}\n", ID, OperatorName);
        }
    }
}
