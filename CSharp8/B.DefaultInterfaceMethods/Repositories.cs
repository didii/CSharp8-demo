using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp8.B {
    public class BaseRepository<T> : IBaseRepository<T> where T : IBaseEntity, new() {
        private IBaseRepository<T> _interface => this;

        public BaseRepository() {
            Console.WriteLine($"Creating {_interface.DebugName}");
        }

        /// <inheritdoc />
        public IEnumerable<T> GetAll() {
            Console.WriteLine($"{_interface.DebugName}.GetAll()");
            return Enumerable.Empty<T>();
        }

        /// <inheritdoc />
        public T Get(int id) {
            Console.WriteLine($"{_interface.DebugName}.Get({id})");
            return new T();
        }

        /// <inheritdoc />
        public T Create(T obj) {
            Console.WriteLine($"{_interface.DebugName}.Create({obj.ToString()})");
            return obj;
        }

        /// <inheritdoc />
        public T Update(T to) {
            Console.WriteLine($"{_interface.DebugName}.Update({to.ToString()})");
            return to;
        }

        /// <inheritdoc />
        public void Remove(int id) {
            Console.WriteLine($"{_interface.DebugName}.Remove({id})");
        }
    }

    public class ExtendedBaseRepository<T> : BaseRepository<T>, IExtendedBaseRepository<T>  where T : IBaseEntity, new() { }

    public class DoublyBaseRepository<T> : BaseRepository<T>, IExtendedBaseRepository<T>, IOtherExtendedBaseRepository<T> where T : IBaseEntity, new() { }
}
