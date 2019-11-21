using System;
using System.Diagnostics.Contracts;

namespace CSharp8.A {
    public class Example : IApp {
        public void Run() {
            var @class = new InvalidReadonlyClass();
            @class.ToString();
        }
    }

    public struct ClassicStruct {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);

        public override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }

    public struct ReadonlyWithWarningStruct {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);

        public override readonly string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }

    public struct ProperReadonlyStruct {
        public double X { get; set; }
        public double Y { get; set; }
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);

        public override readonly string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }

    public struct InvalidReadonlyStruct {
        public double X { get; set; }
        public double Y { get; set; }

        //Error CS1604  Cannot assign to 'X' because it is read-only
        public /*readonly*/ void Translate(double dx, double dy) {
            X += dx;
            Y += dy;
        }
    }

    public class InvalidReadonlyClass {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);

        //Error CS0106  The modifier 'readonly' is not valid for this item
        [Pure]
        public /*readonly*/ override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }
}
