using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string LogMessage);
    
    public class TypeTests
    {
        int count = 0;
        
        [Fact]
        public void WriteLogDelegateCanPointToAnotherMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");
            Assert.Equal(3, count);
        }
        
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange - establishing the components to compare
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            //act - the logic calculation
            
            
            //assert - the test
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        // [Fact]
        // public void TwoVarsCanReferenceSameObject()
        // {
        //     //arrange - establishing the components to compare
        //     var book1 = GetBook("Book 1");
        //     var book2 = book1; //copies the pointer not the values of the instance
            
        //     //act - the logic calculation
        //     //book1.Name = "Book 2"; //Book 1 and Book 2 point to the same object therefore both will be named book 2 because of this line
            
        //     //assert - the test
        //     Assert.Same(book1, book2);
        //     Assert.True(Object.ReferenceEquals(book1, book2));//same as other assert, different way to write it.
        //     Assert.Equal("Book 2", book2.Name); //proof that book 2 has the same change as book 1 (same object instance)
        // }

        // [Fact]
        // public void CanSetNameFromReference()
        // {
        //     //arrange - establishing the components to compare
        //     var book1 = GetBook("Book 1");

        //     //act - the logic calculation
        //     SetName(book1, "New Name");
            
        //     //assert - the test
        //     Assert.Equal("New Name", book1.Name);
        // }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange - establishing the components to compare
            var book1 = GetBook("Book 1");

            //act - the logic calculation
            GetBookSetName(book1, "New Name");
            
            //assert - the test
            Assert.Equal("Book 1", book1.Name);
        }

        [Fact]
        public void PassByReference()
        {
            //arrange - establishing the components to compare
            var book1 = GetBook("Book 1");

            //act - the logic calculation
            RefGetBookSetName(ref book1, "New Name");
            
            //assert - the test
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42,x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        private void RefGetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            //book.Name = name;
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
