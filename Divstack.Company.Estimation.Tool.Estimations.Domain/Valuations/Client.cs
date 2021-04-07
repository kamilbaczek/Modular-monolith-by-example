using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations
{
    public class Client : ValueObject
    {
        private Client(Email email, string firstName, string lastName)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public static Client Of(Email email, string firstName, string lastName)
        {
            return new (email, firstName, lastName);
        }

        internal Email Email { get;  }
        private string FirstName { get;  }
        private string LastName { get;  }
    };
}
