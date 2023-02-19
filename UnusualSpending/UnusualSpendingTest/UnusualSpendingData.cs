[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]


namespace UnusualSpendingTest;
public class UnusualSpendingData
{
    protected const string User = "user";
    protected const string OtherUser = "other_user";
    protected static readonly DateTime PreviousMonth = new(2022, 8, 1);
    protected static readonly DateTime CurrentMonth = new(2022, 9, 1);

    protected readonly IList<Spending> AllSpendingFromOneUser = new Spending[] {new(new Payment(20, "", Category.Groceries), User,PreviousMonth),
        new(new Payment(30, "", Category.Groceries), User,PreviousMonth),
        new(new Payment(100, "", Category.Travel), User,PreviousMonth),
        new(new Payment(300, "", Category.Travel), User,PreviousMonth),
        new(new Payment(105, "", Category.Groceries), User, CurrentMonth),
        new(new Payment(43, "", Category.Groceries), User, CurrentMonth),
        new(new Payment(327, "", Category.Travel), User, CurrentMonth),
        new(new Payment(300, "", Category.Travel), User, CurrentMonth),
        new(new Payment(275, "", Category.Travel), User, CurrentMonth),
        new(new Payment(353, "", Category.Travel), User, CurrentMonth) };

    protected IList<Spending> UnusualSpendingFromOneUser = new Spending[] { new(new Payment(105, "", Category.Groceries), User, CurrentMonth),
        new(new Payment(43, "", Category.Groceries), User, CurrentMonth),
        new(new Payment(327, "", Category.Travel), User, CurrentMonth),
        new(new Payment(300, "", Category.Travel), User, CurrentMonth),
        new(new Payment(275, "", Category.Travel), User, CurrentMonth),
        new(new Payment(353, "", Category.Travel), User, CurrentMonth)};

    protected readonly IList<Spending> AllSpendingFromMultipleUsers = new Spending[] {new(new Payment(20, "", Category.Groceries), User,PreviousMonth),
        new(new Payment(30, "", Category.Groceries), User,PreviousMonth),
        new(new Payment(30, "", Category.Groceries), OtherUser,PreviousMonth),
        new(new Payment(100, "", Category.Travel), User,PreviousMonth),
        new(new Payment(300, "", Category.Travel), User,PreviousMonth),
        new(new Payment(105, "", Category.Groceries), OtherUser, CurrentMonth),
        new(new Payment(105, "", Category.Groceries), User, CurrentMonth),
        new(new Payment(43, "", Category.Groceries), User, CurrentMonth),
        new(new Payment(327, "", Category.Travel), User, CurrentMonth),
        new(new Payment(300, "", Category.Travel), User, CurrentMonth),
        new(new Payment(300, "", Category.Travel), OtherUser, CurrentMonth),
        new(new Payment(275, "", Category.Travel), User, CurrentMonth),
        new(new Payment(353, "", Category.Travel), OtherUser, CurrentMonth),
        new(new Payment(353, "", Category.Travel), User, CurrentMonth) };

    protected readonly Payment APayment = new(10, "", Category.Entertainment);

    protected readonly IList<SpendingReport> UnusualSpendingReport = new SpendingReport[] {
        new(9,Category.Groceries,148),
        new(9,Category.Travel,1255),
    };

    private const double UnusualSpendingTotal = 1403;

    protected Email ExpectedEmail
    {
        get
        {
            var email = new Email
            {
                Subject = $"Unusual spending of ${UnusualSpendingTotal} detected!"
            };
            email.AddLine("Hello card user!");
            email.AddLine("We have detected unusually high spending on your card in these categories:");
            foreach (var spendingReport in UnusualSpendingReport)
            {
                email.AddLine($"* You spent ${spendingReport.Sum} on {spendingReport.Category.ToText()}");
            }
            email.AddLine("Love,The Credit Card Company");
            return email;
        }
    }
}
