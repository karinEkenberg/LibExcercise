using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Console;

namespace LibExcercise
{
    internal class Lender : Library 
    {
		private Library library;
		public List<Borrower> Lenders {  get; set; } = new List<Borrower>();


		public Lender(Library library)
		{
			this.library = library;
			Lenders = LoadLendersFromJson();
		}

		public void LendingBooks(List<Borrower> borrowers)
		{
			WriteLine("What book do you want to borrow?");
			string wantedBook = ReadLine();
			bool isAvailable = CheckBookAvailability(wantedBook);
			if (isAvailable)
			{
				WriteLine("The book is available to borrow. Enter your first name:");
				string fName = ReadLine();
				WriteLine("Enter last name");
				string lName = ReadLine();
				WriteLine("Enter your social security number:");
				string socNr = ReadLine();

				if (!string.IsNullOrWhiteSpace(fName) && !string.IsNullOrWhiteSpace(lName) && !string.IsNullOrWhiteSpace(socNr)
				{
					Borrower newBorrower = new Borrower
					{
						FirstName = fName,
						LastName = lName,
						SocSecNr = socNr,
						BorrowedBooks = wantedBook
					};
					borrowers.Add(newBorrower);
					SavedLendersToJson(borrowers);
					UpdateBookStatus(wantedBook, "unavailable.");
				}
				else
				{
					WriteLine("Please fill all the required fields!");
				} 
			}
            else
            {
				WriteLine("The book is not available..");
            }
			ReadLine();
        }

		public void SavedLendersToJson(List<Borrower> borrowers)
		{
			string filePath = "lenders.json";
			string json = JsonConvert.SerializeObject(borrowers, Formatting.Indented);
			File.WriteAllText(filePath, json);
		}

		public bool CheckBookAvailability (string title)
		{
			return library.books.Any(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
		}

		public void PrintLenders()
		{
			
			foreach (Borrower borrowers in Lenders)
			{
				Book borrowedBook = library.books.FirstOrDefault(book => book.Title.Equals(borrowers.BorrowedBooks, StringComparison.OrdinalIgnoreCase));
				if (borrowedBook != null)
				{
					WriteLine($"\nFirst name: {borrowers.FirstName} \nLast name: {borrowers.LastName} \nSocial security number: {borrowers.SocSecNr} \nBorrowed book: {borrowedBook.Title} \nAuthor: {borrowedBook.Author}.");
				}
				else
				{
					WriteLine($"\nFirst name: {borrowers.FirstName} \nLast name: {borrowers.LastName} \nSocial security number: {borrowers.SocSecNr} \nBorrowed book: {borrowers.BorrowedBooks}´(Book not found).");
				}

			}
			ReadLine();
		}

		private List<Borrower> LoadLendersFromJson()
		{
			string filePath = "lenders.json";
			if (File.Exists(filePath))
			{
				string json = File.ReadAllText(filePath);
				return JsonConvert.DeserializeObject<List<Borrower>>(json);
			}
			return new List<Borrower>();
		}

		private void UpdateBookStatus(string title, string status)
		{
			Book book = library.books.FirstOrDefault(b => b.Title.Equals(title,StringComparison.OrdinalIgnoreCase));
			if (book != null)
			{
				book.Status = status;
				library.SavedLibraryToJson();
			}
		}

	}
}
