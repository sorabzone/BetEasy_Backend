# BetEasy_Backend
Backend Coding Challange

# Project Structure

# dotnet-code-challenge - Console application
It is a dotNet core console application that reads XML and JSON input from file system and generates output.

Input files path is provided from environment variables. Environment variable is easy to pass in CI/CD and DockerCompose. you can pass different paths for different deployment, without making any change in any application config files.

2 Environment variables:
WolverhamptonFiles - FeedData
CaufieldFiles - FeedData

For now relative path of /FeedData directory is set for both type of files.

# dotnet-code-challenge.RaceEngine
Engines process files to generate the output.
There is separate engine for JSON and XML files.

Applicaton design allows it to easily expand to support different output formats. As per requirement the output is printed on console but there is another service to write result in an excel file. Type is injected in program.cs via DI.

# dotnet-code-challenge.Test
Unittest cases are created before coding. But none of the test case is complete because of time constraint.


# Assumption & Limitations
1. No error logging for now.
2. Only JSON file processing is complete, code is available in JsonEngine.cs. But XML file processing will also be similar, just the model class and way to read files will be different.
3. Reading whole file in memory. Assumption is that the file size is not very big, otherwise JsonTextReader can be used to read one record at a time.
4. I am accessing participants data as well, to get the Jockey name, although it is not part of original requirement

# How to Run
1. Clone the repository
2. Open project in Visual Studio and run "dotnet-code-challenge" console application.
