using UnusualSpending.Domain;

namespace UnusualSpending.Interfaces;

public interface ISpendingsRepository
{
    void AddSpending(Payment payment, string userId);
    IList<Spending> SpendingsForUserWithId(string id);
    int Count { get; }
}