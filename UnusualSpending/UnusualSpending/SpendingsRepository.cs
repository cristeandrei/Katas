using UnusualSpending.Domain;
using UnusualSpending.Interfaces;

namespace UnusualSpending;

public class SpendingsRepository : ISpendingsRepository
{
    private readonly IList<Spending> _spendings = new List<Spending>();
    private readonly ITime _time;

    public SpendingsRepository(ITime time)
    {
        _time = time;
    }

    public void AddSpending(Payment payment, string userId)
    {
        _spendings.Add(new Spending(payment, userId, _time.GetTime()));
    }

    public IList<Spending> SpendingsForUserWithId(string id)
    {
        return _spendings.Where(s => s.UserId.Equals(id)).ToList();
    }

    public int Count => _spendings.Count;
}