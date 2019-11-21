using System;

namespace CSharp8.C {
    public class Example : IApp {
        public static Color FromRainbow(Rainbow colorBand) =>
            colorBand switch
            {
                Rainbow.Red => new Color(0xFF, 0x00, 0x00),
                Rainbow.Orange => new Color(0xFF, 0x7F, 0x00),
                Rainbow.Yellow => new Color(0xFF, 0xFF, 0x00),
                Rainbow.Green => new Color(0x00, 0xFF, 0x00),
                Rainbow.Blue => new Color(0x00, 0x00, 0xFF),
                Rainbow.Indigo => new Color(0x4B, 0x00, 0x82),
                Rainbow.Violet => new Color(0x94, 0x00, 0xD3),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
            };

        public static Rainbow FromColor(Color color) =>
            color switch
            {
                { Red: 255 } => Rainbow.Red,
                { Green: 255 } => Rainbow.Green,
                { Blue: 255 } => Rainbow.Blue,
                _ => Rainbow.Indigo,
            };

        public void Run() {
            Console.WriteLine("Switch expression pattern");
            Console.WriteLine("-------------------------");
            var blue = FromRainbow(Rainbow.Blue);
            Console.WriteLine(blue);
            var orange = FromRainbow(Rainbow.Orange);
            Console.WriteLine(orange);
            var indigo = FromRainbow(Rainbow.Indigo);
            Console.WriteLine(indigo);
            try {
                var error = FromRainbow((Rainbow)12);
                Console.WriteLine(error);
            } catch (Exception ex) {
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine();

            Console.WriteLine("Property patterns");
            Console.WriteLine("-----------------");
            var redRainbow = FromColor(new Color(255, 0, 0));
            Console.WriteLine(redRainbow);
            var greenRainbow = FromColor(new Color(0, 255, 0));
            Console.WriteLine(greenRainbow);
            var blueRainbow = FromColor(new Color(0, 0, 255));
            Console.WriteLine(blueRainbow);
            var whatRainbow = FromColor(new Color(128, 128, 128));
            Console.WriteLine(whatRainbow);
        }
    }

    public enum Rainbow {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    public struct Color {
        public Color(int red, int green, int blue) {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }

        public void Deconstruct(out int red, out int green, out int blue) => (red, green, blue) = (Red, Green, Blue);

        public override string ToString() {
            return $"Color:{Red}|{Green}|{Blue}";
        }
    }
}
