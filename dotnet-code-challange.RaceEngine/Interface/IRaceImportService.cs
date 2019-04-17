using dotnet_code_challange.RaceEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_code_challenge.Engine.Interface
{
    public interface IRaceImportService
    {
        Task<List<Horse>> ImportRace(string filesPath);
    }
}
