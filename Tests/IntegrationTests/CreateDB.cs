﻿using System;
using System.Linq;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using FluentAssertions;

namespace IntegrationTest
{
    [TestClass]
    public class CreateDb
    {
        [TestMethod]
        public void CreateDataBase()
        {
            Console.WriteLine(AppContext.BaseDirectory);

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

        //[TestMethod]
        public void GetJsonData()
        {
            var jArrayTechs = GetJson("https://v1.ifs.aero/technologies/");
            foreach (var tech in jArrayTechs)
            {
                var t = new Technology(tech);
                t.Name.Should().NotBeEmpty();
            }

            var jArrayCandidates = GetJson("https://v1.ifs.aero/candidates/");
            foreach (var jTokenCandidate in jArrayCandidates)
            {
                var c = new Candidate(jTokenCandidate);
                using (var uw = new UnitOfWork())
                {
                    AddTechnologies(uw, c, jTokenCandidate);
                }
            }
        }

        private static void AddTechnologies(UnitOfWork uw, Candidate candidate, JToken jTokenCandidate)
        {
            var content = jTokenCandidate["technologies"];
            var techArray = content.Children();
            foreach (var tech in techArray)
            {
                var techName = tech["name"].ToString();
                var t = uw.TechnologyRepository.Get(technology => technology.Name == techName).FirstOrDefault();
                if (t != null)
                {
                    var experience = new Experience()
                    {
                        Technology = t, 
                        Candidate = candidate,
                        Years = tech["experianceYears"].Value<int>() // property is misspelled in source JSon
                    };
                    uw.ExperienceRepository.Add(experience);
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
                    Last = "Toth",
                },
                PasswordSaltedHash = "empty",
            });

            var jsonTechs = GetJson("https://v1.ifs.aero/technologies/");
            var jsonCandidates = GetJson("https://v1.ifs.aero/candidates/");

            foreach (var tech in jsonTechs)
            {
                uw.TechnologyRepository.Add(new Technology(tech));
            }
            uw.SaveChanges();

            foreach (var jsonCandidate in jsonCandidates)
            {
                var candidate = new Candidate(jsonCandidate);
                uw.CandidateRepository.Add(candidate);
                AddTechnologies(uw, candidate,jsonCandidate);
            }

            uw.SaveChanges();

            Console.WriteLine("Base data generated");
        }

        private static JArray GetJson(string baseUrl)
        {

            var client = new HttpClient();

            var jsonString = client.GetStringAsync(baseUrl).Result;

            var jsonResponse = JArray.Parse(jsonString);

            return jsonResponse;
        }
    }
}