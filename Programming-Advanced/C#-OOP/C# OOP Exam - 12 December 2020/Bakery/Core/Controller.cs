using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<BakedFood> bakedFoods;
        private List<Drink> drinks;
        private List<Table> tables;
        private decimal total;

        public Controller()
        {
            bakedFoods = new List<BakedFood>();
            drinks = new List<Drink>();
            tables = new List<Table>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else
            {
                food = new Cake(name, price);
            }

            bakedFoods.Add(food);
            return $"Added {name} ({type}) to the menu";
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);

            return $"Added table number {tableNumber} in the bakery";
        }

        public string ReserveTable(int numberOfPeople)
        {
            Table table = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (table != null)
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }

            return $"No available table for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            BakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            Drink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            decimal bill = table.GetBill();
            this.total += bill;
            table.Clear();

            return $"Table: {tableNumber}\r\n" +
                   $"Bill: {bill}";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {total:f2}lv";
        }
    }
}