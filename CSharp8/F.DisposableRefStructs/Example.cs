using System;

namespace CSharp8.F.DisposableRefStructs {
    internal class Example : IApp {
        public void Run() {
            using (var disposableRefStruct = new DisposableRefStruct()) {
                Console.WriteLine("This works!");
            }
        }
    }

    public ref struct DisposableRefStruct {
        public void Dispose() {
            Console.WriteLine("Disposing");
        }
    }
}
