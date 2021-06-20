﻿using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests
{
    using static ValuationsTesting;

    public abstract class ValuationsTestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
