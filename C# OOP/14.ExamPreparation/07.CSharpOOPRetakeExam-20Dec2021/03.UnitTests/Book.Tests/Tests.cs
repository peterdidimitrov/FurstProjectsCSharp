namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book;
        [SetUp]
        public void SetUp()
        {
            this.book = new Book("Dog", "Wolf");
        }
        [Test]
        public void BookInitializeCorrect()
        {
            Assert.IsNotNull(book);
            Assert.That(book, Is.Not.Null);
            Assert.That(book.BookName, Is.EqualTo("Dog"));
            Assert.That(book.Author, Is.EqualTo("Wolf"));
        }
        [Test]
        public void BookInitializeWhitIncorretParamsShouldThrowArgumentException()
        {
            Book book;

            Assert.Throws<ArgumentException>(() => new Book("", "Wolf"), $"Invalid !");
            Assert.Throws<ArgumentException>(() => new Book(null, "Wolf"), $"Invalid !");
            Assert.Throws<ArgumentException>(() => new Book("Dog", ""), $"Invalid !");
            Assert.Throws<ArgumentException>(() => new Book("Dog", null), $"Invalid !");
        }
        [Test]
        public void AddFootnoteShouldAddOneNote()
        {
            this.book.AddFootnote(1, "Note");
            Assert.That(book.FootnoteCount, Is.EqualTo(1));
        }
        [Test]
        public void AddFootnoteThatAlreadyExists_ShouldThrowsInvalidOperationException()
        {
            this.book.AddFootnote(1, "Note");
            
            Assert.Throws<InvalidOperationException>(() => this.book.AddFootnote(1, "Note"), "Footnote already exists!");
        }
        [Test]
        public void FindFootnote_ShouldFindNote()
        {
            this.book.AddFootnote(1, "Note");
            var result = this.book.FindFootnote(1);

            Assert.That(result, Is.EqualTo("Footnote #1: Note"));
        }
        [Test]
        public void FindFootnote_ShouldThrowInvalidOperationExceptionWhenNoteDoesNotExist()
        {
            this.book.AddFootnote(1, "Note");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(2), "Footnote doesn't exists!");
        }
        [Test]
        public void AlterFootnoteShouldRewriteNewNotByFootNoteNumber()
        {
            this.book.AddFootnote(1, "Note");
            this.book.AlterFootnote(1, "NewText");

            Assert.That(book.FindFootnote(1), Is.EqualTo("Footnote #1: NewText"));
        }
        [Test]
        public void AlterFootnoteShouldThrowInvalidOperationExceptionWhenNoteDoesNotExist()
        {
            this.book.AddFootnote(1, "Note");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(2, "NewText"), "Footnote doesn't exists!");
        }
    }
}