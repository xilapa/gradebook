using System;
using Xunit;

namespace GradeBook.Tests
{
    public class DiskBookTests
    {
        [Fact]
        public void GetStatisticsTest()
        {
            // arrange
            var book = new DiskBook("new book");
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
            var book = new DiskBook("test");
            Assert.Throws<ArgumentException>(() =>book.AddGrade(-5.0));
        }

        [Fact]
        public void GradeLessOrEqualtoOneHundred()
        {
            var book = new DiskBook("test");
            Assert.Throws<ArgumentException>(() =>book.AddGrade(110.0));
        }

        [Fact]
        public void BookNameIsNotNull()
        {
            Book book;
            Assert.Throws<ArgumentException>(() => book = new DiskBook(null));
        }

        [Fact]
        public void BookNameIsNotEmpty()
        {
            Book book;
            Assert.Throws<ArgumentException>(() => book = new DiskBook(""));
        }
        
        [Fact]
        public void GradeAddedEventIsRaised()
        {
            var book = new DiskBook("test");
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
