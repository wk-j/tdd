using System;
using Xunit;

namespace MyLibrary.Facts
{
    public class DayUtilFact {

        public class ToFriendlyText {
            [Theory]
            [InlineData(1, "1")]
            [InlineData(2, "2")]
            [InlineData(3, "3")]
            [InlineData(4, "4")]
            public void SingleDay(int day, string expected) {
                // arrange
                var d = new DayHelper();
                var input  = new int [ ] { day };

                // act
                var result = d.ToFrieldlyText(input);

                // assert
                Assert.Equal(expected, result);
            }

            [Theory]
            [InlineData(new int[] { 1,2,3}, "1-3")]
            public void ContinuouslyDay(int[] days, string excpected) {
                var d = new DayHelper();

                var result = d.ToFrieldlyText(days);

                Assert.Equal(excpected, result);
            }

            [Fact]
            public void EmptyArray_ReturnEmptyString() {
                // arrange
                var d = new DayHelper();
                var input = new int[] {};

                // act
                var result = d.ToFrieldlyText(input);

                // assert
                Assert.Equal("", result);
            }
        }
    }
}
