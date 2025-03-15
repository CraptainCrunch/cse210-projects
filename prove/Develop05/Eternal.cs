using System;

class EternalGoal : Goal{
    public EternalGoal(string goalName, int goalPoints) : base(goalName, goalPoints) { }

    public override int RecordProgress(){
        return points;
    }

    public override string DisplayProgress(){
        return "[∞] " + name;
    }
}