using System.Runtime.Serialization;

namespace EbookLib
{
    /// <summary>
    /// Класс Magazine – наследник класса PrintEdition, дополнительно содержит описание периодичности
    /// издания журнала (period).
    /// </summary>
    [DataContract, KnownType(typeof(PrintEdition))]
    public class Magazine : PrintEdition
    {
        [DataMember]
        public int period;       
        public Magazine() {}
        public Magazine(string name, int pages, int period) : base(name, pages)
        {
            this.period = period;
        }
        /// <summary>
        /// Переопределенный метод для вывода на экран информации о периоде.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $"; period = {period}";
        }
    }
}
