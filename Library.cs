using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Console;
using Newtonsoft.Json;
using System.IO;


namespace LibExcercise
{
    public class Library : Book
    {

        public List<Book> books;

        public Library() 
        {
            books = new List<Book>();
            LoadLibraryFromJson();
            AddBooks();
        }

        public void AddBooks()
        {
            Book book1 = new Book { Author = "Kristin Hannah", Title = "The Women: A Novel", Year = 2023, Description = "Women can be heroes. When twenty-year-old nursing student Frances “Frankie” McGrath hears these words, it is a revelation. Raised in the sun-drenched, idyllic world of Southern California and sheltered by her conservative parents, she has always prided herself on doing the right thing. But in 1965, the world is changing, and she suddenly dares to imagine a different future for herself. When her brother ships out to serve in Vietnam, she joins the Army Nurse Corps and follows his path." };
            Book book2 = new Book { Author = " Jamie Kern Lima", Title = "Worthy: How to Believe You Are Enough and Transform Your Life", Year = 2024, Description = "Imagine what you’d do if you FULLY believed in YOU! When you stop doubting your greatness, build unshakable self-worth and embrace who you are, you transform your entire life! WORTHY teaches you how, with simple steps that lead to life-changing results!" };
            Book book3 = new Book { Author = "J.R.R Tolkien", Title = "The Fellowship of the Ring", Year = 1954, Description = "Set in Middle-earth, the story tells of the Dark Lord Sauron, who seeks the One Ring, which contains part of his might, to return to power. The Ring has found its way to the young hobbit Frodo Baggins. The fate of Middle-earth hangs in the balance as Frodo and eight companions (who form the Fellowship of the Ring) begin their perilous journey to Mount Doom in the land of Mordor, the only place where the Ring can be destroyed. The Fellowship of the Ring was financed and distributed by American studio New Line Cinema, but filmed and edited entirely in Jackson's native New Zealand, concurrently with the other two parts of the trilogy." };
            Book book4 = new Book { Author = "George Orwell", Title = "1984", Year = 1949, Description = "1984 is a dystopian novel by George Orwell published in 1949. The story follows the life of Winston Smith, who lives in a totalitarian society where the government, led by the Party, exercises complete control over the people."};
            Book book5 = new Book { Author = "Gabriel Garcia Marquez", Title = "One Hundred Years of Solitude", Year = 1967, Description = "One Hundred Years of Solitude is a landmark 1967 novel by Colombian author Gabriel García Márquez that tells the multi-generational story of the Buendía family, whose patriarch, José Arcadio Buendía, founded the town of Macondo, a fictitious town in the country of Colombia."};
            Book book6 = new Book { Author = "Harper Lee", Title = "To Kill a Mockingbird", Year = 1960, Description = "To Kill a Mockingbird is a novel by Harper Lee published in 1960. It is set in the fictional town of Maycomb, Alabama, and follows the story of a young girl named Scout Finch as she grows up in the racially charged atmosphere of the American South during the 1930s."};
            
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            books.Add(book6);
        }

        public void AddBook(string author, string title, int year, string description)
        {

            Book book = new Book { Author = author, Title = title, Year = year, Description = description };
            books.Add(book);
            
        }

        public void AddBookFromUserInput()
        {
            WriteLine("Name of the book:");
            string title = ReadLine();
            WriteLine("Name of the author:");
            string author = ReadLine();
            WriteLine("Year the book was made:");
            int year = int.Parse(ReadLine());
            WriteLine("Description of the book:");
            string description = ReadLine();

            Book newBook = new Book
            {
                Title = title,
                Author = author,
                Year = year,
                Description = description
            };

            AddBook(author, title, year, description);
            SavedLibraryToJson();
        }

        public void PrintBooks()
        {
            foreach (Book book in books)
            {
                WriteLine($"\nTitle: {book.Title} \nAuthor: {book.Author} \nPublished: {book.Year} \nDescription: {book.Description}.");
                
            }

            ReadLine();
        }

        public void SavedLibraryToJson()
        {
            string filePath = "library.json";
            string json = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void LoadLibraryFromJson()
        {
            string filePath = "library.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
            else
            {
                WriteLine("Library JSON file not found. Creating a new library..");
            }
            

        }
    }
}
