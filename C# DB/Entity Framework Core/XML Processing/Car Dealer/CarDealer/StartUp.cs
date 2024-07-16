using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string suppliersInput = File.ReadAllText("D:\\GitHub Repos\\SoftUni\\C# DB\\Entity Framework Core\\XML Processing\\Car Dealer\\CarDealer\\Datasets\\suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersInput));

            //string partsInput = File.ReadAllText("D:\\GitHub Repos\\SoftUni\\C# DB\\Entity Framework Core\\XML Processing\\Car Dealer\\CarDealer\\Datasets\\parts.xml");
            //Console.WriteLine(ImportParts(context, partsInput));

            //string carsInput = File.ReadAllText("D:\\GitHub Repos\\SoftUni\\C# DB\\Entity Framework Core\\XML Processing\\Car Dealer\\CarDealer\\Datasets\\cars.xml");
            //Console.WriteLine(ImportCars(context, carsInput));

            //string customersInput = File.ReadAllText("D:\\GitHub Repos\\SoftUni\\C# DB\\Entity Framework Core\\XML Processing\\Car Dealer\\CarDealer\\Datasets\\customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersInput));

            //string saleInput = File.ReadAllText("D:\\GitHub Repos\\SoftUni\\C# DB\\Entity Framework Core\\XML Processing\\Car Dealer\\CarDealer\\Datasets\\sales.xml");
            //Console.WriteLine(ImportSales(context, saleInput));

            //Console.WriteLine(GetCarsWithDistance(context));

            //Console.WriteLine(GetCarsFromMakeBmw(context));

            //Console.WriteLine(GetLocalSuppliers(context));

            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            Console.WriteLine(GetTotalSalesByCustomer(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierImportDto[]), 
                new XmlRootAttribute("Suppliers"));

            SupplierImportDto[] dtos;

            using (StringReader sr = new StringReader(inputXml))
            {
                dtos = (SupplierImportDto[])xmlSerializer.Deserialize(sr);
            }

            Supplier[] suppliers = dtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                }).ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartImportDto[]),
                new XmlRootAttribute("Parts"));

            PartImportDto[] dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = (PartImportDto[])xmlSerializer.Deserialize(reader);
            }

            var validSupplierIds = context.Suppliers.Select(s => s.Id).ToArray();

            var parts = dtos.Where(dto => validSupplierIds.Contains(dto.SupplierId))
                .Select(dto => new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarImportDto[]),
                new XmlRootAttribute("Cars"));

            CarImportDto[] dtos;
            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = (CarImportDto[])xmlSerializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();

            foreach (var dto in dtos)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance,
                    
                };

                int[] carPartIds = dto.PartIds
                    .Select(i => i.Id)
                    .Distinct()
                    .ToArray();

                var carParts = new List<PartCar>();

                foreach(var id in carPartIds)
                {
                    carParts.Add(new PartCar()
                    {
                        Car = car,
                        PartId = id
                    });
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();


            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerImportDto[]), 
                new XmlRootAttribute("Customers"));

            CustomerImportDto[] dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = (CustomerImportDto[])xmlSerializer.Deserialize(reader);
            }

            List<Customer> customers = dtos
                .Select(d => new Customer()
                {
                    Name = d.Name,
                    BirthDate = d.Birthdate,
                    IsYoungDriver = d.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleImportDto[]),
                new XmlRootAttribute("Sales"));

            SaleImportDto[] dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = (SaleImportDto[])xmlSerializer.Deserialize(reader);
            }

            int[] validCarIds = context.Cars.Select(c => c.Id).ToArray();

            List<Sale> sales = dtos
                .Where(d => validCarIds.Contains(d.CarId) )
                .Select(d => new Sale()
                {
                    CarId = d.CarId,
                    CustomerId = d.CustomerId,
                    Discount = d.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context
                .Cars
                .Select(c => new CarExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarExportDto[]),
                new XmlRootAttribute("cars"));

            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                xmlSerializer.Serialize(textWriter, carsWithDistance, ns);
                return textWriter.ToString();
            }
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var BMWCars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new BMWCarExportDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c  => c.TraveledDistance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BMWCarExportDto[]),
                new XmlRootAttribute("cars"));

            using ( StringWriter textWriter = new StringWriter())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                xmlSerializer.Serialize(textWriter, BMWCars, ns);
                return textWriter.ToString();
            }
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new SupplierExportDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierExportDto[]),
                new XmlRootAttribute("suppliers"));

            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                xmlSerializer.Serialize(textWriter, localSuppliers, ns);
                return textWriter.ToString();
            }
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context
                .Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarsWithPartsExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .OrderByDescending(pc => pc.Part.Price)                
                        .Select(pc => new CarPartDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .ToArray()
                })
                .ToArray();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsWithPartsExportDto[]),
                new XmlRootAttribute("cars"));

            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                xmlSerializer.Serialize(textWriter, carsWithParts, ns);
                return textWriter.ToString();
            }
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var temp = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Price = c.IsYoungDriver ?
                        s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2)) :
                        s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price, 2 ))
                    }).ToArray()
                })
                .ToArray();

            var customerSalesInfo = temp
                .OrderByDescending(t => t.SalesInfo.Sum(s => s.Price))
                .Select(c => new CustomerWithBoughtCarExportDto()
                {
                    FullName = c.FullName,
                    BoughtCars = c.BoughtCars,
                    SpentMoney = c.SalesInfo.Sum (s => (decimal)s.Price)
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerWithBoughtCarExportDto[]),
                new XmlRootAttribute("customers"));

            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                xmlSerializer.Serialize(textWriter, customerSalesInfo, ns);
                return textWriter.ToString();
            }
        }
    }
}