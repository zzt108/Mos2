using System;
using System.Web;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Controller;

namespace IntegrationTest
{
    [TestClass]
    public class CreateDB
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
                    Console.WriteLine("Recruiter with ID 1 found");
                }
            }
        }

        [TestMethod]
        public void GetJsonData()
        {
            var jArrayTechs = GetJson("https://v1.ifs.aero/technologies/");
            foreach (var tech in jArrayTechs)
            {
                var t = new Technology(tech);
            }

            var jArrayCandidates = GetJson("https://v1.ifs.aero/candidates/");
            foreach (var jTokenCandidate in jArrayCandidates)
            {
                var c = new Candidate(jTokenCandidate);
                using (var uw = new UnitOfWork())
                {
                    Candidates.AddTechnologies(uw, c, jTokenCandidate);
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

            var jsonTechs = GetJson("https://v1.ifs.aero/technologies/");
            var jsonCandidates = GetJson("https://v1.ifs.aero/candidates/");

            foreach (var tech in jsonTechs)
            {
                uw.TechnologyRepository.Add(new Technology(tech));
            }

            foreach (var jsonCandidate in jsonCandidates)
            {
                var candidate = new Candidate(jsonCandidate);
                uw.CandidateRepository.Add(candidate);
                Candidates.AddTechnologies(uw, candidate,jsonCandidate);
            }
            uw.SaveChanges();
            Console.WriteLine("Base data generated");
        }

        public static JArray GetJson(string baseUrl)
        {

            var client = new HttpClient();

            var jsonString = client.GetStringAsync(baseUrl).Result;

            var jsonResponse = JArray.Parse(jsonString);

            return jsonResponse;
        }
    }
}