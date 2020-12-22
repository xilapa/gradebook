using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void GetStatisticsTest()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(12.0);
            book.AddGrade(14.0);
            book.AddGrade(13.3);

            // act 
            var result = book.GetStatistics();

            // assert
            Assert.Equal(12.0, result.Low, 1);
            Assert.Equal(14.0, result.High, 1);
            Assert.Equal(13.1, result.Average, 1);
            // terceiro argumento é a precisão de casas decimais
        }


        public void CountInstancesTest()
        {
            // arrange
            var book1 = new Book("book");
            var book2 = new Book("book");

            // act
            var result = Book.CountInstances();

            // assert
            Assert.NotEqual(book1,book2);
            Assert.Equal(3,result);
            // conta a instância do método acima

        }
    }
}
