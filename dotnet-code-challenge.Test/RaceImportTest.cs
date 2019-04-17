using System;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class RaceImportTest
    {
        [Fact]
        public void When_Read_All_Json_Files_Count()
        {
            var fileCountinDirectory = 0;
            Assert.Equal(1, fileCountinDirectory);
        }

        [Fact]
        public void When_Read_All_XML_Files_Count()
        {
            var fileCountinDirectory = 0;
            Assert.Equal(1, fileCountinDirectory);
        }

        [Fact]
        public void When_Read_Json_SingleHorse()
        {
            var horseName = string.Empty; //readfromfile having single horse "George"
            Assert.Equal("George", horseName);
        }

        [Fact]
        public void When_Read_Xml_SingleHorse()
        {
            var horseName = string.Empty; //readfromfile having single horse "George"
            Assert.Equal("George", horseName);
        }

        [Fact]
        public void When_Read_Json_TopHorse()
        {
            var horseName = string.Empty; //readfromfile having horse "George" with highest price
            Assert.Equal("George", horseName);
        }

        [Fact]
        public void When_Read_Xml_TopHorse()
        {
            var horseName = string.Empty; //readfromfile having horse "George" with highest price
            Assert.Equal("George", horseName);
        }

        [Fact]
        public void When_Read_Json_BottomHorse()
        {
            var horseName = string.Empty; //readfromfile having horse "Pony" with lowest price
            Assert.Equal("Pony", horseName);
        }

        [Fact]
        public void When_Read_Xml_BottomHorse()
        {
            var horseName = string.Empty; //readfromfile having horse "Pony" with lowest price
            Assert.Equal("Pony", horseName);
        }
    }
}
