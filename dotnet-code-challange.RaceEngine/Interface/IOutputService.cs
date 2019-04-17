using dotnet_code_challange.RaceEngine.Model;
using System.Collections.Generic;

namespace dotnet_code_challange.RaceEngine.Interface
{
    public interface IOutputService
    {
        void GenerateOutput(List<Horse> output);
    }
}
