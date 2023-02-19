namespace UnusualSpendingTest;

[TestClass]
public class SpendingManagerShould : UnusualSpendingData
{
    private readonly IUnusualSpendingEmailComposer _emailComposer;
    private readonly IEmailServer _emailServer;
    private readonly ISpendingsRepository _spendings;
    private readonly ISpendingVerifier _verifier;

    public SpendingManagerShould()
    {
        _spendings = Substitute.For<ISpendingsRepository>();
        _emailComposer = Substitute.For<IUnusualSpendingEmailComposer>();
        _verifier = Substitute.For<ISpendingVerifier>();
        _emailServer = Substitute.For<IEmailServer>();
    }

    [TestMethod]
    public void BeCapableOfRegisteringSpendings()
    {
        var spendingManager = new SpendingManager(_spendings, _emailComposer, _verifier, _emailServer);

        spendingManager.RegisterSpending(APayment, User);

        _spendings.Received(1).AddSpending(Any<Payment>(), User);
    }

    [TestMethod]
    public void DoNothingIfThereAreNoUnusualSpendings()
    {
        var spendingManager = new SpendingManager(_spendings, _emailComposer, _verifier, _emailServer);

        spendingManager.VerifyUnusualSpendings(User);

        _spendings.Received().SpendingsForUserWithId(User);
    }

    [TestMethod]
    public void IfThereAreUnusualSpendingsSendAlertEmail()
    {
        _spendings.SpendingsForUserWithId(User).Returns(AllSpendingFromOneUser);
        _verifier.DetectUnusualSpendings(Any<IList<Spending>>()).Returns(UnusualSpendingReport);

        var spendingManager = new SpendingManager(_spendings, _emailComposer, _verifier, _emailServer);

        spendingManager.VerifyUnusualSpendings(User);

        Received.InOrder(() =>
        {
            _spendings.Received().SpendingsForUserWithId(User);
            _verifier.Received().DetectUnusualSpendings(Any<Spending[]>());
            _emailComposer.Received().Compose(Any<IList<SpendingReport>>());
            _emailServer.Received(1).Send(Any<Email>(), User);
        });
    }
}