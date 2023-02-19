namespace UnusualSpendingTest;

[TestClass()]
public class UnusualSpendingEmailComposerShould : UnusualSpendingData
{

    [TestMethod()]
    public void ComposeEmailWithSubjectIntroductionListOfSpendingAndFarewell()
    {
        var emailComposer =
            new UnusualSpendingEmailComposer();

        var result = emailComposer.Compose(UnusualSpendingReport);

        Assert.AreEqual(ExpectedEmail, result);
    }
}