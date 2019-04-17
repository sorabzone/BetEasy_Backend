using dotnet_code_challange.RaceEngine.Model;
using dotnet_code_challenge.Engine.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_code_challenge.Engine.Service
{
    public class XmlEngine : IRaceImportService
    {
        /// <summary>
        /// NOT IMPLEMENTED YET
        /// read from XML file
        /// </summary>
        /// <param name="filesPath"></param>
        /// <returns></returns>
        public async Task<List<Horse>> ImportRace(string filesPath)
        {
            return new List<Horse>();
        }
    }
}
