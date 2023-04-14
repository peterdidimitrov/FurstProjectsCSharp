using NUnit.Framework;
using System;
using System.Text;

namespace UniversityLibrary.Tests
{
    [TestFixture]
    public class UniversityLibraryTests
    {
        private TextBook book1;
        private TextBook book2;
        private TextBook book3;
        private UniversityLibrary library;

        [SetUp]
        public void Setup()
        {
            book1 = new TextBook("C# in Depth", "Jon Skeet", "Programming");
            book2 = new TextBook("The Art of Computer Programming", "Donald Knuth", "Programming");
            book3 = new TextBook("Operating System Concepts", "Abraham Silberschatz", "Computer Science");

            library = new UniversityLibrary();
        }
        [Test]
        public void Test1()
        {
            TextBook textBook = new TextBook("History", "Balabanov", "Humanity");

            UniversityLibrary library = new UniversityLibrary();

            var actualResult = library.AddTextBookToLibrary(textBook);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: History - 1");
            sb.AppendLine($"Category: Humanity");
            sb.AppendLine($"Author: Balabanov");

            var expectedResult = sb.ToString().TrimEnd();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test2()
        {
            TextBook textBook = new TextBook("History", "Balabanov", "Humanity");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);

            library.LoanTextBook(1, "George Bush");
            var actualResult = library.ReturnTextBook(1);
            var expectedResult = "History is returned to the library.";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(string.Empty, Is.EqualTo(textBook.Holder));
        }

        [Test]
        public void AddTextBookToLibrary_ShouldAddBookToCatalogue()
        {
            // Arrange
            int expectedCount = 1;

            // Act
            library.AddTextBookToLibrary(book1);

            // Assert
            Assert.That(library.Catalogue.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void LoanTextBook_ShouldLoanBookToStudent()
        {
            // Arrange
            string studentName = "John";
            string expectedMessage = $"{book1.Title} loaned to {studentName}.";

            // Act
            library.AddTextBookToLibrary(book1);
            string actualMessage = library.LoanTextBook(book1.InventoryNumber, studentName);

            // Assert
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void LoanTextBook_ShouldNotLoanBookToSameStudent()
        {
            // Arrange
            string studentName = "John";
            library.AddTextBookToLibrary(book1);
            library.LoanTextBook(book1.InventoryNumber, studentName);
            string expectedMessage = $"{studentName} still hasn't returned {book1.Title}!";

            // Act
            string actualMessage = library.LoanTextBook(book1.InventoryNumber, studentName);

            // Assert
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void ReturnTextBook_ShouldReturnBookToLibrary()
        {
            // Arrange
            string expectedMessage = $"{book1.Title} is returned to the library.";
            library.AddTextBookToLibrary(book1);
            library.LoanTextBook(book1.InventoryNumber, "John");

            // Act
            string actualMessage = library.ReturnTextBook(book1.InventoryNumber);

            // Assert
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void TextBookToString_ShouldReturnFormattedString()
        {
            // Arrange
            string expectedString = $"Book: {book1.Title} - {book1.InventoryNumber}{Environment.NewLine}Category: {book1.Category}{Environment.NewLine}Author: {book1.Author}";

            // Act
            string actualString = book1.ToString();

            // Assert
            Assert.That(actualString, Is.EqualTo(expectedString));
        }
    }
}
