using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Clients
{
    public sealed class ClientCompany : ValueObject
    {
        private ClientCompany()
        {
        }

        private ClientCompany(string employeeNumber, string name)
        {
            EmployeeNumber = employeeNumber;
            Name = name;
        }

        private string EmployeeNumber { get; }
        private string Name { get; }

        public static ClientCompany Of(string employeeNumber, string name)
        {
            return new (employeeNumber, name);
        }
    }
}
