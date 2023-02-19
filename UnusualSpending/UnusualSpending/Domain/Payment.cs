// See https://aka.ms/new-console-template for more information

namespace UnusualSpending.Domain;

public record Payment(double Price, string Description, Category Category);