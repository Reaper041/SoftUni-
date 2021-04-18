using System.Collections.Generic;
using System.Linq;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models;

        public BunnyRepository()
        {
            models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => models.AsReadOnly().ToList();

        public void Add(IBunny model)
        {
            models.Add(model);
        }

        public bool Remove(IBunny model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }

            return false;
        }

        public IBunny FindByName(string name)
        {
            if (models.Exists(x => x.Name == name))
            {
                return models.FirstOrDefault(x => x.Name == name);
            }

            return null;
        }
    }
}