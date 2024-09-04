using NUnit.Framework;
using System.IO;
using UserInputFile;

namespace UserInputFile.IntegrationTests
{
    [TestFixture]
    public class UserInputHandlerIntegrationTests
    {
        private UserInputHandler inputHandler;

        [SetUp]
        public void Setup()
        {
            inputHandler = new UserInputHandler();
        }

        [Test]
        public void ReadInputAndWriteToFile_IntegrationTest()
        {
            // Arrange
            var filePath = "integration_test_output.txt";
            var expectedInput = "Integration Test Input";

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                Console.SetIn(new StringReader(expectedInput));

                // Act
                inputHandler.ReadInputAndWriteToFile(filePath);

                // Assert
                var writtenText = File.ReadAllText(filePath);
                Assert.AreEqual(expectedInput, writtenText);

                // Cleanup
                File.Delete(filePath);
            }
        }
    }
}
