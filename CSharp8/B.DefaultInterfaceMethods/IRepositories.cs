using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CSharp8.B {
    public interface IBaseRepository<T> where T : IBaseEntity {
        internal string DebugName => $"{GetType().Name}<{typeof(T).Name}>";
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T obj);
        T Update(T to);
        void Remove(int id);
    }

    public interface IExtendedBaseRepository<T> : IBaseRepository<T> where T : IBaseEntity {
        IEnumerable<T> CreateMany(IEnumerable<T> objs) {
            foreach (var obj in objs) {
                yield return Create(obj);
            }
        }

        IEnumerable<T> UpdateMany(IEnumerable<T> objs) {
            foreach (var obj in objs) {
                yield return Update(obj);
            }
        }

        void RemoveMany(IEnumerable<int> ids) {
            foreach (var id in ids) {
                Remove(id);
            }
        }
    }

    public interface IOtherExtendedBaseRepository<T> : IBaseRepository<T> where T : IBaseEntity {
        IEnumerable<T> GetAll(IEnumerable<int> ids) {
            foreach (var id in ids) {
                yield return Get(id);
            }
        }

        IEnumerable<T> RemoveMany(IEnumerable<int> ids) {
            var result = GetAll().Where(obj => ids.Contains(obj.Id));
            foreach (var id in ids) {
                Remove(id);
            }
            return result;
        }
    }

    public interface ISuperExtendedBaseRepository<T> : IExtendedBaseRepository<T> where T : IBaseEntity {
        IEnumerable<T> GetAllSorted<TKey>(string propName) {
            return Enumerable.OrderBy(GetAll(), (dynamic)CreatePropertyExpression(propName));
        }

        private Expression CreatePropertyExpression(string propName) {
            var parameter = Expression.Parameter(typeof(T));
            var memberExpr = Expression.Property(parameter, propName);
            var lambda = Expression.Lambda(memberExpr, parameter);
            return lambda;
        }
    }
}
