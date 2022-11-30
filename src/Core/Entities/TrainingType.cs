using Core.Enums;

namespace Core.Entities;

public class TrainingType
{
    public TypeOfTraining TypeOfTraining { get; private set; }
    public byte[] Image { get; private set; }
}