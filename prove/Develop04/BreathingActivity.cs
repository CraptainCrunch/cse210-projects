class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    protected override void RunActivity()
    {
        for (int i = 0; i < Duration / 6; i++)
        {
            Console.WriteLine("Breathe in...");
            Animate(5);
            Console.WriteLine("Breathe out...");
            Animate(5);
        }
    }
}