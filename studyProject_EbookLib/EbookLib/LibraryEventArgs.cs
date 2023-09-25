using System;

namespace EbookLib
{
    /// <summary>
    /// Класс аргументов события onTake.
    /// </summary>
    public class LibraryEventArgs : EventArgs
    {
        public char start;
        public LibraryEventArgs(char start)
        {
            this.start = start;
        }
    }
}