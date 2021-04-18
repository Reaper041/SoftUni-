using System.Collections.Generic;
using System.Linq;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> models;

        public EggRepository()
        {
            models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => models.AsReadOnly().ToList();

        public void Add(IEgg model)
        {
            models.Add(model);
        }

        public bool Remove(IEgg model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }

            return false;
        }

        public IEgg FindByName(string name)
        {
            if (models.Exists(x => x.Name == name))
            {
                return models.FirstOrDefault(x => x.Name == name);
            }

            return null;
        }
    }
}