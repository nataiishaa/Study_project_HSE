using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EKRlib
{
    /// <summary>
    /// Создание класса обработки исключений.
    /// </summary>
    [Serializable]
    public class TransportException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса TransportException. 
        /// </summary>
        public TransportException() : base()
        {
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса TransportException с указанным сообщением об ошибке.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        public TransportException(string message) : base(message)
        {
        }
        /// <summary>
        ///  Инициализирует новый экземпляр класса TransportException.
        ///  Указывает сообщение об ошибке со ссылкой на внутреннее исключение, которое является причиной этого исключения.
        /// </summary>
        /// <param name="message"> Сообщение пользователю.</param>
        /// <param name="inner"> Представлет ошибки, которые возникнут во время исполнения программы</param>
        public TransportException(string message, Exception inner) : base(message, inner)
        {
        }
       
        //Инициализирует новый экземпляр класса TransportException с сериализованными данными.  
        
        protected TransportException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}