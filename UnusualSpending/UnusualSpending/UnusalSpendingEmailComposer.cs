using UnusualSpending.Domain;
using UnusualSpending.Interfaces;

namespace UnusualSpending;

public class UnusualSpendingEmailComposer : IUnusualSpendingEmailComposer
{
    public Email Compose(IList<SpendingReport> spendings)
    {
        var email = new Email
        {
            Subject = Subject(GetTotalSum(spendings))
        };
        email.AddLine(Greetings);
        email.AddLine(Content);
        foreach (var spendingReport in spendings)
            email.AddLine(Spending(spendingReport.Sum, spendingReport.Category));
        email.AddLine(Farewell);

        return email;
    }

    private double GetTotalSum(IEnumerable<SpendingReport> spendings) => spendings.Select(s => s.Sum).Sum();
    private string Subject(double value) => $"Unusual spending of ${value} detected!";
    private string Greetings => "Hello card user!";
    private string Content => "We have detected unusually high spending on your card in these categories:";
    private string Spending(double value, Category category) => $"* You spent ${value} on {category.ToText()}";
    private string Farewell => "Love,The Credit Card Company";
}
