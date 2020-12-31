using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        private int count = 0;
        public delegate string WriteLogDelegate(string logMessage);

        [Fact]
        public void WriteLogDelegateCanPointToManyMethods()
        {
            WriteLogDelegate logger = writeLogAndReturnMessage;
            logger += ReturnMessage;
            logger("message");
            Assert.Equal(2, count);

        }

        private string ReturnMessage(string message)
        {
            count ++;
            return message;
        }

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            var logger = new WriteLogDelegate(writeLogAndReturnMessage);
            var result = logger("message");
            Assert.Equal("message",result);

        }

        private string writeLogAndReturnMessage(string message)
        {
            count ++;
            Console.WriteLine(message);
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            var name = "Dirceu";
            ToUpperCase(name);
            Assert.Equal("Dirceu",name);
        }

        private void ToUpperCase(string parameter)
        {
            parameter.ToUpper();
        }

        [Fact]
        public void CSharpCanPassByRef()
        // mantém um link entre a variável e o parâmetro
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1,"New name");
            Assert.Equal("New name",book1.Name);
        }

        private void GetBookSetNameRef(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpPassIsByValue()
        {
            // no método GetBookSetName a referência de book foi trocada para a valor de outro ponteiro
            // por isso não há alteração do valor em book1
            var book1 = GetBook("Book 1");
            GetBookSetName(book1,"New name");
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);
            Assert.Equal(5,x);
        }

        private void SetInt(int x)
        {
            x = 10;
        }

        private int GetInt()
        {
            return 5;
        }

        [Fact]
        public void SetNameByReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1,"New name");
            Assert.Equal("New name",book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            // act

            // assert
            Assert.Equal("Book 1",book1.GetBookName());
            Assert.Equal("Book 2",book2.GetBookName());
            Assert.NotSame(book1,book2);

        }

        [Fact]
        public void TwoVarsReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // copia o ponteiro de book1 

            // act
            book1.AddGrade(10.0);
            book2.AddGrade(12.0);

            // assert
            Assert.Same(book1,book2);            
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}