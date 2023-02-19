using UnusualSpending.Domain;

namespace UnusualSpending.Interfaces;

public interface ISpendingVerifier
{
    IList<SpendingReport> DetectUnusualSpendings(IEnumerable<Spending> spendings);
}