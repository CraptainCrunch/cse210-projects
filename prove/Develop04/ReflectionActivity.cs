class ReflectionActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private static readonly List<string> Questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on moments of strength and resilience. This will help you recognize the power that you have and how you can use it in other aspects of your life.") { }

    protected override void RunActivity()
    {
        Random random = new();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        Animate(3);
        for (int i = 0; i < Duration / 10; i++)
        {
            Console.WriteLine(Questions[random.Next(Questions.Count)]);
            Animate(10);
        }
    }
}