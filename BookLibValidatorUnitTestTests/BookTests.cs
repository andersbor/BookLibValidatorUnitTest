using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibValidatorUnitTest;

namespace BookLibValidatorUnitTest.Tests
{
    [TestClass()]
    public class BookTests
    {
        private Book book = new Book { Id = 1, Title = "A", Price = 1 };
        private Book bookPriceNegative = new Book { Id = 2, Title = "A", Price = -1 };
        private Book bookTitleNull = new Book { Id = 3, Title = null, Price = 1 };
        private Book bookTitleShort = new Book { Id = 4, Title = "", Price = 1 };

        [TestMethod()]
        public void ToStringTest()
        {
            string str = book.ToString();   // act
            Assert.AreEqual("1 A 1", str);  // assert
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            book.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceNegative.ValidatePrice());
        }

        [TestMethod()]
        public void ValidateTitleTest()
        {
            book.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => bookTitleNull.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => bookTitleShort.ValidateTitle());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            book.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceNegative.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => bookTitleNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => bookTitleShort.Validate());
        }

        [TestMethod()]
        [DataRow(2)]
        [DataRow(100)]
        [DataRow(14593)]
        public void ValidatePricesTest(int price)
        {
            book.Price = price;
            book.ValidatePrice();
        }
    }
}