﻿#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Clients;

public sealed class ClientCompany : ValueObject
{
    private ClientCompany()
    {
    }

    private ClientCompany(string size, string name)
    {
        Size = size;
        Name = name;
    }

    private string Size { get; }
    private string Name { get; }

    public static ClientCompany Of(string size, string name)
    {
        return new ClientCompany(size, name);
    }
}
