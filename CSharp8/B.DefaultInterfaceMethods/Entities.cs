namespace CSharp8.B {
    public interface IBaseEntity {
        public int Id { get; }
        public string? ToString() {
            return $"{{id:{Id}}}";
        }
    }

    public class BaseEntity : object, IBaseEntity {
        /// <inheritdoc />
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    public class Entity : IBaseEntity {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        //Stack overflow
        //public override string ToString() => ((IBaseEntity)this).ToString();
    }
}
