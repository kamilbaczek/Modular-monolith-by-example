using System;

namespace Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}