using System;
using Xunit;
using CalculatorApp;

namespace CalTest
{
    public class CalculatorTest
    {
        
        private Calculator newCalculator = new Calculator();
        [Theory]
        public void AdditionTest(int value1, int value2, int expected){
            var result = newCalculator.Addition(value1, value2);
            Assert.Equal(expected,result);
        }
         public void SubstractionTest(){

        }
        public void MultiplicationTest(){

        }
        public void DivisionTest(){

        }
        public void FibTest(){

        }
        public void PrimeNumberTest(){

        }
        public void EquationBalancedTest(){

        }
    }
}