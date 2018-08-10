using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.SampleData.Data;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.SampleData.ViewModels;

namespace SimplCommerce.Module.SampleData.Services
{
    public class SampleDataService : ISampleDataService
    {
        private readonly ISqlRepository _sqlRepository;
        private readonly IMediaService _mediaService;

        public SampleDataService(ISqlRepository sqlRepository, IMediaService mediaService)
        {
            _sqlRepository = sqlRepository;
            _mediaService = mediaService;
        }

        public async Task ResetToSampleData(SampleDataOption model)
        {
            var usePostgres = _sqlRepository.GetDbConnectionType() == "Npgsql.NpgsqlConnection";
            var sampleContentFolder = Path.Combine(GlobalConfiguration.ContentRootPath, "Modules", "SimplCommerce.Module.SampleData", "SampleContent", model.Industry);

            var filePath = usePostgres ? Path.Combine(sampleContentFolder, "ResetToSampleData_Postgres.sql") : Path.Combine(sampleContentFolder, "ResetToSampleData.sql");
            var lines = File.ReadLines(filePath);
            var commands = usePostgres ? _sqlRepository.PostgresCommands(lines) : _sqlRepository.ParseCommand(lines);
            _sqlRepository.RunCommands(commands);

           await CopyImages(sampleContentFolder);
        }

        private async Task CopyImages(string sampleContentFolder)
        {
            var imageFolder = Path.Combine(sampleContentFolder, "Images");
            IEnumerable<string> files = Directory.GetFiles(imageFolder);
            foreach (var file in files)
            {
                using (var stream = File.Open(file, FileMode.Open, FileAccess.Read))
                {
                    await _mediaService.SaveMediaAsync(stream, Path.GetFileName(file));
                }
            }
        }
    }
}