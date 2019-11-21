using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CSharp8.B {
    public class Example : IApp {
        public void Run() {
            Console.WriteLine("BaseRepository stuff");
            Console.WriteLine("--------------------");
            var baseRepo = new BaseRepository<Entity>();
            baseRepo.GetAll();
            baseRepo.Update(new Entity() { Id = 1, Name = "updateEntity" });
            baseRepo.Remove(1);

            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine();

            Console.WriteLine("BaseRepository stuff");
            Console.WriteLine("--------------------");
            var extendedRepo = new ExtendedBaseRepository<Entity>();
            //Error CS1061  'ExtendedBaseRepository<Entity>' does not contain a definition for 'UpdateMany' and no accessible extension method 'UpdateMany' accepting a first argument of type 'ExtendedBaseRepository<Entity>' could be found(are you missing a using directive or an assembly reference ?)
            //What in the everlasting mother? ...
            //extendedRepo.UpdateMany(new[] { 1, 2, 3 });
            IExtendedBaseRepository<Entity> iExtendedRepo = extendedRepo;
            iExtendedRepo.UpdateMany(new[] { new Entity() { Id = 5 }, new Entity() { Id = 8 } });
            iExtendedRepo.RemoveMany(new[] { 7, 8, 9 });

            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine();

            Console.WriteLine("DoublyRepository stuff");
            Console.WriteLine("----------------------");
            var doublyRepo = new DoublyBaseRepository<Entity>();
            //Error CS1061  'DoublyBaseRepository<Entity>' does not contain a definition for 'RemoveMany' and no accessible extension method 'RemoveMany' accepting a first argument of type 'DoublyBaseRepository<Entity>' could be found(are you missing a using directive or an assembly reference ?)
            //doublyRepo.RemoveMany(new[] { 1, 2, 3, 4 });
            ((IExtendedBaseRepository<Entity>)doublyRepo).RemoveMany(new[] { 1, 2, 3, 4 });
            var result = ((IOtherExtendedBaseRepository<Entity>)doublyRepo).RemoveMany(new[] { 1, 2, 3, 4 });

            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine();

            Console.WriteLine("Entity stuff");
            Console.WriteLine("------------");
            var entity = new Entity();
            Console.WriteLine("Entity.ToString():  " + entity.ToString());
            Console.WriteLine("IBaseEntity.ToString(): " + ((IBaseEntity)entity).ToString());
            var baseEntity = new BaseEntity();
            Console.WriteLine("BaseEntity.ToString():  " + entity.ToString());
            Console.WriteLine("IBaseEntity.ToString(): " + ((IBaseEntity)entity).ToString());
        }
    }


}
