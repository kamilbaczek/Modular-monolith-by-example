namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay.Dtos.CreditCard;

public record CreditCardDto(string CardNumber,
    int ExpYear,
    int ExpMonth,
    string Cvc);
