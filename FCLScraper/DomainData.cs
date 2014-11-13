using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FCLScraper
{
    // Class the will store information about DomainData.csv
    public class DomainData
    {
        // Name,URL
        public string Name { get; set; }
        public string URL { get; set; }        
    }

    public class DomainDataParser
    {
        public List<DomainData> ListPostData = new List<DomainData>();
        CsvReader CSVReader = null;

        public DomainDataParser(String strFileName)
        {
            StreamReader sr = new StreamReader(strFileName);
            CSVReader = new CsvReader(sr);

            //Get all records in store in IEnumerable
            IEnumerable<DomainData> items = CSVReader.GetRecords<DomainData>();

            foreach (DomainData item in items) // Each record will be fetched and printed on the screen
            {
                ListPostData.Add(item);
                Console.Out.WriteLine(item.Name + " " + item.URL);
            }

            sr.Close();
        }
    }

}
