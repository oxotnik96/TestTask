using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class ParseData
    {
        public IEnumerable<StructData> PData(List<string> file_downloading)
        {
            List<string> list_all_data = file_downloading;
            List<string> toparse = new List<string>();
            for (int i = 0; i < list_all_data.Count() - 1; i++)
            {
                if (list_all_data[i].Contains(".html"))
                    toparse.Add(list_all_data[i]);
            }
            List<StructData> l = new List<StructData>();
            StructData struc = new StructData();
            for (int i = 0; i < toparse.Count() - 1; i++)
            {
                List<string> list = new List<string>();
                list = AddingParsed(toparse[i]).ToList();

                struc.IP = list[0];
                struc.date = DateTime.Parse(list[1]);
                struc.type_query = list[2];
                struc.result = int.Parse(list[3]);
                struc.site = list[4];
                struc.size = int.Parse(list[5]);
                l.Add(struc);
            }

            return l;
        }
        
        private IEnumerable<string> ParseBySpace(string str)
        {
            String[] substrings = str.Split(' ');
            return substrings;
        }

        public IEnumerable<string> AddingParsed(string str)
        {
            List<string> substrings = new List<string>();
            List<string> parsed = new List<string>();

            ParseBySpace(str).ToList().ForEach(x => parsed.Add(x));
            //ID
            substrings.Add(parsed[0]);
            //дата с учетом часового пояса
            string time = (parsed[3].Remove(0, 1) + " " + parsed[4].Remove(parsed[4].Length - 1));
            substrings.Add(ParseDateTime(time).ToString());
            //тип запроса
            substrings.Add(parsed[5].Remove(0, 1));
            //результат
            substrings.Add(parsed[8]);
            //путь
            substrings.Add(parsed[6]);
            //размер 
            substrings.Add(parsed[9]);
            return substrings;
        }

        private DateTime ParseDateTime(string time)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "dd/MMM/yyyy:HH:mm:ss zzz";
            DateTime dd = DateTime.ParseExact(time, format, provider);
            return dd;
        }
    }
}
