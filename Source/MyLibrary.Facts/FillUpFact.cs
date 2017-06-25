using Xunit;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace MyLibrary.Facts {
    public class FilUpFact {
        public class Kml {
            [Fact]
            public void FirstFillUp_Null() {
                var x = new FillUp(100, 50.00);
                //x.Odometer = 100;
                //x.Liters = 50.00;
                x.IsFull = true;

                double? kml = x.Kml;

                Assert.Null(kml);
            }

            [Fact]
            public void SecondFillUp() {
                var f1 = new FillUp(1000, 50.00);
                //f1.Odometer = 1000;
                //f1.Liters = 50.00;
                f1.IsFull = true;

                var f2 = new FillUp(1600, 60.00);
                //f2.Odometer = 1600;
                //f2.Liters = 60.00;
                f2.IsFull = true;

                f1.NextFillUp = f2;

                double? kml1 = f1.Kml;
                double? kml2 = f2.Kml;

                Assert.Equal(10, kml1);
                Assert.Null(kml2);
            }

            private static IEnumerable<object[]> FillUpCsv() {
                using(var reader = new StreamReader(new FileStream("/Users/wk/Source/github/TDD/Source/MyLibrary.Facts/FillUpData.csv", FileMode.Open))) {
                    var csv = new CsvReader(reader);
                    var data = csv.GetRecords<FillUpData>().ToArray();
                    for (var i = 0; i < data.Length - 1; i++) {
                        yield return new object[] {
                            data[i].Odometer, data[i].Liters,
                            data[i+1].Odometer, data[i+1].Liters,
                            data[i].Kml
                        };
                    }
                }
            }

 
            [Theory]
            [MemberData(nameof(FillUpCsv))]
            public void TwoFillUps(
                int odo1, double liters1,
                int odo2, double liters2,
                double? expected) {

                    // a
                var f1 = new FillUp(odo1, liters1);
                var f2 = new FillUp(odo2, liters2);  
                f1.NextFillUp = f2;
            
                // act
                double? kml1 = f1.Kml;
                double? kml2 = f2.Kml;
            
                // assert
                Assert.Equal(expected, kml1);
                Assert.Null(kml2);

            }

        }
    }
}