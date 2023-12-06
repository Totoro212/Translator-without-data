using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Переводчик
{

    public partial class Form1 : Form
    {
        string[,] dic = new string[100, 4];
        public Form1()
        {
            InitializeComponent();
        }
        void DIC()
        {
            dic[0, 0] = "Salom"; dic[0, 1] = "Привет"; dic[0, 2] = "Hi"; dic[0, 3] = "annyeonghaseyo";
            dic[1, 0] = "Yaxshi"; dic[1, 1] = "Хорошо"; dic[1, 2] = "Good"; dic[1, 3] = "gwaenchanh-eun";
            dic[2, 0] = "Yomon"; dic[2, 1] = "Плохо"; dic[2, 2] = "Bad"; dic[2, 3] = "simhage";
            dic[3, 0] = "Va"; dic[3, 1] = "И"; dic[3, 2] = "And"; dic[3, 3] = "geuligo";
            dic[4, 0] = "Yoki"; dic[4, 1] = "Или"; dic[4, 2] = "Or"; dic[4, 3] = "ttoneun";
            dic[5, 0] = "Kompyuter"; dic[5, 1] = "Компьютер"; dic[5, 2] = "Computer"; dic[5, 3] = "keompyuteo";
            dic[6, 0] = "Men"; dic[6, 1] = "я"; dic[6, 2] = "I"; dic[6, 3] = "na";
            dic[7, 0] = "Siz"; dic[7, 1] = "ты"; dic[7, 2] = "you"; dic[7, 3] = "neo";
            dic[8, 0] = "qil"; dic[8, 1] = "делать"; dic[8, 2] = "do"; dic[8, 3] = "hada";
            dic[9, 0] = "vaqt"; dic[9, 1] = "время"; dic[9, 2] = "time"; dic[9, 3] = "sigan";
            dic[10, 0] = "Agar"; dic[10, 1] = "если"; dic[10, 2] = "if"; dic[10, 3] = "man-yag-e";
            dic[11, 0] = "istayman"; dic[11, 1] = "хотеть"; dic[11, 2] = "want"; dic[11, 3] = "wonhada";
            dic[12, 0] = "gapirish"; dic[12, 1] = "говорить"; dic[12, 2] = "said"; dic[12, 3] = "malhada";
            dic[13, 0] = "o'ynash"; dic[13, 1] = "играть"; dic[13, 2] = "play"; dic[13, 3] = "nolda";
            dic[14, 0] = "Yer"; dic[14, 1] = "земля"; dic[14, 2] = "land"; dic[14, 3] = "jigu";
            dic[15, 0] = "Odamlar"; dic[15, 1] = "люди"; dic[15, 2] = "people"; dic[15, 3] = "salamdeul";
            dic[16, 0] = "oila"; dic[16, 1] = "семья"; dic[16, 2] = "family"; dic[16, 3] = "gajog";
            dic[17, 0] = "kun"; dic[17, 1] = "день"; dic[17, 2] = "day"; dic[17, 3] = "naj";
            dic[18, 0] = "ovqat"; dic[18, 1] = "еда"; dic[18, 2] = "food"; dic[18, 3] = "eumsig";
            dic[19, 0] = "suv"; dic[19, 1] = "вода"; dic[19, 2] = "water"; dic[19, 3] = "mul";
            dic[20, 0] = "Ish"; dic[20, 1] = "работа"; dic[20, 2] = "work "; dic[20, 3] = "jig-eob";
        }

        void Selected()
        {
            listBox1.Items.Clear(); listBox2.Items.Clear();
            int i = 0;
            if (comboBox1.SelectedIndex >= 0 & comboBox2.SelectedIndex >= 0)
                while (dic[i, comboBox1.SelectedIndex] != "" & i < 21)
                {
                    listBox1.Items.Add(dic[i, comboBox1.SelectedIndex]);
                    listBox2.Items.Add(dic[i++, comboBox2.SelectedIndex]);
                }
        }

        string TR(string S, int tr1, int tr2)
        {
            string[] words = S.Split(' ');
            string t, T;
            string sent = "";
            string[] tr_words = new string[words.Length];
            int num = 0, i = 0, j = 0;

            while (true & dic.Length / 4 > i & j != words.Length)
            {
                t = "";
                if (words[j].LastIndexOf("ning") > 0) { t = "ning"; T = words[j].Remove(words[j].LastIndexOf("ning")); }
                else if (words[j].LastIndexOf("lar") > 0) { t = "lar"; T = words[j].Remove(words[j].LastIndexOf("lar")); }
                else if (words[j].LastIndexOf("s ") > 0) { t = "s"; T = words[j].Remove(words[j].LastIndexOf("s")); }
                else if (words[j].LastIndexOf("ете") > 0) { t = "ете"; T = words[j].Remove(words[j].LastIndexOf("ете")); }
                else if (words[j].LastIndexOf("ешь") > 0) { t = "ешь"; T = words[j].Remove(words[j].LastIndexOf("ешь")); }
                else if (words[j].LastIndexOf("nin") > 0) { t = "nin"; T = words[j].Remove(words[j].LastIndexOf("nin")); }
                else T = words[j];

                for (int y = 0; y < listBox1.Items.Count; y++)
                {
                    if (T.ToLower() == listBox1.Items[y].ToString().ToLower()  )
                    {
                        if (t == "")
                        {
                            tr_words[j] = dic[y, tr2] + " "; break;
                        }
                        else if (t == "ning")
                        {
                            if (tr2 == 1) { tr_words[j] = dic[y, tr2] + "ешь "; break; }
                            if (tr2 == 2) { tr_words[j] = dic[y, tr2] + "'s "; break; }
                            if (tr2 == 3) { tr_words[j] = dic[y, tr2] + "nin "; break; }

                        }
                        else if (t == "lar")
                        {
                            if (tr2 == 1) { tr_words[j] = dic[y, tr2] + "ете "; break; }
                            if (tr2 == 2) { tr_words[j] = dic[y, tr2] + "s"; break; }
                            if (tr2 == 3) { tr_words[j] = dic[y, tr2] + "nin "; break; }

                        }
                        else if (t == "s")
                        {
                            if (tr2 == 1) { tr_words[j] = dic[y, tr2] + "ете "; break; }
                            if (tr2 == 0) { tr_words[j] = dic[y, tr2] + "lar"; break; }
                            if (tr2 == 3) { tr_words[j] = dic[y, tr2] + "nin "; break; }

                        }
                        else if (t == "ете")
                        {
                            if (tr2 == 0) { tr_words[j] = dic[y, tr2] + "lar"; break; }
                            if (tr2 == 2) { tr_words[j] = dic[y, tr2] + "s"; break; }
                            if (tr2 == 3) { tr_words[j] = dic[y, tr2] + "nin"; break; }
                        }
                        else if (t == "ешь")
                        {
                            if (tr2 == 0) { tr_words[j] = dic[y, tr2] + "ning"; break; }
                            if (tr2 == 2) { tr_words[j] = dic[y, tr2] + "'s"; break; }
                            if (tr2 == 3) { tr_words[j] = dic[y, tr2] + "nin "; break; }
                        }
                        else if (t == "nin")
                        {
                            if (tr2 == 1) { tr_words[j] = dic[y, tr2] + "ете "; break; }
                            if (tr2 == 0) { tr_words[j] = dic[y, tr2] + "ning "; break; }
                            if (tr2 == 2) { tr_words[j] = dic[y, tr2] + "'s "; break; }
                        }
                    }
                    else tr_words[j] = T;
                }

                num += 1; j++;
                if (num == words.Length)
                {
                    
                    return string.Join(" ", tr_words);
                }
            }
            return "";
        }


        private void comboBox1_Click(object sender, EventArgs e)
        { Selected(); }
        private void comboBox2_Click(object sender, EventArgs e)
        { Selected(); }
        private void Form1_Load(object sender, EventArgs e)
        { DIC(); }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = TR(textBox1.Text, comboBox1.SelectedIndex, comboBox2.SelectedIndex);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
            textBox2.Text = TR(textBox1.Text, comboBox1.SelectedIndex, comboBox2.SelectedIndex);
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text = listBox2.Items[listBox2.SelectedIndex].ToString();
            textBox1.Text = TR(textBox2.Text, comboBox2.SelectedIndex, comboBox1.SelectedIndex);
        }
    }
}
