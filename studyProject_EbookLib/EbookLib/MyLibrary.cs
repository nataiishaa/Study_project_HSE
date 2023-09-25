using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EbookLib
{
    /// <summary>
    /// Обобщенный класс, реаоизующий интерфейс. Класс представляет
    /// итерируемую коллекцию печатных изданий.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class MyLibrary<T>  : IEnumerable where T : PrintEdition
    {
        [DataMember]
        // Список объектов.
        public List<PrintEdition> library;
        // Событие, сигнализирующее,  что библиотеки изъяты все книги.
        public event EventHandler<LibraryEventArgs> onTake;
        public MyLibraryEnumerator<List<PrintEdition>> myLibraryEnumerator;
        public MyLibrary()
        {
            library = new List<PrintEdition>();
            myLibraryEnumerator = new MyLibraryEnumerator<List<PrintEdition>>(library);
        }
        public void TakeBooks(char start)
        {
            onTake?.Invoke(this, new LibraryEventArgs(start));
        }
        /// <summary>
        /// Свойство, позволяющее вычислить и вернуть среднее число страниц во всех книгах,
        /// состоящих в коллекции.
        /// </summary>
        public double GetAverageCountOfPagesInBook {
            get
            {
                int sum = 0;
                int count = 0;
                foreach (var pr in library)
                {
                    if (pr is Book)
                    {
                        sum += pr.pages;
                        count++;
                    }
                }
                if (count != 0)
                {
                    return (double)sum / count;
                }
                    Console.WriteLine("Возникло деление на 0. Список книг пуст.");
                return 0;
            }
        }
        /// <summary>
        /// Количество печатных изданий в библиотеке.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return library.Count;
        }
        /// <summary>
        /// Свойство, позволяющее вычислить и вернуть среднее число страниц во всех журналах,
        /// состоящих в коллекции.
        /// </summary>
        public double GetAverageCountOfPagesInMagazine {
            get
            {
                int sum = 0;
                int count = 0;
                foreach (var pr in library)
                {
                    if (pr is Magazine)
                    {
                        sum += pr.pages;
                        count++;
                    }
                }
                if (count != 0)
                {
                    return (double)sum / count;
                }
                
               Console.WriteLine("Возникло деление на 0. Список журналов пуст.");
               return 0;

            }
        }
        /// <summary>
        /// Индексатор.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>    
        public PrintEdition this[int index] 
        { 
            get 
            { 
                if (true)
                { 
                    return library[index];
                }               
                else
                {
                    throw new IndexOutOfRangeException();
                }       
            } 

        }
        /// <summary>
        /// Метод  для добавления переданного в качестве параметра объекта к списку library.
        /// </summary>
        /// <param name="printed"></param>
        public void Add(T printed)
        {
            library.Add(printed);
        }
        /// <summary>
        ///  Метод удаления печатного издания из библиотеки.
        /// </summary>
        /// <param name="printEdition"></param>
        public void Remove(T printEdition)
        {
            library.Remove(printEdition);
        }
        /// <summary>
        ///  Переопределенный метод для вывода на экран информациию о количестве страниц в печатт.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {          
            string context = String.Empty;
            int sumOfPages = 0;
            foreach (var pr in library)
            {
                sumOfPages += pr.pages;
            }

            context += $"Count of pages in all of printeditions {sumOfPages}\n";
            foreach (var pr in library)
            {
                context += pr.ToString() + "\n";
            }
            return context;
        }
        public IEnumerator GetEnumerator()
        {
            return new MyLibraryEnumerator<List<PrintEdition>>(library);
        }
        /// <summary>
        /// Дополнительный класс для реализации итератора.
        /// </summary>
        /// <typeparam name="U"></typeparam>
        public class MyLibraryEnumerator<U> : IEnumerator, IEnumerable where U: List<PrintEdition>
        {
            private int position = -1;
            private U _printEditions;
            public MyLibraryEnumerator(U library)
            {
                _printEditions = library;
            }           
            public bool MoveNext()
            {
                if (position < _printEditions.Count - 1)
                {
                    position++;
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                position = -1;
            }
            public object Current
            {
                get
                {
                    if (position == -1 || position >= _printEditions.Count)
                        throw new ArgumentException();
                    return _printEditions[position];
                }
            }
            public IEnumerator GetEnumerator()
            {
                return this;
            }
        }
    }
}
