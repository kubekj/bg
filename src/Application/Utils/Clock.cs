using Core.Shared;

namespace Application.Utils;

public class Clock : IClock
{
    public DateTime Current() => DateTime.Now;
}