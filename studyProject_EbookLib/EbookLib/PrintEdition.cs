using System;
using System.Runtime.Serialization;

namespace EbookLib
{
    /// <summary>
    ///  Класс, описывающий печатное издание, характеризуется именем и числом страниц.
    /// </summary>
    [DataContract, KnownType(typeof(Book)), KnownType(typeof(Magazine))]
    public abstract class PrintEdition : IPrinting
    {
        // Имя печатного издания.
        [DataMember]
        public string name;
        [DataMember]
        // Число страниц в печатном издании.
        public int pages;
        // Пустой конструктор.
        public PrintEdition() { }      
        public PrintEdition(string name, int pages)
        {
            // Проверка формата имени на соотетствие условию.
            this.name = name;
            if (name.Length < 11 || name[0]<65 || name[0] > 90)
            {
                this.name = name;
            }
            else
            {
                throw new ArgumentException();
            }
            // Проверка формата числа страниц на соответвие условию.
            if (pages > 0)
            {
                this.pages = pages;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Переопределенный метод ToString.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"name = {name}; pages = {pages}";
        }
        /// <summary>
        ///  Событие onPrint, основанное на стандартном шаблоне,
        ///  сигнализирующее о печати книги.
        /// </summary>
        public event EventHandler<EventArgs>? onPrint;
        public void Print()
        {
            onPrint?.Invoke(this, EventArgs.Empty);
        }
    }
}