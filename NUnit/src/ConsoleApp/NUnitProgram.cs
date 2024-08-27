using UserInputFile;

namespace ConsoleApp
{
    class NUnitProgram
    {
        static void Main(string[] args)
        {
            var inputHandler = new UserInputHandler();
            inputHandler.ReadInputAndWriteToFile("output.txt");
        }
    }
}
