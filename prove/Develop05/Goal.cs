using System;

abstract class Goal{
    protected string name;
    protected int points;
    protected bool isCompleted;

    public Goal(string goalName, int goalPoints){
        name = goalName;
        points = goalPoints;
        isCompleted = false;
    }

    public abstract int RecordProgress();
    public abstract string DisplayProgress();
}