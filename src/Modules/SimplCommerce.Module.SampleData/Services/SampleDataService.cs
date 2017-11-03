using System.Collections.Generic;
using System.IO;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.SampleData.Data;

namespace SimplCommerce.Module.SampleData.Services
{
    public class SampleDataService : ISampleDataService
    {
        private readonly ISqlRepository _sqlRepository;

        public SampleDataService(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public void ResetToSampleData()
        {
            var usePostgres = _sqlRepository.GetDbConnectionType() == "Npgsql.NpgsqlConnection";
            var sampleContentFolder = Path.Combine(GlobalConfiguration.ContentRootPath, "Modules", "SimplCommerce.Module.SampleData", "SampleContent");

            var filePath = usePostgres ? Path.Combine(sampleContentFolder, "ResetToSampleData_Postgres.sql") : Path.Combine(sampleContentFolder, "ResetToSampleData.sql");
            var lines = File.ReadLines(filePath);
            var commands = usePostgres ? _sqlRepository.PostgresCommands(lines) : _sqlRepository.ParseCommand(lines);
            _sqlRepository.RunCommands(commands);

            CopyImages(sampleContentFolder);
        }

        private static void CopyImages(string sampleContentFolder)
        {
            var imageFolder = Path.Combine(sampleContentFolder, "Images");
            var destDir = Path.Combine(GlobalConfiguration.WebRootPath, "user-content");
            IEnumerable<string> files = Directory.GetFiles(imageFolder);
            foreach (var file in files)
            {
                var destFileName = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFileName, true);
            }
        }
    }
}