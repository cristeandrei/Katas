using UnusualSpending.Domain;

namespace UnusualSpending.Interfaces;

public interface IUnusualSpendingEmailComposer
{
    Email Compose(IList<SpendingReport> spendings);
}