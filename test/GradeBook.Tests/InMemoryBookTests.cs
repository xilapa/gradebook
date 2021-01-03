using System;
using Xunit;

namespace GradeBook.Tests
{
    public class InMemoryBookTests
    {
        [Fact]
        public void GetStatisticsTest()
        {
            // arrange
            var book = new InMemoryBook("new book");
            book.AddGrade(12.0);
            book.AddGrade(14.0);
            book.AddGrade(13.3);

            // act 
            var result = book.GetStatistics();

            // assert
            Assert.Equal(12.0, result.Low, 1);
            Assert.Equal(14.0, result.High, 1);
            Assert.Equal(13.1, result.Average, 1);
            Assert.Equal('F',result.Letter);
            // terceiro argumento é a precisão de casas decimais
        }


        [Fact]
        public void GradeGreaterThanOrEqualToZero()
        {
            var book = new InMemoryBook("test");
            Assert.Throws<ArgumentException>(() =>book.AddGrade(-5.0));
        }

        [Fact]
        public void GradeLessOrEqualtoOneHundred()
        {
            var book = new InMemoryBook("test");
            Assert.Throws<ArgumentException>(() =>book.AddGrade(110.0));
        }

        [Fact]
        public void BookNameIsNotNull()
        {
            Book book;
            Assert.Throws<ArgumentException>(() => book = new InMemoryBook(null));
        }

        [Fact]
        public void BookNameIsNotEmpty()
        {
            Book book;
            Assert.Throws<ArgumentException>(() => book = new InMemoryBook(""));
        }
        
        [Fact]
        public void GradeAddedEventIsRaised()
        {
            var book = new InMemoryBook("test");
            book.GradeAdded += GradeAddedEventTest;
            book.AddGrade(10.0);
            Assert.True(EventCalled);

        }
        private bool EventCalled = false;
        private void GradeAddedEventTest(object sender, EventArgs args)
        {
            Console.WriteLine("Grade Added");
            EventCalled = true;
        }

    }
}
