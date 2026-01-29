using MyNUnitSolution.MockVarExample;
using Moq;

namespace MyLibrary.Tests
{
    [TestFixture]
    public class CollegeServiceTest
    {
        private Mock<ICollegeService> _mockRepo;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<ICollegeService>();
            CollegeService collegeService = new CollegeService();
        }

        [Test]
        public void GetFarewellNote_ShouldReturnCorrectFarewellMessage()
        {
            CollegeService collegeService = new CollegeService();
            var result = collegeService.GetFarewellNote("John"); ;
            Assert.That(result, Is.EqualTo("All the best, John!"));

        }

        [Test]
        public void GetWelcomeNote_ShouldReturnCorrectWelcomeMessage()
        {
            CollegeService collegeService = new CollegeService();
            var result = collegeService.GetWelcomeNote("John"); ;
            Assert.That(result, Is.EqualTo("Welcome, John!"));
        }
    }
}