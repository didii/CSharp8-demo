using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8.E {
    class Example : IApp {
        public void Run() {
            var scopedObj = new object();
            void WriteObject() {
                Console.WriteLine("WriteObject: " + scopedObj);
            }
            static void StaticWriteObject(object obj) {
                Console.WriteLine("StaticWriteObject: " + obj);
            }
            static void InvalidStaticWriteObject() {
                //Error CS8421  A static local function cannot contain a reference to 'scopedObj'.
                //Console.WriteLine("InvalidStaticWriteObject" + scopedObj);
            }

            WriteObject();
            StaticWriteObject(scopedObj);
            InvalidStaticWriteObject();
        }
    }
}
