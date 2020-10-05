using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public static IList<Technology> GetAll(int modelPageSize, int modelPageNumber)
        {
            using (var uw = new UnitOfWork())
            {
                var source = uw.TechnologyRepository.Get( ).ToList();
                return source.Skip((modelPageNumber - 1) * modelPageSize).Take(modelPageSize).ToList();
            }
        }
    }
}