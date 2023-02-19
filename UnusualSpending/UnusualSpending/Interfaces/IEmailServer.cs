using UnusualSpending.Domain;

namespace UnusualSpending.Interfaces;

public interface IEmailServer
{
    void Send(Email email, string user);
}