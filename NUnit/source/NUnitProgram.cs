using UserInput;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHandler = new UserInputHandler();
            inputHandler.ReadInputAndWriteToFile("output.txt");
        }
    }
}
