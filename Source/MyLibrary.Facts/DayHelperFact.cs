using System;
using Xunit;

namespace MyLibrary.Facts
{
    public class DayUtilFact {

        public class ToFriendlyText {
            [Fact]
            public void SingleDay() {
                // arrange
                var d = new DayHelper();
                var input  = new int [ ] { 1 };

                // act
                var result = d.ToFrieldlyText(input);

                // assert
                Assert.Equal("1", result);
            }
        }
    }
}
