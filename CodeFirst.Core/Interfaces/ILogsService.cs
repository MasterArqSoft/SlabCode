using System;

namespace CodeFirst.Core.Interfaces
{
    public interface ILogsService
    {
        void Save(string url, Exception ex);
    }
}