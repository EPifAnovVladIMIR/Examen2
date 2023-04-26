using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Epifanov_program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool refresh = true;


            while (refresh)
            {
                try
                {

                    Console.Write("Введите размер массива Book: ");
                    int size = Convert.ToInt32(Console.ReadLine());
                    BookControl bookcontrol = new BookControl(size);

                    Console.WriteLine($"Введите {size} элементов массива.");
                    bookcontrol.Fill();


                    Console.WriteLine("Отсортированныый массив.");
                    bookcontrol.Sort();
                    bookcontrol.ViewBooks();

                    Console.WriteLine("Массив сохранен.");
                    bookcontrol.Save();
                    refresh = false;
                }
                catch
                {
                    Console.WriteLine("Ошибка!");
                    refresh = true;
                }
            }
        }
    }

    public class Book
    {
        public string Name;
        public string Janr;
        public string Author;
        

        public Book(string Name, string Janr, string Author) // Тип для хранения данных
        {
            this.Name = Name;
            this.Janr = Janr;
            this.Author = Author;
           
        }
    }

    public class BookControl
    {
        // Хранение массива, сортировки и вывода в файл. Работает с классом PrintToFile

        
        public Book[] books;
        public BookControl(int size) => books = new Book[size];
        /*
                public ElementsBook(int FullInfos)
                {
                    this.Elements = FullInfos;
                    FullInfo = new Book[FullInfos];
                }
        */



        public void Fill() // Функция диаологового заполнения
        {
            

                string Name;
                string Janr;
                string Author;
            

            for (int i = 0; i < this.books.Length; i++)
            {

                Console.WriteLine("Введите название:");
                Name = Console.ReadLine();
                Console.WriteLine("Введите Жанр:");
                Janr = Console.ReadLine();
                Console.WriteLine("Введите Автора книги:");
                Author = Console.ReadLine(); 
                this.books[i] = new Book(Name, Janr, Author);
            }

        }

        public void ViewBooks()
        {
            foreach (Book book in books)
                Console.WriteLine($"Жанр: {book.Janr} Название книги: {book.Name} Автор: {book.Author}");
        }



        public void Sort() => Array.Sort(books, (x, y) => (x.Janr + " " + x.Author + "" + x.Name).CompareTo(y.Janr + " " + y.Author + " " + y.Name));



        public void Save()
        {
            string path = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\Books.txt";
            using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Create)))
            {
                foreach (Book book in books)
                    Console.WriteLine($"Автор: {book.Author} Название: {book.Name} Жанр: {book.Janr}");
            }
        }
    }
}
