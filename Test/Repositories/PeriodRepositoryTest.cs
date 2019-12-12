using System.Linq;
using Core.Base;
using Moq;
using NUnit.Framework;
using Test.Mock;
using Web.Controllers;

namespace Test.Repositories
{
    public class PeriodRepositoryTest
    {
        [Test]
        public void ShouldReturnPensumWithSubjects()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var periods = MockData.GetFakePeriod();
            var careers = MockData.GetFakeCareer();
            var careerId = careers.First().Id;

            unitOfWork.Setup(x => x.PeriodRepository.Pensum(careerId)).Returns(periods);
            var controller = new PensumController(unitOfWork.Object);

            var result = controller.Pensum(careerId);
            Assert.AreEqual(result, periods);
        }
    }
}