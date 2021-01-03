using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
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
        public void GradeBetween0and100()
        {
            var book = new InMemoryBook("test");
            book.AddGrade(105.0);
            book.AddGrade(-5.0);
            book.AddGrade(0);
            var result = book.GetStatistics();
            Assert.Equal(0.0, result.Average, 1);
        }
    }
}
