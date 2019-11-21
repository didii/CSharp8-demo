using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8.H {
    public class Example : IApp {
        public void Run() {
            RunAsync().Wait();
        }

        public async Task RunAsync() {
            await foreach (var num in GenerateEnumerable(100)) {
                Console.Write(num + " ");
            }
        }

        private async IAsyncEnumerable<int> GenerateEnumerable(int max) {
            int count = 0;
            while (true) {
                if (count >= max) {
                    yield break;
                }
                await Task.Delay(100);
                yield return count;
                count++;
            }
        }
    }
}
