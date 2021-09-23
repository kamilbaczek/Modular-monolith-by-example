using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Clients
{
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
}