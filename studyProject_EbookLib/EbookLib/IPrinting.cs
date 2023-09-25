using System;

namespace EbookLib
{
    public interface IPrinting
    {
        /// <summary>
        /// Событие onPrint, основанное на стандартном шаблоне,
        ///  сигнализирующее о печати книги.
        /// </summary>
        public event EventHandler<EventArgs> onPrint;
        // Метод для вызова события.
        public void Print();
    }
}
