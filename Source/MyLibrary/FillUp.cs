
namespace MyLibrary {
    public class FillUp {
        public FillUp() { }

        public FillUp  NextFilUp { set;get; }

        public int Odometer { get; set; }
        public double Liters { get; set; }
        public bool IsFull { get; set; }

        public double? Kml { 
            get {
                if(NextFilUp != null) {
                    var r = NextFilUp.Odometer - Odometer;
                    return  r / NextFilUp.Liters;
                }
                return null;
            }
        }
    }
}