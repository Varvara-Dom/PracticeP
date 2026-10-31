using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level3
{

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
    public class Reader
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; private set; } = new List<Book>();

        public Reader(string name)
        {
            Name = name;
        }
    }

    public class Library
    {
        public List<Book> Books { get; private set; } = new List<Book>();
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void BorrowBook(Reader reader, Book book)
        {
            
            if (!Books.Contains(book)) throw new ArgumentException("Этой книги нет в библиотеке.");

            
            if (!book.IsAvailable) throw new InvalidOperationException($"Книга '{book.Title}' уже выдана другому читателю.");

            
            if (reader.BorrowedBooks.Count >= 3) throw new InvalidOperationException($"Читатель '{reader.Name}' превысил лимит выдачи (макс. 3 книги).");

            book.IsAvailable = false;
            reader.BorrowedBooks.Add(book);
        }
        public void ReturnBook(Reader reader, Book book)
        {
            
            if (!reader.BorrowedBooks.Contains(book)) throw new InvalidOperationException($"Читатель '{reader.Name}' не брал книгу '{book.Title}'.");

            
            book.IsAvailable = true;
            reader.BorrowedBooks.Remove(book);
        }
    }
    internal class Ex45_MiniProjectLibrary : ITask
    {
        public string Title => "Минипроект «Библиотека» + юниттесты";
        public string Description => "Классы библиотеки + тесты.";
        public string[] Condition => new[]
        {
            "Классы: Book (Title, Author, IsAvailable), Reader (Name, BorrowedBooks), Library (выдача/возврат)",
            "Логика: выдача книги читателю, возврат, лимит (не больше 3 книг на читателя)",
            "Обработка: книгу уже выдали, лимит превышен — бросать исключения",
            "Написать 5+ юниттестов (xUnit/NUnit) на ключевые сценарии",
            " Все тесты должны проходить"
        };

        public void Launch()
        {
            Console.WriteLine("Демонстрация работы библиотеки");

            var library = new Library();
            var book1 = new Book("Собор Парижской Богоматери", "В. Гюго");
            var book2 = new Book("Щегол", "Д. Тартт");
            var book3 = new Book("Три любви", "А. Кронин");
            var book4 = new Book("Гордость и предупреждение", "Д. Остин");
            var book5 = new Book("Доктор Живаго", "Б. Пастернак");

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);

            var reader = new Reader("Валерия");

            try
            {
                Console.WriteLine("1.Валерия берет 'Щегол'..");
                library.BorrowBook(reader, book1);
                Console.WriteLine("Успешно!");

                Console.WriteLine("2.Валерия берет 'Гордость и предупреждение'..");
                library.BorrowBook(reader, book2);
                Console.WriteLine("Успешно!");

                Console.WriteLine("3.Валерия берет 'Доктор Живаго'..");
                library.BorrowBook(reader, book3);
                Console.WriteLine("Успешно!");

                Console.WriteLine("4.Валерия пытается взять 4-ю книгу 'Собор Парижской Богоматери' (ошибку лимита)..");
                library.BorrowBook(reader, book4);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Исключение]: {ex.Message}");
            }

            try
            {
                Console.WriteLine("\n5.Валерия возвращает 'Щегол'...");
                library.ReturnBook(reader, book1);
                Console.WriteLine("Успешно!");

                Console.WriteLine("6.Валерия берет 4-ю книгу 'Собор Парижской Богоматери' (теперь можно)...");
                library.BorrowBook(reader, book4);
                Console.WriteLine("Успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Исключение]: {ex.Message}");
            }
        }
    }
}
