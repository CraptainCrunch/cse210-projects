class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can based on the question.") { }

    protected override void RunActivity()
    {
        Random random = new();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        Animate(3);
        int count = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.Write("Please share a response: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items! That's so awesome!");
    }
}