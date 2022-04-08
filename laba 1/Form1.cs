using System.Text.RegularExpressions;
using System.Collections;
namespace laba_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            comboBox1.Items.Add("алфавиту (по возрастанию)");
            comboBox1.Items.Add("алфавиту (по убыванию)");
            
            //comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("алфавиту (по возрастанию)");
            comboBox2.Items.Add("алфавиту (по убыванию)");
            
            //comboBox2.SelectedIndex = 0;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear(); 
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(openFileDialog.FileName);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            openFileDialog.Dispose();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                StreamWriter Writer = new StreamWriter(saveFileDialog.FileName);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox2.Items[i]);
                }
                Writer.Close();
            }
            saveFileDialog.Dispose();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 AddRec = new Form4();
            AddRec.Owner = this;
            AddRec.ShowDialog();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                Form5 AddRec = new Form5();
                AddRec.Owner = this;
                AddRec.ShowDialog();
            }
            else
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox1.BeginUpdate();
                string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' },
                StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in Strings)
                {
                    string Str = s.Trim();

                    if (Str == String.Empty) continue;
                    if (radioButton1.Checked) listBox1.Items.Add(Str);
                    if (radioButton2.Checked)

                    {
                        if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                    }
                    if (radioButton3.Checked)
                    {
                        if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);
                    }
                }
                listBox1.EndUpdate();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            richTextBox1.Clear();
            textBox1.Clear();  
            radioButton1.Checked = false;
            radioButton2.Checked = false;       
            radioButton3.Checked = false;   

        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            string Find = textBox1.Text;
            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();
            AddRec.Owner = this;
            AddRec.ShowDialog();
        }
        public void DeleteSelectedStrings(ListBox l)
        {
            for (int i = l.Items.Count - 1; i >= 0; i--)
            {
                if (l.GetSelected(i)) l.Items.RemoveAt(i);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if(choose == false)
            {
                DeleteSelectedStrings(listBox1);
            }
            if(choose == true)
            {
                DeleteSelectedStrings(listBox2);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            choose = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            choose = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                Form3 AddRec = new Form3();
                AddRec.Owner = this;
                AddRec.ShowDialog();
            }
            else
            {
                if (comboBox1.SelectedItem.ToString() == "алфавиту (по возрастанию)")
                {
                    ArrayList list = new ArrayList();
                    foreach (var item in listBox1.Items)
                    {
                        list.Add(item);
                    }
                    list.Sort();

                    listBox1.Items.Clear();
                    foreach (var item in list)
                    {
                        listBox1.Items.Add(item);
                    }
                }

                if (comboBox1.SelectedItem.ToString() == "алфавиту (по убыванию)")
                {
                    ArrayList list = new ArrayList();
                    foreach (var item in listBox1.Items)
                    {
                        list.Add(item);
                    }
                    list.Sort();
                    list.Reverse();
                    listBox1.Items.Clear();
                    foreach (var item in list)
                    {
                        listBox1.Items.Add(item);
                    }
                }
                
            }
            
        }
        public static void Swap(ref string x, ref string y)
        {
            string temp = x;
            x = y;
            y = temp;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                Form3 AddRec = new Form3();
                AddRec.Owner = this;
                AddRec.ShowDialog();
            }

            else
            {
                if (comboBox2.SelectedItem.ToString() == "алфавиту (по возрастанию)")
                {
                    ArrayList list = new ArrayList();
                    foreach (var item in listBox2.Items)
                    {
                        list.Add(item);
                    }
                    list.Sort();

                    listBox2.Items.Clear();
                    foreach (var item in list)
                    {
                        listBox2.Items.Add(item);
                    }
                }

                if (comboBox2.SelectedItem.ToString() == "алфавиту (по убыванию)")
                {
                    ArrayList list = new ArrayList();
                    foreach (var item in listBox2.Items)
                    {
                        list.Add(item);
                    }
                    list.Sort();
                    list.Reverse();
                    listBox2.Items.Clear();
                    foreach (var item in list)
                    {
                        listBox2.Items.Add(item);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(choose == false)
            {
                listBox1.BeginUpdate();
                listBox2.BeginUpdate();
                foreach (object Item in listBox1.SelectedItems)
                {
                    listBox2.Items.Add(Item);
                }
                listBox1.EndUpdate();
                listBox2.EndUpdate();

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (choose == true)
            {
                listBox2.BeginUpdate();
                listBox1.BeginUpdate();
                foreach (object Item in listBox2.SelectedItems)
                {
                    listBox1.Items.Add(Item);
                }
                listBox2.EndUpdate();
                listBox1.EndUpdate();

            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}