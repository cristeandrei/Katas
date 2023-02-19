// See https://aka.ms/new-console-template for more information

namespace UnusualSpending.Domain;

public enum Category
{
    Entertainment,
    Groceries,
    Travel
}

public static class CategoryExtensionMethod
{
    public static string ToText(this Category category) => category.ToString().ToLower();

}