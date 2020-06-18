using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ViewTxt
{
    public partial class Form1 : Form
    {
        private TextBox TextBox1;
        private Label Label1;
        private ListBox ListBox1;
        private Button Button1;
        private Button Button2;
        private FolderBrowserDialog FolderBrowserDialog1;
        private RadioButton RadioButton3;
        private RadioButton RadioButton2;
        private RadioButton RadioButton1;
        private string CurrentEncodingDesc;
        private Encoding CurrentEncoding;
        public Form1()
        {
            CurrentEncoding = Encoding.GetEncoding(1251);
            Initialize();
        }

        private void Initialize()
        {
            CreateForm();
            CreateLabel();
            CreateTextBox();
            CreateListBox();
            CreateButton1();
            CreateButton2();
            CreateRadioButton3();
            CreateRadioButton2();
            CreateRadioButton1();
            FolderBrowserDialog1 = new FolderBrowserDialog();
            FolderBrowserDialog1.ShowNewFolderButton = false;
        }

        private void CreateRadioButton1()
        {
            RadioButton1 = new RadioButton();
            RadioButton1.Checked = true;
            RadioButton1.AutoSize = true;
            RadioButton1.Location = new Point(424, 530);
            RadioButton1.Size = new Size(80, 17);
            RadioButton1.Text = "Зап.-европ.";
            RadioButton1.UseVisualStyleBackColor = true;
            Controls.Add(RadioButton1);
        }
        private void CreateRadioButton2()
        {
            RadioButton2 = new RadioButton();
            RadioButton2.AutoSize = true;
            RadioButton2.Location = new Point(424, 553);
            RadioButton2.Size = new Size(83, 17);
            RadioButton2.TabIndex = 0;
            RadioButton2.TabStop = true;
            RadioButton2.Text = "Кириллица";
            Controls.Add(RadioButton2);
        }

        private void CreateRadioButton3()
        {
            RadioButton3 = new RadioButton();
            RadioButton3.AutoSize = true;
            RadioButton3.Location = new Point(424,575);
            RadioButton3.Size = new Size(64, 17);
            RadioButton3.TabIndex = 2;
            RadioButton3.Text = "Юникод";
            RadioButton3.UseVisualStyleBackColor = true;
            Controls.Add(RadioButton3);

        }

        private void CreateButton2()
        {
            Button2 = new Button();
            Button2.Location = new Point(417, 643);
            Button2.Size = new Size(111, 27);
            Button2.TabIndex = 3;
            Button2.Text = "Отмена";
            Button2.UseVisualStyleBackColor = true;
            Button2.Click += (a, b) =>
            {
                Close();
            };
            Controls.Add(Button2);
        }

        private void CreateButton1()
        {
            Button1 = new Button();
            Button1.Location = new Point(418, 606);
            Button1.Size = new Size(111, 31);
            Button1.TabIndex = 3;
            Button1.Text = "Выбрать каталог";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += (a, b) =>
            {
                if (FolderBrowserDialog1.ShowDialog() != DialogResult.OK)
                    return;
                Label1.Text = FolderBrowserDialog1.SelectedPath;
                var directoryInfo = new DirectoryInfo(FolderBrowserDialog1.SelectedPath);
                ListBox1.Items.Clear();
                ListBox1.SelectedIndex = -1;
                try
                {
                    foreach (FileInfo enumerateFile in directoryInfo.EnumerateFiles("*.txt"))
                        ListBox1.Items.Add(enumerateFile.Name);
                }
                finally{}
            };
            Controls.Add(Button1);
        }

        private void CreateListBox()
        {
            ListBox1 = new ListBox();
            ListBox1.FormattingEnabled = true;
            ListBox1.Location = new Point(16, 510);
            ListBox1.Size = new Size(380, 160);
            ListBox1.Sorted = true;
            ListBox1.TabIndex = 2;
            ListBox1.SelectedIndexChanged += (a, b) =>
            {
                var path = Path.Combine(Label1.Text, ListBox1.SelectedItem.ToString());
                var txt = "";
                using (StreamReader str = new StreamReader(path))
                {
                    txt = str.ReadToEnd();
                }
                TextBox1.Text = CurrentEncoding.GetString(Encoding.UTF8.GetBytes(txt));
            };
            Controls.Add(ListBox1);
        }

        private void CreateLabel()
        {
            Label1 = new Label();
            Label1.Location = new Point(18, 471);
            Label1.Size = new Size(510, 22);
            Label1.TabIndex = 1;
            Controls.Add(Label1);
        }

        private void ChooseEncoding(object sender, EventArgs e)
        {
            string text = ((ButtonBase)sender).Text;
            string Left = text;
            Encoding encoding = Operators.CompareString(Left, "Зап.-европ.", false) != 0 ? (Operators.CompareString(Left, "Юникод", false) != 0 ? Encoding.GetEncoding(1251) : Encoding.GetEncoding("utf-8")) : Encoding.GetEncoding(1250);
            if (Operators.CompareString(CurrentEncodingDesc, text, false) == 0)
                return;
            CurrentEncoding = encoding;
            CurrentEncodingDesc = text;
            if (Operators.CompareString(TextBox1.Text, "", false) != 0)
            {
                var path = Path.Combine(Label1.Text, ListBox1.SelectedItem.ToString());
                var txt = "";
                using (StreamReader str = new StreamReader(path))
                {
                    txt = str.ReadToEnd();
                }
                TextBox1.Text = CurrentEncoding.GetString(Encoding.UTF8.GetBytes(txt));
            }
        }


        private void CreateForm()
        {
            ClientSize = new Size(544, 682);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр текстовых файлов";
            Load += (a, b) =>
            {
                RadioButton1.Click += new EventHandler(ChooseEncoding);
                RadioButton2.Click += new EventHandler(ChooseEncoding);
                RadioButton3.Click += new EventHandler(ChooseEncoding);
            };
        }

        private void CreateTextBox()
        {
            TextBox1 = new TextBox();
            TextBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBox1.Multiline = true;
            TextBox1.ScrollBars = ScrollBars.Vertical;
            TextBox1.Location = new Point(16, 19);
            TextBox1.Size = new Size(513, 436);
            TextBox1.TabIndex = 0;
            Controls.Add(TextBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
