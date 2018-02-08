using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTask.Contracts.DataContracts;
using TestTask.DAL.DataBase;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void whoisgetdata()
        {
            var ip = textBox1.Text;
            result(ip, textBox2);
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

        static async void result(string ip, TextBox t1)
        {
                string res = await whois.getdatawhois(ip);
                t1.Text = res;
        }

        List<StructData> ls;

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label1.Text = "";
            label2.Text = "";
            List<string> list_input = new List<string>();
            list_input = new List<string>(file_downloading());
            ParseData p = new ParseData();
            ls = new List<StructData>(p.PData(list_input));
            outinfo(0, ls);
        }

        public void outinfo( int i , List<StructData> ls )
        {
            textBox1.Text = ls[i].IP;
            whoisgetdata();
            textBox3.Text = ls[i].date.ToString();
            textBox4.Text = ls[i].type_query;
            textBox5.Text = ls[i].result.ToString();
            textBox6.Text = ls[i].site;
            textBox7.Text = "title";
            textBox8.Text = ls[i].size.ToString();
            label1.Text = i.ToString();
            label2.Text = " из " + ls.Count;
            getreadytitle();
        }
        public void cleartb()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //adding
            DataBase db = new DataBase();

            Files file = new Files();
            IPAdress ipadres = new IPAdress();
            MainLog mainLog = new MainLog();
            file.Size = ls[int.Parse(label1.Text)].size;
            file.Title = textBox7.Text;
            file.Way = ls[int.Parse(label1.Text)].site;
            ipadres.IP = ls[int.Parse(label1.Text)].IP;
            ipadres.Name_of_company = textBox2.Text;
            mainLog.type = ls[int.Parse(label1.Text)].type_query;
            mainLog.result = ls[int.Parse(label1.Text)].result;
            mainLog.date = ls[int.Parse(label1.Text)].date;
            mainLog.Files = file;
            mainLog.IpAdress = ipadres;

            //db.AddFiles(file);
            //db.AddIPAdress(ipadres);
            db.AddMainLog(mainLog);

            cleartb();

            label1.Text = (int.Parse(label1.Text) + 1).ToString();
            outinfo(int.Parse(label1.Text), ls);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cleartb();
            label1.Text = (int.Parse(label1.Text) + 1).ToString();
            outinfo(int.Parse(label1.Text) , ls);
        }

        private void getreadytitle()
        {
            string site = "http://www.tariscope.com" + ls[int.Parse(label1.Text)].site;
            string Titlesite = getTitle(site);
        }
        private string title;
        private string getTitle(string site)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Navigate(site);
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
            return title;
        }

        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            title = (sender as WebBrowser).Document.Title;
            if (title == null) title = "";
            textBox7.Text = title;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TestTaskContext db = new TestTaskContext();
            db.mainlog.Load();

            List<MainLog> outData = db.mainlog.Include(c => c.Files).Include(c => c.IpAdress).ToList();
            dataGridView1.DataSource = outData;
        }

    }
}
