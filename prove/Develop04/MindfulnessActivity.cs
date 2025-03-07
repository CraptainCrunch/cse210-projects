class MindfulnessActivity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"\nStarting {Name}...");
        Console.WriteLine(Description);
        Console.Write("Enter the duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        Animate(3);
        RunActivity();
        EndActivity();
    }

    protected void Animate(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}...\r");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected virtual void RunActivity() { }

    protected void EndActivity()
    {
        Console.WriteLine("Awesome!");
        Console.WriteLine($"You completed the {Name} activity for {Duration} seconds.");
        Animate(3);
    }
}