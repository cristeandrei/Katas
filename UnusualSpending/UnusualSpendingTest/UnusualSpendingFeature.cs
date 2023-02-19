namespace UnusualSpendingTest;

[TestClass()]
public class UnusualSpendingFeature : UnusualSpendingData
{
    private readonly ITime _time;
    private readonly IEmailServer _emailServer;

    public UnusualSpendingFeature()
    {
        _time = Substitute.For<ITime>();
        _emailServer = Substitute.For<IEmailServer>();
    }

    [TestMethod()]
    public void SendEmailWithUnusualSpending()
    {
        var sut = new SpendingManager(new SpendingsRepository(_time),
            new UnusualSpendingEmailComposer(),
            new SpendingVerifier(_time), _emailServer);

        foreach (var spending in AllSpendingFromOneUser)
        {
            _time.GetTime().Returns(spending.Date);
            sut.RegisterSpending(spending.Payment, User);
        }

        sut.VerifyUnusualSpendings(User);

        _emailServer.Received().Send(ExpectedEmail, User);
    }
}