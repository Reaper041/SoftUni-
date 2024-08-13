namespace GenericBox
{
    public class Box<T>
        where T : IComparable
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T? Value { get; private set; }

        public override string ToString()
        {
            Type type = this.Value!.GetType();
            string valueTypeFullName = type.FullName!;


            return $"{valueTypeFullName}: {this.Value.ToString()}";
        }
    }
}
