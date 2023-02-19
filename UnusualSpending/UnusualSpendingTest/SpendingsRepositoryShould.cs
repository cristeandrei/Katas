namespace UnusualSpendingTest;

[TestClass()]
public class SpendingsRepositoryShould : UnusualSpendingData
{
    private readonly ITime _time;
    public SpendingsRepositoryShould()
    {
        _time = Substitute.For<ITime>();
    }

    [TestMethod()]
    public void AddOneSpending()
    {
        var spendings = new SpendingsRepository(_time);

        _time.GetTime().Returns(PreviousMonth);

        spendings.AddSpending(APayment, User);

        Assert.AreEqual(1, spendings.Count);
    }

    [TestMethod]
    public void ProvideUnusualSpendings()
    {
        var spendings = new SpendingsRepository(_time);


        foreach (var spending in AllSpendingFromMultipleUsers)
        {
            _time.GetTime().Returns(spending.Date);
            spendings.AddSpending(spending.Payment, spending.UserId);
        }

        var result = spendings.SpendingsForUserWithId(User);

        Assert.IsTrue(result.SequenceEqual(AllSpendingFromOneUser));
    }
}