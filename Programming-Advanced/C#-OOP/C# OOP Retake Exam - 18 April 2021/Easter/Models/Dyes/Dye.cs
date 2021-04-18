using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        public Dye(int power)
        {
            Power = power;
        }

        public int Power { get; private set; }

        public void Use()
        {
            Power -= 10;

            if (Power < 0)
            {
                Power = 0;
            }
        }

        public bool IsFinished()
        {
            if (Power == 0)
            {
                return true;
            }

            return false;
        }
    }
}