using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace MyLibrary.Facts
{
    public class DayUtilFact {
        
        public static IEnumerable<object[]> DayInMonthTestData() {
            //return Enumerable.Range(1, 31).Select( x => new object[] { x, x.ToString()});
            for (int i = 1; i <= 31; i++) {
                yield return new object [] { i, i.ToString()};
            }
        }

        public class ToFriendlyText {
            [Theory]
            //[InlineData(1, "1")]
            //[InlineData(2, "2")]
            //[InlineData(3, "3")]
            [InlineData(4, "4")]
            //[MemberData(nameof(DayInMonthTestData))]
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
            [InlineData(new int[] { 1, 2, 3}, "1-3")]
            [InlineData(new int[] { 1, 2, 3, 4 ,5}, "1-5")]
            public void ContinuouslyDay8(int[] days, string excpected) {
                var d = new DayHelper();

                var result = d.ToFrieldlyText(days);

                Assert.Equal(excpected, result);
            }


            [Fact]
            public void InvalidDay_TrowsException() {
                var d = new DayHelper();

                Assert.Throws<InvalidDateException>(() => {
                    var result = d.ToFrieldlyText(new int[] { 0, 1});
                });
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
