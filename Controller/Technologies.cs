using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;

namespace Controller
{
    public static class Technologies
    {

        public static IList<Technology> GetAll()
        {
            using (var uw = new UnitOfWork())
            {
                return uw.TechnologyRepository.Get(tech => true).ToList();
            }

        }

        public static Technology GetByName(string technology)
        {
            using (var uw = new UnitOfWork())
            {
                return uw.TechnologyRepository.Get(tech => tech.Name == technology).FirstOrDefault();
            }
        }
    }
}