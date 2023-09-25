using System.Runtime.Serialization;

namespace EbookLib
    
{
    /// <summary>
    ///  Класс Book – наследник класса PrintEdition, дополнительно содержит описание автора книги.
    /// </summary>
    [DataContract, KnownType(typeof(PrintEdition))]
    
    public class Book : PrintEdition
    {
        [DataMember]
        public string author;
        //Пустой конструктор для сериализации.
        public Book() { }
        public Book(string name, int pages, string author) : base(name, pages)
        {
            this.author = author;
        }
        public string GetAuthor()
        {
            return author;
        }
        /// <summary>
        ///  Переопределенный метод для вывода на экран информациию об авторе.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $"; author = {author}";
        }
    }
}
