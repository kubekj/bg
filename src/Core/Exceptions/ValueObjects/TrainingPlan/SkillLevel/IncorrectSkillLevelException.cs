namespace Core.Exceptions.ValueObjects.TrainingPlan.SkillLevel;

public class IncorrectSkillLevelException : CoreException
{
    public IncorrectSkillLevelException(string value) : base("")
    {
        Value = value;
    }

    public string Value { get; }
}