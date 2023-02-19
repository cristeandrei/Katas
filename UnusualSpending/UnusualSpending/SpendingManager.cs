using UnusualSpending.Domain;
using UnusualSpending.Interfaces;

namespace UnusualSpending;
public class SpendingManager
{
    private readonly ISpendingsRepository _spendings;
    private readonly IUnusualSpendingEmailComposer _emailComposer;
    private readonly ISpendingVerifier _verifier;
    private readonly IEmailServer _server;

    public SpendingManager(ISpendingsRepository spendings, IUnusualSpendingEmailComposer emailComposer, ISpendingVerifier verifier, IEmailServer server)
    {
        _spendings = spendings;
        _emailComposer = emailComposer;
        _verifier = verifier;
        _server = server;
    }

    public void RegisterSpending(Payment payment, string userId)
    =>
        _spendings.AddSpending(payment, userId);


    public void VerifyUnusualSpendings(string userId)
    {
        var spendings = _spendings.SpendingsForUserWithId(userId);
        if (spendings.Count is 0) return;

        var unusualSpendings = _verifier.DetectUnusualSpendings(spendings);

        if (unusualSpendings.Count is 0) return;

        var email = _emailComposer.Compose(unusualSpendings);

        _server.Send(email, userId);
    }
}
