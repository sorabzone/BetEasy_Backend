using dotnet_code_challange.RaceEngine.Model;
using dotnet_code_challenge.Engine.Interface;
using dotnet_code_challenge.Engine.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace dotnet_code_challenge.Engine.Service
{
    public class JsonEngine : IRaceImportService
    {
        public async Task<List<Horse>> ImportRace(string filesPath)
        {
            //Thread safe collection of horses
            ConcurrentBag<IEnumerable<Horse>> horses = new ConcurrentBag<IEnumerable<Horse>>();

            #region Reading Files
            ActionBlock<string> readAction = new ActionBlock<string>(item =>
            {
                Wolverhampton raceDetail;

                //Reading whole file in memory
                //assumption is that the file size is not very big, otherwise JsonTextReader can be used to read one record at a time.
                using (StreamReader sr = new StreamReader(item))
                {
                    string json = sr.ReadToEnd();
                    raceDetail = JsonConvert.DeserializeObject<Wolverhampton>(json);
                }

                //I am accessing participamts data as well, to get the Jockey name, although it is not part of original requirement
                var horseList = raceDetail.RawData.Markets.SelectMany(m =>
                {
                    return m.Selections.SelectMany(s =>
                    {
                        return raceDetail.RawData.Participants.Where(p => p.Id.ToString() == s.Tags.participant)
                        .Select(p =>
                        {
                            return new Horse
                            {
                                Name = s.Tags.name,
                                Price = s.Price,
                                Drawn = p.Tags.Drawn,
                                Jockey = p.Tags.Jockey,
                                Number = p.Tags.Number,
                                Trainer = p.Tags.Trainer,
                                Weight = p.Tags.Weight
                            };
                        });
                    });
                });

                horses.Add(horseList);
            }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 5 });
            #endregion

            //Remove trailing \ if exists in directory path
            var path = filesPath[filesPath.Length - 1] == '\\' ? filesPath.Substring(0, filesPath.Length - 1) : filesPath;
            string[] filePaths = Directory.GetFiles($@"{path}\", "*.json");

            //ActionBlock read and process all files in parallel(max limit is 5).
            filePaths.ToList().ForEach(filePath =>
            {
                readAction.SendAsync<string>(filePath);
            });

            //waiting for process to complete without blocking the thread
            readAction.Complete();
            await readAction.Completion;

            return horses.SelectMany(i => i).ToList();//flatten the results
        }
    }
}
