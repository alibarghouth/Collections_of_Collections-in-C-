using Creating_Collections_of_Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        String CsvFile = "C:\\Users\\user\\source\\repos\\Creating Collections of Collections\\Country.Csv";
        CsvReader readingCsvFile = new CsvReader(CsvFile);
        Dictionary<string, List< Country>> dictionary = readingCsvFile.ReadFile();
        foreach(String region in dictionary.Keys)
        {
            Console.WriteLine(region);
        }
        Console.WriteLine("Choose Region");
        String chooseRegion = Console.ReadLine();

        if (dictionary.ContainsKey(chooseRegion))
        {
            foreach(Country country in dictionary[chooseRegion].Take(1).OrderBy(x=>x.Name).Where(x=>!x.Name.Contains(',')))
            {
                Console.WriteLine($"{country.Name}    :   {country.Population}  ");
            }
        }
        else
        {
            Console.WriteLine("The Key Is Not Exist");
        }
        
    }
}