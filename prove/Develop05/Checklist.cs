using System;

class ChecklistGoal : Goal{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string goalName, int goalPoints, int goalTargetCount, int goalBonusPoints)
        : base(goalName, goalPoints){
        targetCount = goalTargetCount;
        currentCount = 0;
        bonusPoints = goalBonusPoints;
    }

    public override int RecordProgress(){
        if (!isCompleted){
            currentCount++;
            if (currentCount >= targetCount){
                isCompleted = true;
                return points + bonusPoints;
            }
            return points;
        }
        return 0;
    }

    public override string DisplayProgress(){
        return (isCompleted ? "[X] " : "[ ] ") + name + $" (Completed {currentCount}/{targetCount})";
    }
}