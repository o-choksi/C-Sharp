using NUnit.Framework;
using Moq;
using System.IO;
using UserInputFile;

namespace UserInputFile.Tests
{
    [TestFixture]
    public class UserInputHandlerTests
    {
        private Mock<TextReader> mockTextReader;
        private UserInputHandler inputHandler;

        [SetUp]
        public void Setup()
        {
            mockTextReader = new Mock<TextReader>();
            inputHandler = new UserInputHandler();
            Console.SetIn(mockTextReader.Object);
        }

        [Test]
        public void ReadInputAndWriteToFile_ShouldWriteInputToFile()
        {
            // Arrange
            var expectedInput = "Test Input";
            mockTextReader.Setup(tr => tr.ReadLine()).Returns(expectedInput);
            var tempFile = Path.GetTempFileName();

            // Act
            inputHandler.ReadInputAndWriteToFile(tempFile);

            // Assert
            var writtenText = File.ReadAllText(tempFile);
            Assert.AreEqual(expectedInput, writtenText);

            // Cleanup
            File.Delete(tempFile);
        }
    }
}
