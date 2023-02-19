using UnusualSpending.Domain;
using UnusualSpending.Interfaces;

namespace UnusualSpending;

public class EmailServer : IEmailServer
{
    public void Send(Email email, string user)
    {
        Console.WriteLine(email.Subject);
        Console.WriteLine(email.Content);
    }
}