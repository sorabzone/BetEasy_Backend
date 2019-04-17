using dotnet_code_challenge.Engine.Service;
using System.Threading.Tasks;
using System.Linq;
using dotnet_code_challange.RaceEngine.Interface;

namespace dotnet_code_challange.Engine
{
    public class RaceImportWorker
    {
        private readonly JsonEngine _jsonEngine;
        private readonly XmlEngine _xmlEngine;
        private readonly IOutputService _outputService;

        public RaceImportWorker(JsonEngine jsonEngine, XmlEngine xmlEngine, IOutputService outputService)
        {
            _jsonEngine = jsonEngine;
            _xmlEngine = xmlEngine;
            _outputService = outputService;
        }

        /// <summary>
        /// This method reads files in parallel and generates output, depending on the type of output service is injected.
        /// </summary>
        /// <param name="wolverhamptonFilePath"></param>
        /// <param name="caufieldFilePath"></param>
        /// <returns></returns>
        public async Task StartProcessing(string wolverhamptonFilePath, string caufieldFilePath)
        {
            var wolverhamptonHorsesTask = _jsonEngine.ImportRace(wolverhamptonFilePath);
            var caufiledHorsesTask = _xmlEngine.ImportRace(caufieldFilePath);

            await Task.WhenAll(wolverhamptonHorsesTask, caufiledHorsesTask);//waiting for taks to finish

            var result = wolverhamptonHorsesTask.Result;
            result.AddRange(caufiledHorsesTask?.Result);//combine both results

            _outputService.GenerateOutput(result);
        }
    }
}
