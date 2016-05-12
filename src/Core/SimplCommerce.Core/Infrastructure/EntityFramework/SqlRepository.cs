using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Reflection;
using System.Text;

namespace SimplCommerce.Core.Infrastructure.EntityFramework
{
    public class SqlRepository : ISqlRepository
    {
        private readonly DbContext dbContext;

        public SqlRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void RunCommand(string command)
        {
            dbContext.Database.ExecuteSqlCommand(command);
        }

        public void RunCommands(IEnumerable<string> commands)
        {
            foreach (var command in commands)
            {
                dbContext.Database.ExecuteSqlCommand(command);
            }
        }

        public void CreateInitData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SimplCommerce.Core.Infrastructure.EntityFramework.Seed.sql";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                IList<string> lines = new List<string>();

                do
                {
                    var line = reader.ReadLine();
                    lines.Add(line);
                }
                while (!reader.EndOfStream);

                var commands = ParseCommand(lines);
                RunCommands(commands);
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
    }
}