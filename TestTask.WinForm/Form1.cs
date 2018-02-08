using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            list = (List<string>)file_downloading();

            List<string> parse_2 = new List<string>();
            //ID
            List<string> id = new List<string>();
            //Date
            List<DateTime> date = new List<DateTime>();
            //тип запроса
            List<string> type = new List<string>();
            //путь
            List<string> way = new List<string>();
            //результат
            List<int> result = new List<int>();
            //размер переданных данных
            List<int> size = new List<int>();

            //для даты
            string time;
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "dd/MMM/yyyy:HH:mm:ss zzz";

            for (int i = 0; i < list.Count() - 1; i++)
            {
                Parse_By_Space(list[i]).ToList().ForEach(x => parse_2.Add(x));
                //айди
                id.Add(parse_2[0]);
                //дата с учетом часового пояса
                time = (parse_2[3].Remove(0, 1) + " " + parse_2[4].Remove(parse_2[4].Length - 1));
                DateTime dd = DateTime.ParseExact(time, format, provider);
                date.Add(dd);
                //тип
                type.Add(parse_2[5].Remove(0, 1));
                //результат
                result.Add(int.Parse(parse_2[8]));
                //путь
                way.Add("http://tariscope.com" + parse_2[6]);
                //размер 
                size.Add(int.Parse(parse_2[9]));
                //очистка
                parse_2.Clear();
            }

            DataBase db = new DataBase();
            db.AddDB(id[0], "123");

        }

        public IEnumerable<string> Parse_By_Space(string str)
        {
            String[] substrings = str.Split(' ');
            return substrings;
        }

        private IEnumerable<string> file_downloading()
        {
            string way;//way to file
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.ShowDialog();
                way = openFileDialog1.FileName;
            }
            List<string> list = new List<string>();
            using (StreamReader fs = new StreamReader(way))
            {
                string s = "";
                while (s != null)
                {
                    s = fs.ReadLine();
                    list.Add(s);
                }
            }
            return list;
        }
    }
}
