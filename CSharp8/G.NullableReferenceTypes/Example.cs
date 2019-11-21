#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CS0219 // Variable is assigned but its value is never used
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8.G.NullableReferenceTypes {
    class Example : IApp {
        public void Run() {
            string? nullableString = null;
            string nonNullableStringWithWarning = null; //Warning CS8600  Converting null literal or possible null value to non - nullable type
            string nonNullableString = "";
        }
    }

    public class ExampleClass {
        /// <summary>
        /// Warning: 
        /// </summary>
        public string NameWithWarning { get; } //Warning CS8618  Non-nullable property 'Name' is uninitialized.Consider declaring the property as nullable.
        public string NameWithoutWarning { get; } = "";
        public string? NullableName { get; }
    }

    public class OtherExampleClass {
        public OtherExampleClass() { //Warning CS8618  Non-nullable property 'Name' is uninitialized.Consider declaring the property as nullable.
            NameWithoutWarning = "";
        }

        public string NameWithWarningButNotActuallyHere { get; }
        public string NameWithoutWarning { get; }
        public string? NullableName { get; }
    }
}

#pragma warning restore CS0219 // Variable is assigned but its value is never used
#pragma warning restore IDE0059 // Unnecessary assignment of a value