namespace UnusualSpendingTest;

[TestClass()]
public class SpendingVerifierShould : UnusualSpendingData
{
    readonly ITime _time;

    public SpendingVerifierShould()
    {
        _time = Substitute.For<ITime>();
    }

    [TestMethod()]
    public void IfThereAreUnusualSpendingsGetThem()
    {
        _time.GetTime().Returns(CurrentMonth);

        var verifier = new SpendingVerifier(_time);

        var result = verifier.DetectUnusualSpendings(AllSpendingFromOneUser);

        Assert.IsTrue(result.SequenceEqual(UnusualSpendingReport));
    }
}