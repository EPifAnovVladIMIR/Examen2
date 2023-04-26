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
 
                    bookcontrol.Save("Books.txt");
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
        

        
        public Book[] books;
        public BookControl(int size) => books = new Book[size];

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
                Console.WriteLine($"Жанр: {book.Janr} Автор: {book.Author} Название книги: {book.Name}");
        }

        public void Sort()
        {
            Book buf;
            bool isSorted = false;
            for (int i = 0; i < books.Length; i++)
            {
                for (int j = 0; j < books.Length - 1; j++)
                {
                    for (int symbol = 0; symbol < books[j].Janr.Length; symbol++)
                    {
                        if (books[j].Janr[symbol] > books[j + 1].Janr[symbol])
                        {
                            break;
                        }
                        else if (books[j].Janr[symbol] < books[j + 1].Janr[symbol])
                        {
                            buf = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = buf;

                            break;
                        }
                        else
                        {
                            if (books[j].Author[symbol] > books[j + 1].Author[symbol])
                            {
                                break;
                            }
                            else if (books[j].Author[symbol] < books[j + 1].Author[symbol])
                            {
                                buf = books[j];
                                books[j] = books[j + 1];
                                books[j + 1] = buf;

                                break;
                            }
                            else
                            {
                                if (books[j].Name[symbol] > books[j + 1].Name[symbol])
                                {
                                    break;
                                }
                                else if (books[j].Name[symbol] < books[j + 1].Name[symbol])
                                {
                                    buf = books[j];
                                    books[j] = books[j + 1];
                                    books[j + 1] = buf;

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }



        public void Save(string filePuth)
        {
            Console.WriteLine("Сохранение");
            Console.WriteLine("- - - - - - - - - - -");
            using (StreamWriter writer = new StreamWriter(filePuth))
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"Жанр: {book.Janr} Автор: {book.Author} Название: {book.Name}");

                    writer.WriteLine("Автор: " + book.Author + " Название: " + book.Name + " Жанр: " + book.Janr);
                }
            }
        }
    }
}
