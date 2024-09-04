using System;
using System.IO;

namespace UserInputFile
{
    public class UserInputHandler
    {
        public void ReadInputAndWriteToFile(string filePath)
        {
            Console.WriteLine("Please enter some text:");
            var input = Console.ReadLine();
            File.WriteAllText(filePath, input);
        }
    }
}
