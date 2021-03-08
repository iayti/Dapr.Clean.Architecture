using System;
using Dapr.CleanArchitecture.Application.Common.Interfaces;

namespace Dapr.CleanArchitecture.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
