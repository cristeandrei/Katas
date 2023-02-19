// See https://aka.ms/new-console-template for more information

namespace UnusualSpending.Domain;

public record Spending(Payment Payment, string UserId, DateTime Date);