using System;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, MindfulnessActivity> activities = new()
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() }
        };
        
        while (true)
        {
            Console.WriteLine("\nMindfulness Activities:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();
            
            if (choice == "4")
                break;
            else if (activities.ContainsKey(choice))
                activities[choice].StartActivity();
            else
                Console.WriteLine("You have entered an invalid response. Please enter a number 1-4.");
        }
    }
}