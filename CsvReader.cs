using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_Collections_of_Collections
{
    public class CsvReader
    {
        private String _csvFileName;
        public CsvReader(String _csvFileName)
        {
            this._csvFileName = _csvFileName;
        }

        public Dictionary<String, List<Country>> ReadFile()
        {
            var result = new Dictionary<String, List<Country>>();

            using (StreamReader reader = new StreamReader(this._csvFileName))
            {
                
                reader.ReadLine();
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    Country country = ConvartedLineToArray(line);
                    if (result.ContainsKey(country.Region))
                    {
                        result[country.Region].Add(country);
                    }
                    else
                    {
                        var countryInRegion = new List<Country> { country};
                        
                        result.Add(country.Region,countryInRegion);
                    }
                }
            }

            return result;
        }
        private Country ConvartedLineToArray(String line)
        {
            String[] lineArray = line.Split(',');
            String name;
            String Code;
            String Region;
            String Population;
            switch (lineArray.Length)
            {
                case 4:
                    name = lineArray[3];
                    Code = lineArray[2];
                    Region = lineArray[1];
                    Population = lineArray[0];
                    break;
                case 5:
                    name = lineArray[3] + "," + lineArray[4];
                    name = name.Replace("\'", null).Trim();
                    Code = lineArray[2];
                    Region = lineArray[1];
                    Population = lineArray[0];
                    break;

                default:
                    throw new Exception($"Error  {line} ");
            };
            int.TryParse(Population, out int population);
            return new Country(name, Code, Region, population);
        }

    }
}
