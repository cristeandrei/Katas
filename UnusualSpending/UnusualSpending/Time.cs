using UnusualSpending.Interfaces;

namespace UnusualSpending;

public class Time : ITime
{
    public DateTime GetTime() => DateTime.Now;
}