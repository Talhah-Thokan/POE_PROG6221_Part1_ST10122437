using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        PlayGreetingAudio(); //Plays the greeting audio

        ShowHeader(); // Displays the header with ASCII art and title
        DisplayWelcomeMessage(); // Displays the welcome message

        Console.Write("🤖 Bot: Let's start with your name: ");
        string? userInput = Console.ReadLine();// Gets the user's name
        string name = userInput ?? "Guest"; // Use null-coalescing operator to provide default
        Console.WriteLine($"🤖 Bot: Great to meet you, {name}! 💡");

        ShowIntro();// Displays the introduction message

        while (true)// Main chat loop
        {
            Console.ForegroundColor = ConsoleColor.Green; // Sets the color for user input
            Console.Write("\nYou: ");
            Console.ResetColor();

            string? inputText = Console.ReadLine()?.ToLower()?.Trim();// Reads user input and normalizes it
            string input = inputText ?? ""; // Use null-coalescing to handle null

            if (string.IsNullOrWhiteSpace(input))// Checks if input is empty or whitespace
            {
                Console.WriteLine("🤖 Bot: Please type something so I can help.");
                continue;
            }

            if (input == "exit" || input == "quit") // Checks for exit commands
            {
                Console.WriteLine("🤖 Bot: Thanks for chatting! Stay safe online! 👋");
                break;
            }

            if (input == "help")
            {
                ShowHelp();
                continue;
            }

            RespondToUser(input);// Responds to user input based on keywords
        }
    }

    static void PlayGreetingAudio()// Plays the greeting audio file
    {
        if (!System.IO.File.Exists("assets/greeting.wav"))// Checks if the audio file exists
        {
            Console.WriteLine("⚠️  Bot: Audio greeting file not found. Please ensure 'greeting.wav' exists in the 'assets' folder.");
            return;
        }
        
        try 
        {
            ProcessStartInfo psi;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Windows - using PowerShell to play audio
                psi = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"-c (New-Object System.Media.SoundPlayer '{System.IO.Path.GetFullPath("assets/greeting.wav")}').PlaySync()",
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Linux
                psi = new ProcessStartInfo
                {
                    FileName = "aplay",
                    Arguments = "assets/greeting.wav",
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // macOS
                psi = new ProcessStartInfo
                {
                    FileName = "afplay",
                    Arguments = "assets/greeting.wav",
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
            }
            else
            {
                Console.WriteLine("⚠️  Bot: Audio greeting is not supported on this platform.");
                return;
            }

            Process.Start(psi)?.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️  Bot: Audio greeting could not be played. {ex.Message}");
        }
    }

    static void ShowHeader() // Displays the header with ASCII art and title
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
   ___      _                ___       _   
  / __\   _| |__   ___ _ __ / __\ ___ | |_ 
 / / | | | | '_ \ / _ \ '__/__\/// _ \| __|
/ /__| |_| | |_) |  __/ | / \/  \ (_) | |_ 
\____/\__, |_.__/ \___|_| \_____/\___/ \__|
      |___/                                

            👾 THINKINBOT CYBER 👾
        ");
        Console.ResetColor();
    }

    static void DisplayWelcomeMessage() // Displays the welcome message
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("👋 Welcome to ThinkinBot Cyber – Your AI Security Ally!");
        Console.WriteLine("--------------------------------------------------");
    }

    static void ShowIntro() // Displays the introduction message
    {
        Console.WriteLine("\n🤖 Bot: I'm here to help you learn and stay safe in the digital world.");
        Console.WriteLine("🔍 Ask me about topics like:");
        Console.WriteLine("   • Password security");
        Console.WriteLine("   • Phishing scams");
        Console.WriteLine("   • Safe browsing habits");
        Console.WriteLine("   • Social engineering");
        Console.WriteLine("   • And more!");
        Console.WriteLine("💬 You can type 'help' anytime to see all supported commands.");
        Console.WriteLine("🚪 Type 'exit' to leave the session.");
    }

    static void ShowHelp() // Displays the help menu with available commands
    {
        Console.WriteLine("\n📘 Bot Help Menu:");
        Console.WriteLine("Here are some things you can ask me:");
        Console.WriteLine(" - How are you?");
        Console.WriteLine(" - What's your purpose?");
        Console.WriteLine(" - Tell me about passwords");
        Console.WriteLine(" - What is phishing?");
        Console.WriteLine(" - Explain safe browsing");
        Console.WriteLine(" - What's social engineering?");
        Console.WriteLine(" - exit / quit");
    }

    static void RespondToUser(string input)// Responds to user input based on keywords
    {
        if (input.Contains("how are you"))
            Console.WriteLine("🤖 Bot: I'm excellent! Always ready to boost your cyber knowledge. 💥");
        else if (input.Contains("purpose") || input.Contains("what can you do"))
            Console.WriteLine("🤖 Bot: I was designed to spread awareness and educate people on staying secure online.");
        else if (input.Contains("password"))
            Console.WriteLine("🔐 Bot: Always use long, unique passwords for every account. Consider a password manager to help manage them.");
        else if (input.Contains("phishing"))
            Console.WriteLine("🎣 Bot: Phishing tricks you into giving personal info. Double-check URLs, never click suspicious links, and verify senders.");
        else if (input.Contains("safe browsing"))
            Console.WriteLine("🌍 Bot: Stay safe online by updating your browser, using HTTPS websites, and avoiding shady downloads.");
        else if (input.Contains("social engineering"))
            Console.WriteLine("🧠 Bot: Social engineering uses manipulation to access your data. Be cautious of unsolicited messages or calls.");
        else if (input.Contains("malware"))
            Console.WriteLine("💣 Bot: Malware is malicious software designed to harm your device. Use antivirus, update systems, and don't open unknown files.");
        else if (input.Contains("vpn"))
            Console.WriteLine("🛡️ Bot: A VPN encrypts your internet connection for privacy. Great for public Wi-Fi use!");
        else if (input.Contains("2fa") || input.Contains("two factor"))
            Console.WriteLine("🔑 Bot: Two-Factor Authentication adds a layer of security. Even if your password leaks, your account stays safer.");
        else
            Console.WriteLine("🤖 Bot: Hmm... I didn't get that. Try asking about 'passwords', 'phishing', 'VPN', or type 'help'.");
    }
}
