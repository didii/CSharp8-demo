using System;
using System.IO;

namespace CSharp8.D {
    internal class Example : IApp {
        private static string FileName = "D.UsingDeclaration.Example.txt";
        public void Run() {
            // Make sure the file exists
            Console.WriteLine("Creating file");
            using (var w = File.AppendText(FileName)) { }

            {
                Console.WriteLine("Opnening file in scope 1");
                // Open the file in a sub-scope
                using var file = File.Open(FileName, FileMode.Append);
                file.WriteByte(0b0100);
                // file is disposed here
                Console.WriteLine("Dispose file in scope 1");
            }

            {
                Console.WriteLine("Opnening file in scope 2");
                // Re-opening in different scope is fine
                using var file = File.Open(FileName, FileMode.Append);
                file.WriteByte(0b0100);
                // file is disposed here
                Console.WriteLine("Dispose file in scope 2");
            }

            {
                Console.WriteLine("Opnening file in scope 3");
                // Opening multiple in the same scope will be a problem
                using var file1 = File.Open(FileName, FileMode.Append);
                file1.WriteByte(0b0100);
                Console.WriteLine("Opnening file in scope 3");
                // Crashy crachy
                using var file2 = File.Open(FileName, FileMode.Append);
                file2.WriteByte(0b0100);
                Console.WriteLine("Dispose file in scope 3");
                Console.WriteLine("Dispose file in scope 3");
            }
        }
    }
}
