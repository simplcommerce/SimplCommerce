using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.Core.Data;

namespace SimplCommerce.Module.SampleData.Data
{
    public class SqlRepository : ISqlRepository
    {
        private readonly DbContext _dbContext;

        public SqlRepository(SimplDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RunCommand(string command)
        {
            _dbContext.Database.ExecuteSqlCommand(command);
        }

        public void RunCommands(IEnumerable<string> commands)
        {
            foreach (var command in commands)
            {
                _dbContext.Database.ExecuteSqlCommand(command);
            }
        }

        public IEnumerable<string> ParseCommand(IEnumerable<string> lines)
        {
            var sb = new StringBuilder();
            var commands = new List<string>();
            foreach (var line in lines)
            {
                if (string.Equals(line, "GO", StringComparison.OrdinalIgnoreCase))
                {
                    if (sb.Length > 0)
                    {
                        commands.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        sb.Append(line);
                    }
                }
            }

            return commands;
        }

        public IEnumerable<string> PostgresCommands(IEnumerable<string> lines)
        {
            var commands = new List<string>();
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    commands.Add(line);
                }
            }

            return commands;
        }

        public string GetDbConnectionType()
        {
            var dbConntionType = _dbContext.Database.GetDbConnection().GetType();
            return dbConntionType.ToString();
        }
    }
}