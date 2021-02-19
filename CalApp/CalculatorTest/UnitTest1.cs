using System;
using Xunit;
using CalculatorBL;

namespace CalculatorTest
{
    public class UnitTest1
    {
        
        private CalculatorRun newCalculator = new CalculatorRun();
        [Fact]
        public void AdditionTest(){
            int value1 = 1;
            int value2 = 1;
            int expected = 2;
            var result = newCalculator.Addition(value1, value2);
            Assert.Equal(expected,result);
        }
        [Fact]
         public void SubstractionTest(){
            int value1 = 1;
            int value2 = 1;
            int expected = 0;
            var result = newCalculator.Substraction(value1, value2);
            Assert.Equal(expected,result);
        }
        [Fact]
        public void MultiplicationTest(){
            int value1 = 2;
            int value2 = 2;
            int expected = 4;
            var result = newCalculator.Multiplication(value1, value2);
            Assert.Equal(expected,result);
        }
        [Fact]
        public void DivisionTest(){
            int value1 = 2;
            int value2 = 1;
            int expected = 2;
            var result = newCalculator.Division(value1, value2);
            Assert.Equal(expected,result);
        }
        [Fact]
        public void FibTest(){
            int value1 = 3;
            int expected = 2;
            var result = newCalculator.Fib(value1);
            Assert.Equal(expected,result);
        }
        [Fact]
        public void PrimeNumberTest(){
            int value1 = 3;
            Boolean expected = true;
            var result = newCalculator.PrimeNumber(value1);
            Assert.Equal(expected,result);
        }
        // public void EquationBalancedTest(){

        // }
    }
}
