using Xunit;

namespace MyLibrary.Facts {
    public class FilUpFact {
        public class Kml {
            [Fact]
            public void FirstFillUp_Null() {
                var x = new FillUp();
                x.Odometer = 100;
                x.Liters = 50.00;
                x.IsFull = true;

                double? kml = x.Kml;

                Assert.Null(kml);
            }

            [Fact]
            public void SecondFillUp() {
                var f1 = new FillUp();
                f1.Odometer = 1000;
                f1.Liters = 50.00;
                f1.IsFull = true;

                var f2 = new FillUp();
                f2.Odometer = 1600;
                f2.Liters = 60.00;
                f2.IsFull = true;

                f1.NextFilUp = f2;

                double? kml1 = f1.Kml;
                double? kml2 = f2.Kml;

                Assert.Equal(10, kml1);
                Assert.Null(kml2);
            }
        }
    }
}