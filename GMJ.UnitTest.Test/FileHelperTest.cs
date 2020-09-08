using System;
using System.Collections.Generic;
using GMJ.Models;
using Xunit;
using GMJ.Utils;
using System.Linq;

namespace GMJ.UnitTest.Test
{
    public class FileHelperTest
    {
        [Fact]
        public void ToCSV_Correct_Colums()
        {
            //Given
            var list = new List<People>();
            //When
            var headers = list.ToCsV();
            Console.WriteLine(headers);
            //Then
            Assert.Equal(headers, $"{string.Join(",", new People().GetType().GetProperties().Select(c => c.Name))}\n");
        }

        [Fact]
        public void ToCSV_Correct_Data()
        {
            //Given
            var list = new List<People>
            {
                new People{Name ="Gerardo"}
            };
            //When
            var csv = list.ToCsV();
            //Then
            Assert.Contains("Gerardo", csv);
        }
    }
}
