namespace GenericTuple
{
    public class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst first, TSecond second)
        {
            this.Key = first;
            this.Value = second;
        }

        public TFirst? Key { get; private set; }

        public TSecond? Value { get; private set; }

        public override string ToString()
        {
            return $"{this.Key} -> {this.Value}";
        }
    }
}
