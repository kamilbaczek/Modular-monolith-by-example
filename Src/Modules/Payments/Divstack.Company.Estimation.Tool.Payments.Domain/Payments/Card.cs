namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public sealed class Card : ValueObject
{
    private Card(string number, int expMonth, int expYear, string cvc)
    {
        Number = number;
        ExpMonth = expMonth;
        ExpYear = expYear;
        Cvc = cvc;
    }

    public string Number { get; }
    public int ExpMonth { get; }
    public int ExpYear { get; }
    public string Cvc { get; }

    public static Card New(string number, int expMonth, int expYear, string cvc)
    {
        return new Card(number, expMonth, expYear, cvc);
    }
}
