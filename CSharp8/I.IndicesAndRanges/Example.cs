using System;
using System.Linq;

namespace CSharp8.I {
    internal class Example : IApp {
        private string[] _words = new string[]
        {
                        // index from start    index from end
            "The",      // 0                   ^9
            "quick",    // 1                   ^8
            "brown",    // 2                   ^7
            "fox",      // 3                   ^6
            "jumped",   // 4                   ^5
            "over",     // 5                   ^4
            "the",      // 6                   ^3
            "lazy",     // 7                   ^2
            "dog"       // 8                   ^1
        };

        public void Run() {
            for (var i = 0; i < _words.Length; i++) {
                Console.Write($"({i}/^{_words.Length - i}){_words[i]} ");
            }
            var num = 5;
            Console.WriteLine();
            Console.WriteLine("[1]:      " + _words[1]);
            Console.WriteLine("[^1]:     " + _words[^1]);
            Console.WriteLine("[1..4]:   " + _words[1..4].Aggregate((a, b) => $"{a} {b}"));
            Console.WriteLine("[3..^2]:  " + _words[0..^2].Aggregate((a, b) => $"{a} {b}"));
            Console.WriteLine("[^6..^2]: " + _words[^6..^2].Aggregate((a, b) => $"{a} {b}"));
            Console.WriteLine("[..3]:    " + _words[..3].Aggregate((a, b) => $"{a} {b}"));
            Console.WriteLine("[^3..]:   " + _words[^3..].Aggregate((a, b) => $"{a} {b}"));
            Console.WriteLine("[^num=5]: " + _words[^num..].Aggregate((a, b) => $"{a} {b}"));

            try {
                Console.Write("[4..1]:   ");
                Console.WriteLine(_words[4..1].Aggregate((a, b) => $"{a} {b}"));
            } catch (Exception ex) {
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
            }
        }
    }

}
