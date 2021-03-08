using System;

namespace Dapr.CleanArchitecture.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
