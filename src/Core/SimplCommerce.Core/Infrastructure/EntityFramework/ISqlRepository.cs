using System.Collections.Generic;

namespace SimplCommerce.Core.Infrastructure.EntityFramework
{
    public interface ISqlRepository
    {
        void RunCommand(string command);

        void RunCommands(IEnumerable<string> command);

        IEnumerable<string> ParseCommand(IEnumerable<string> lines);
    }
}