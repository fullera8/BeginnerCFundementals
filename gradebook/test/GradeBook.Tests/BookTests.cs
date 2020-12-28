using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange - establishing the components to compare
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            book.AddGrade('A');
            book.AddGrade('a');
            book.AddGrade('B');
            book.AddGrade('b');
            book.AddGrade('C');
            book.AddGrade('c');
            book.AddGrade('D');
            book.AddGrade('d');
            book.AddGrade('F');
            book.AddGrade('f');
            //book.AddGrade(105.0);
            
            //act - the logic calculation
            var result = book.GetStatistics();
            
            //assert - the test
            Assert.Equal(65.9, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(0, result.Low, 1);
            Assert.Equal('D', result.letter);
        }
    }
}
