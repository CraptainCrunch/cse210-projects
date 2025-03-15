using System;

class SimpleGoal : Goal{
    public SimpleGoal(string goalName, int goalPoints) : base(goalName, goalPoints) { }

    public override int RecordProgress(){
        if (!isCompleted){
            isCompleted = true;
            return points;
        }
        return 0;
    }

    public override string DisplayProgress(){
        return isCompleted ? "[X] " + name : "[ ] " + name;
    }
}