
namespace MyLibrary {
    public class FillUp {
        public FillUp(int od, double li) {
            Odometer = od;
            Liters = li;
         }

        public FillUp  NextFillUp { set;get; }

        public int Odometer { get; set; }
        public double Liters { get; set; }
        public bool IsFull { get; set; }

        public double? Kml { 
            get {
                if(NextFillUp != null) {
                    var r = NextFillUp.Odometer - Odometer;
                    return  r / NextFillUp.Liters;
                }
                return null;
            }
        }
    }
}