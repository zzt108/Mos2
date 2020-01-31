using System;
using System.IO;
using DataAccessLayer;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void CanGetRecruiterId()
        {
            Controller.Recruiters.GetByEmail("zzt@outlook.hu").RecruiterId.Should().Be(1);
        }


    }
}
