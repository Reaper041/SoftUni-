namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ICollection<Creator> validCreators = new List<Creator>();

            var xmlSerializer = new XmlSerializer(typeof(CreatorImportDto[]), new XmlRootAttribute("Creators"));

            using StringReader xmlReader = new StringReader(xmlString);
            var creatorImportDtos = (CreatorImportDto[])xmlSerializer.Deserialize(xmlReader)!;

            foreach( var creatorImportDto in creatorImportDtos )
            {
                if(!IsValid(creatorImportDto))
                {
                    stringBuilder.AppendLine(ErrorMessage); 
                    continue; 
                }

                ICollection<Boardgame> boardgames = new List<Boardgame>();

                foreach (var boardgameImportDto in creatorImportDto.Boardgames)
                {
                    if (!IsValid(boardgameImportDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = boardgameImportDto.Name,
                        YearPublished = boardgameImportDto.YearPublished,
                        Rating = boardgameImportDto.Rating,
                        CategoryType = (CategoryType)boardgameImportDto.CategoryType,
                        Mechanics = boardgameImportDto.Mechanics,
                    };

                    boardgames.Add(boardgame);
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorImportDto.FirstName,
                    LastName = creatorImportDto.LastName,
                    Boardgames = boardgames
                };

                validCreators.Add(creator);
                stringBuilder.AppendLine(String.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count()));
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ICollection<Seller> validSellers = new List<Seller>();

            SellerImportDto[] sellerImportDtos = JsonConvert.DeserializeObject<SellerImportDto[]>(jsonString)!;

            foreach (var dto in sellerImportDtos)
            {
                if (!IsValid(dto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                List<BoardgameSeller> boardgamesSellers = new List<BoardgameSeller>();

                Seller seller = new Seller()
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Country = dto.Country,
                    Website = dto.Website,

                };


                foreach (var boardgameId in dto.Boardgames.Distinct())
                {
                    Boardgame? b = context.Boardgames.Find(boardgameId);
                    if (b == null)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        BoardgameId = boardgameId,
                        Boardgame = b,
                        Seller = seller
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);

                }
                validSellers.Add(seller);
                stringBuilder.AppendLine(String.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));

            }
            context.Sellers.AddRange(validSellers);
            context.SaveChanges();
            return stringBuilder.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
