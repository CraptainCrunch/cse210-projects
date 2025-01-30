using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string date, string prompt, string response) => (Date, Prompt, Response) = (date, prompt, response);

    public override string ToString() => $"{Date} | {Prompt} | {Response}";
}

class Journal
{
    private List<Entry> entries = new();
    private static List<string> prompts = new()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn today?"
    };

    public void AddEntry()
    {
        string prompt = prompts[new Random().Next(prompts.Count)];
        Console.WriteLine(prompt);
        entries.Add(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, Console.ReadLine()));
    }

    public void DisplayEntries() => entries.ForEach(Console.WriteLine);

    public void SaveToFile(string filename) => File.WriteAllLines(filename, entries.ConvertAll(e => e.ToString()));

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename)) { Console.WriteLine("File not found."); return; }
        entries = new List<Entry>(Array.ConvertAll(File.ReadAllLines(filename), line => {
            var parts = line.Split('|');
            return parts.Length == 3 ? new Entry(parts[0].Trim(), parts[1].Trim(), parts[2].Trim()) : null;
        }));
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new();
        while (true)
        {
            Console.WriteLine("1. Write a new entry\n2. Display the journal\n3. Save journal to file\n4. Load journal from file\n5. Exit");
            switch (Console.ReadLine())
            {
                case "1": journal.AddEntry(); break;
                case "2": journal.DisplayEntries(); break;
                case "3": Console.Write("Enter filename: "); journal.SaveToFile(Console.ReadLine()); break;
                case "4": Console.Write("Enter filename: "); journal.LoadFromFile(Console.ReadLine()); break;
                case "5": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }
}
