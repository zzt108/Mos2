using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest.ControllerTests
{
    [TestClass]
    public class RecruiterTest
    {
        [TestMethod]
        public void CanGetRecruiterId()
        {
            Controller.Recruiters.GetByEmail("zzt@outlook.hu").RecruiterId.Should().Be(1);
        }

    }
}