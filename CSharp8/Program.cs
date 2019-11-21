using System;

namespace CSharp8 {
    class Program {
        static void Main(string[] args) {
            IApp app = new J.Example();
            app.Run();
        }
    }
}
