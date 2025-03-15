using System;

class Program{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(){
        LoadGoals();
        while (true){
            Console.Clear();
            Console.WriteLine("Eternal Quest - Goal Tracker");
            Console.WriteLine("1. Create Goal\n2. Record Progress\n3. View Goals\n4. View Score\n5. Save and Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice){
                case "1": CreateGoal(); break;
                case "2": RecordProgress(); break;
                case "3": ViewGoals(); break;
                case "4": Console.WriteLine($"Your score: {score}"); Console.ReadKey(); break;
                case "5": SaveGoals(); return;
            }
        }
    }

    static void CreateGoal(){
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());
        Console.WriteLine("Select Goal Type:\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
        string type = Console.ReadLine();

        switch (type){
            case "1": goals.Add(new SimpleGoal(name, points)); break;
            case "2": goals.Add(new EternalGoal(name, points)); break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
        }
    }

    static void RecordProgress(){
        ViewGoals();
        Console.Write("Select a goal to record progress: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count){
            score += goals[index].RecordProgress();
            Console.WriteLine("Progress recorded!");
        }
        Console.ReadKey();
    }

    static void ViewGoals(){
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < goals.Count; i++){
            Console.WriteLine($"{i + 1}. {goals[i].DisplayProgress()}");
        }
        Console.ReadKey();
    }

    static void SaveGoals(){
        using (StreamWriter file = new StreamWriter("goals.txt")){
            file.WriteLine(score);
            foreach (var goal in goals){
                file.WriteLine($"{goal.GetType().Name}|{goal.DisplayProgress()}|{goal.RecordProgress()}");
            }
        }
    }

    static void LoadGoals(){
        if (File.Exists("goals.txt")){
            string[] lines = File.ReadAllLines("goals.txt");
            score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++){
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];
                int points = int.Parse(parts[2]);

                if (type == "SimpleGoal")
                    goals.Add(new SimpleGoal(name, points));
                else if (type == "EternalGoal")
                    goals.Add(new EternalGoal(name, points));
                else if (type == "ChecklistGoal")
                    goals.Add(new ChecklistGoal(name, points, int.Parse(parts[4]), int.Parse(parts[5])));
            }
        }
    }
}