using UnusualSpending.Domain;
using UnusualSpending.Interfaces;

namespace UnusualSpending;

public class SpendingVerifier : ISpendingVerifier
{
    private readonly ITime _time;

    public int Prop { get; set; }

    private const double AlertThreshold = 0.5;
    public SpendingVerifier(ITime time) => _time = time;

    public IList<SpendingReport> DetectUnusualSpendings(IEnumerable<Spending> spendings)
    {
        return CreateGroupedSpendingReports(spendings)
            .Where(reports => reports.Count() == 2 && ThresholdExceeded(reports.Last(), reports.First()))
            .Select(reports => reports.Last())
            .ToList();
    }

    private IEnumerable<IGrouping<Category, SpendingReport>> CreateGroupedSpendingReports(
        IEnumerable<Spending> spendings)
    {
        return spendings
            .Where(InPeriod)
            .GroupBy(
                s => new { s.Date.Month, s.Payment.Category },
                s => s.Payment.Price,
                (s, prices) => new SpendingReport(s.Month, s.Category, prices.Sum()))
            .GroupBy(s => s.Category);
    }

    private bool ThresholdExceeded(SpendingReport currentMonth, SpendingReport previousMonth) => currentMonth.Sum >=
        previousMonth.Sum *
        (1 + AlertThreshold);

    private bool InPeriod(Spending s) => CurrentMonth(s) || PreviousMonth(s);

    private bool PreviousMonth(Spending s) => s.Date.Month == _time.GetTime().AddMonths(-1).Month &&
        s.Date.Year == _time.GetTime().AddMonths(-1).Year;

    private bool CurrentMonth(Spending s) => s.Date.Month == _time.GetTime().Month &&
        s.Date.Year == _time.GetTime().Year;
}

public record SpendingReport(int Month, Category Category, double Sum);