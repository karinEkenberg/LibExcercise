using static System.Console;
using LibExcercise;

namespace LibExcercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;

            Other other = new Other();
            Book book = new Book();
            Lender lender = new Lender();
            Library library = new Library();
            library.SavedLibraryToJson();

            while (run)
            {
             

                Clear();
                ForegroundColor = ConsoleColor.Magenta;
                BackgroundColor = ConsoleColor.Yellow;
                WriteLine("--------------------------------------");
                WriteLine("[1] - Add books.");
                WriteLine("[2] - Lend book/s.");
                WriteLine("[3] - Return book/s.");
                WriteLine("[4] - Show available books.");
                WriteLine("[5] - Show lenders and what they lent.");
                WriteLine("[6] - Exit program.");
                WriteLine("--------------------------------------");

                Int32.TryParse(ReadLine(), out int input);

                switch (input)
                {
                    case 1:
                        library.AddBookFromUserInput();
                        
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        library.PrintBooks();
                        break;
                    case 5:
                        break;
                    case 6:
                        Other.Text("Shutting down...");
                        run = false;
                        return;
                    default:
                        Other.Warning("Wrong input.. Try 1-6...");
                        break;
                }
            }
        }
    }
}
