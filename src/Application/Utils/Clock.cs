using Core.Shared;

namespace Application.Utils;

public class Clock : IClock
{
    public DateTime Current()
    {
        return DateTime.Now;
    }
}