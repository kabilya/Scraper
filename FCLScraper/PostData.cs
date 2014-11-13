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
    // Class the will store information about PostData.txt
    public class PostData
    {
        // Name|Start|End
        public string Name { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

    }

    public sealed class PostDataMap : CsvClassMap<PostData>
    {
        public PostDataMap()
        {
            Map(m => m.Name);
            Map(m => m.Start);
            Map(m => m.End);
        }
    }

    public class PostDataParser
    {
        public List<PostData> ListPostData = new List<PostData>();
        CsvReader CSVReader = null;
        public PostDataParser(String strFileName)
        {
            StreamReader sr = new StreamReader(strFileName);
            CSVReader = new CsvReader(sr);
            CSVReader.Configuration.Delimiter = "|";

            //Get all records in store in IEnumerable
            IEnumerable<PostData> ArrayPostData = CSVReader.GetRecords<PostData>();

            foreach (PostData item in ArrayPostData) // Each record will be fetched and printed on the screen
            {
                ListPostData.Add(item);
            }

            sr.Close();

        }
    }

}
