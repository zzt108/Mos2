using System;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace IntegrationTest
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void CreateDb()
        {
            Console.WriteLine(AppContext.BaseDirectory);

            // Create context object and then save company data.
            using (var uw = new UnitOfWork())
            {
                var user = uw.RecruiterRepository.GetById(1);

                if (user == null)
                {
                    Console.WriteLine("Recruiter with ID 1 is not found, generating base data");
                    GenerateData(uw);
                }
                else
                {
                    Console.WriteLine("OldMunicipality with ID 1 found");
                }
            }
        }

        private static void GenerateData(UnitOfWork uw)
        {
            uw.RecruiterRepository.Add(new Recruiter()
            {
                Email = "zzt@outlook.hu",
                Name = new Name()
                {
                    First = "Zsolt",
                    Last = "Toth"
                },
                PasswordSaltedHash = "empty"
            });
            uw.SaveChanges();
        }
    }
}