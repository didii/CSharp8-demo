using System;

namespace CSharp8.J {
    public class Example : IApp {
        public void Run() {
            Console.WriteLine("int? number = null;");
            int? number = null;
            Console.WriteLine("> number: " + number);

            Console.WriteLine("number ??= 5;");
            number ??= 5;
            Console.WriteLine("> number: " + number);

            Console.WriteLine("number ??= 8;");
            number ??= 8;
            Console.WriteLine("> number: " + number);
        }
    }
}
