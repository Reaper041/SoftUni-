using System;
using System.Collections.Generic;

namespace Detail_Printer
{
    public class DetailsPrinter
    {
        private IList<INameable> people;

        public DetailsPrinter(IList<INameable> people)
        {
            this.people = people;
        }

        public void PrintDetails()
        {
            foreach (INameable person in this.people)
            {
                person.PrintDetails();
            }
        }
    }
}