
namespace PersonInfo
{
    public interface IBuyer : IPerson
    {
        public int Food { get; set; }

        void BuyFood();
    }
}