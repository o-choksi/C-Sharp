
using System;
using System.IO;
using Keyoti.RapidSpell;
using Keyoti.RapidSpell.Dictionaries;

namespace SpellCheckerApp
{
    class KeyootiRapidSpellProgram
    {
        static void Main(string[] args)
        {
            // Check if a file path was provided as an argument
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a file path as an argument.");
                return;
            }

            string filePath = args[0];

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file does not exist.");
                return;
            }

            // Read the file content
            string content = File.ReadAllText(filePath);

            // Initialize RapidSpellAsYouType
            RapidSpellAsYouType spellChecker = new RapidSpellAsYouType();
            // Optionally, add a custom or user dictionary
            // spellChecker.AddDictionary(new UserDictionary("path/to/custom/dictionary"));

            // Spell check the content
            bool hasErrors = false;
            foreach (string word in content.Split(new[] { ' ', '\n', '\r', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!spellChecker.IsSpelledCorrectly(word))
                {
                    hasErrors = true;
                    Console.WriteLine($"Spelling error: {word}");
                }
            }

            if (!hasErrors)
            {
                Console.WriteLine("No spelling errors found.");
            }

            Console.WriteLine("Spell checking complete.");
        }
    }
}
