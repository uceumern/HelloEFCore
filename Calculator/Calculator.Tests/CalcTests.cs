using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Calc_Sum_2_and_3_results_5()
        {
            //arrange
            var calc = new Calc();

            //act
            int result = calc.Sum(2, 3);

            //assert
            Assert.Equal(5, result);
        } 
        
        [Fact]
        public void Calc_Sum_0_and_0_results_0()
        {
            //arrange
            var calc = new Calc();

            //act
            int result = calc.Sum(0, 0);

            //assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Calc_Sum_intmin_and_1_throws_OverflowException()
        {
            //arrange
            var calc = new Calc();

            //act
            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }
    }
}