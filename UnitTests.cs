using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturn0WhenEmptyString()
        {
            Calculator c = new Calculator();
            int result = c.Add("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1",1)]
        [InlineData("4", 4)]
        public void ShouldReturnNumber(string input, int expectedValue)
        {
            Calculator c = new Calculator();
            int result = c.Add(input);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("1,4", 5)]
        [InlineData("4,2", 6)]
        public void ShouldReturnSumOfTwoNumbers(string input, int expectedValue)
        {
            Calculator c = new Calculator();
            int result = c.Add(input);
            Assert.Equal(expectedValue, result);
        }


        [Theory]
        [InlineData("1,4,7,1", 13)]
        [InlineData("4,2,8,8,8", 30)]
        public void ShouldReturnSumOfAnyNumbers(string input, int expectedValue)
        {
            Calculator c = new Calculator();
            int result = c.Add(input);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("1\n4,7,1", 13)]
        [InlineData("4,2,8\n8,8", 30)]
        public void ShouldReturnSumOfAnyNumbersWithNewline(string input, int expectedValue)
        {
            Calculator c = new Calculator();
            int result = c.Add(input);
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ShouldReturnSumOfAnyNumbersWithDelimeter()
        {
            Calculator c = new Calculator();
            int result = c.Add("//;1;4;7;1");
            Assert.Equal(13, result);
        }

        [Theory]
        [InlineData("1\n4,-7,-1")]
        [InlineData("4,2,8\n8,-8")]
        public void ShouldThrowErrorForNegativeNumbers(string input)
        {
            Calculator c = new Calculator();
            Assert.Throws<Exception>(()=>c.Add(input));
        }

        [Theory]
        [InlineData("1\n4,7,1,1001", 13)]
        [InlineData("4,2,8\n8,8,1002", 30)]
        public void ShouldReturnSumOfAnyNumbersAndIgnoreOver1000(string input, int expectedValue)
        {
            Calculator c = new Calculator();
            int result = c.Add(input);
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ShouldReturnSumOfAnyNumbersWithDelimeterOfAnyLen()
        {
            Calculator c = new Calculator();
            int result = c.Add("//[;;]1;;4;;7;;1");
            Assert.Equal(13, result);
        }

        [Fact]
        public void ShouldReturnSumOfAnyNumbersWithManyDelimeters()
        {
            Calculator c = new Calculator();
            int result = c.Add("//[;;][']1;;4'7'1");
            Assert.Equal(13, result);
        }

        [Fact]
        public void ShouldReturnSumOfAnyNumbersWithManyDelimetersOfAnyLen()
        {
            Calculator c = new Calculator();
            int result = c.Add("//[;;][,,]1;;4,,7;;1");
            Assert.Equal(13, result);
        }




    }
}
