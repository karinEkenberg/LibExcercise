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
            Library library = new Library();
			Lender lender = new Lender(library);
            var borrowers = new List<Borrower>();
			library.SavedLibraryToJson();
			library.LoadBooksFromJson("library.json");

			while (run)
            {
                Clear();
                ForegroundColor = ConsoleColor.Magenta;
                BackgroundColor = ConsoleColor.Yellow;
                WriteLine("--------------------------------------");
                WriteLine("[1] - Add books.");
                WriteLine("[2] - Lend book/s.");
                WriteLine("[3] - Return book/s.");
                WriteLine("[4] - Show books.");
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
                        lender.LendingBooks(borrowers);
                        break;
                    case 3:
                        lender.ReturnBooks();
                        break;
                    case 4:
                        library.PrintBooks();
                        break;
                    case 5:
                        lender.PrintLenders();
                        break;
                    case 6:
                        Other.Text("Shutting down... Goodbye!");
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
