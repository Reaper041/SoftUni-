using System.Linq;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && bunny.Dyes.Count > 0)
            {
                var dye = bunny.Dyes.First();
                egg.GetColored();
                dye.Use();
                bunny.Work();

                if (dye.IsFinished())
                {
                    bunny.Dyes.Remove(dye);
                }

                if (egg.IsDone())
                {
                    break;
                }

                
            }
        }
    }
}