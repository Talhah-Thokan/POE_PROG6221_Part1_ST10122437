using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Play audio using afplay (macOS only)
        var psi = new ProcessStartInfo
        {
            FileName = "afplay",
            Arguments = "assets/greeting.wav",
            RedirectStandardOutput = false,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        try
        {
            Process.Start(psi)?.WaitForExit();
        }
        catch
        {
            Console.WriteLine("Bot: Could not play audio. Please ensure 'greeting.wav' exists and 'afplay' is available.");
        }

        // ASCII Art Header
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
 _____       _                         _     _              
| ____|_ __ | |_ ___ _ __ _   _  ___  | |__ (_)_ __   __ _  
|  _| | '_ \| __/ _ \ '__| | | |/ _ \ | '_ \| | '_ \ / _` | 
| |___| | | | ||  __/ |  | |_| |  __/ | | | | | | | | (_| | 
|_____|_| |_|\__\___|_|   \__, |\___| |_| |_|_|_| |_|\__, | 
                         |___/                        |___/ 
");
        Console.ResetColor();

        Console.Write("Bot: What's your name? ");
        string name = Console.ReadLine();
        Console.WriteLine($"Bot: Welcome, {name}! I'm your Cybersecurity Awareness Bot.");

        while (true)
        {
            Console.Write("\nYou: ");
            string input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Bot: Please type something.");
                continue;
            }

            if (input.Contains("how are you"))
                Console.WriteLine("Bot: I'm ready to help you stay safe online!");
            else if (input.Contains("purpose"))
                Console.WriteLine("Bot: I'm here to spread cybersecurity awareness.");
            else if (input.Contains("password"))
                Console.WriteLine("Bot: Use a strong, unique password and never reuse them.");
            else if (input.Contains("phishing"))
                Console.WriteLine("Bot: Phishing is when attackers trick you into giving up info. Don’t click suspicious links.");
            else if (input.Contains("safe browsing"))
                Console.WriteLine("Bot: Keep your browser updated and don’t visit untrusted websites.");
            else if (input == "exit")
            {
                Console.WriteLine("Bot: Goodbye, stay safe!");
                break;
            }
            else
                Console.WriteLine("Bot: I didn’t quite understand that. Could you rephrase?");
        }
    }
}