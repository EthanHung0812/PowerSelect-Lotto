using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace 作業666
{
    public partial class lab : Form
    {
        List<Label> labels = new List<Label>();
        List<Label> labels本期 = new List<Label>();
        
        List<Button> buttons = new List<Button>(); 
        List<Button> buttons2 = new List<Button>();

        int Click_count = 0;
        int Click2_count = 0;
        int sum = 0;
        public void CreateBtn(int col, int row)
        {
            int num = 1;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (num == 39) { break; }
                    Button btn1 = new Button();
                    btn1.BackColor = Color.PeachPuff;
                    btn1.ForeColor = Color.Black;
                    btn1.Font = new Font("標楷體", 11);
                    btn1.Text = string.Format("{0:00}", num);
                    btn1.Location = new Point(10 + 40 * j, 111 + 40 * i);
                    btn1.Size = new Size(33, 33);

                    btn1.Click += new EventHandler(btn1_Click);

                    Controls.Add(btn1);
                    buttons.Add(btn1);

                    num++;
                }
            }        
        }
        public void CreateBtn2(int col, int row)
        {
            int num2 = 1;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (num2 == 9) { break; }
                    Button btn2 = new Button();
                    btn2.BackColor = Color.PeachPuff;
                    btn2.ForeColor = Color.Black;
                    btn2.Font = new Font("標楷體", 11);
                    btn2.Text = string.Format("{0:00}", num2);
                    btn2.Location = new Point(10 + 40 * j, 360 + 40 * i);
                    btn2.Size = new Size(33, 33);

                    btn2.Click += new EventHandler(btn2_Click);
                    buttons2.Add(btn2);

                    Controls.Add(btn2);
                    buttons2.Add(btn2);

                    num2++;
                }
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            //把物件轉回原本資料型態
            Button myBtn = (Button)sender;
                       
            if (myBtn.BackColor == Color.PeachPuff && Click_count<6)
            {
                myBtn.BackColor = Color.Red;
                Click_count++;
                if(txtN1.Text == ""){txtN1.Text = myBtn.Text;}
                else if(txtN2.Text == "") { txtN2.Text = myBtn.Text; }
                else if (txtN3.Text == "") { txtN3.Text = myBtn.Text; }
                else if (txtN4.Text == "") { txtN4.Text = myBtn.Text; }
                else if (txtN5.Text == "") { txtN5.Text = myBtn.Text; }
                else if (txtN6.Text == "") { txtN6.Text = myBtn.Text; }

            }
            else if(myBtn.BackColor == Color.Red)
            {
                myBtn.BackColor = Color.PeachPuff;
                Click_count--;
                if (txtN1.Text == myBtn.Text) { txtN1.Text = ""; }
                else if (txtN2.Text == myBtn.Text) { txtN2.Text = ""; }
                else if (txtN3.Text == myBtn.Text) { txtN3.Text = ""; }
                else if (txtN4.Text == myBtn.Text) { txtN4.Text = ""; }
                else if (txtN5.Text == myBtn.Text) { txtN5.Text = ""; }
                else if (txtN6.Text == myBtn.Text) { txtN6.Text = ""; }
            }


            
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            //把物件轉回原本資料型態
            Button myBtn = (Button)sender;

            if (myBtn.BackColor == Color.PeachPuff && Click2_count < 1)
            {
                myBtn.BackColor = Color.Red;
                Click2_count++;
                if (txtN7.Text == "") { txtN7.Text = myBtn.Text; }                
            }
            else if (myBtn.BackColor == Color.Red)
            {
                myBtn.BackColor = Color.PeachPuff;
                Click2_count--;
                if (txtN7.Text == myBtn.Text) { txtN7.Text = ""; }                
            }

        }

        public lab()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateBtn(9,5);
            CreateBtn2(8, 1);

            labels.Add(txtN1);
            labels.Add(txtN2);
            labels.Add(txtN3);
            labels.Add(txtN4);
            labels.Add(txtN5);
            labels.Add(txtN6);
            labels.Add(txtN7);

            labels本期.Add(txt本期1);
            labels本期.Add(txt本期2);
            labels本期.Add(txt本期3);
            labels本期.Add(txt本期4);
            labels本期.Add(txt本期5);
            labels本期.Add(txt本期6);
            labels本期.Add(txt本期7);

            lbox紀錄.Visible = false;
        }

        private void btnRND_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            HashSet<int> uniqueNumbers = new HashSet<int>();
            while (uniqueNumbers.Count < 6)
            {
                // 產生一個介於 1 和 38 之間的隨機數字（包含 1 但不包含 38）??????????????
                int randomNumber = rnd.Next(1, 39);
                // 將數字加入 HashSet，由於 HashSet 不允許重複，它會自動檢查??????????????
                uniqueNumbers.Add(randomNumber);
            }
            int[] arr = uniqueNumbers.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 10)
                {
                    labels[i].Text = $"0{arr[i]}";
                }
                else
                {
                    labels[i].Text = arr[i].ToString();
                }
            }
            labels[6].Text = $"0{rnd.Next(1, 9)}";
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (txtN1.Text != "" &&
                txtN2.Text != "" &&
                txtN3.Text != "" &&
                txtN4.Text != "" &&
                txtN5.Text != "" &&
                txtN6.Text != "" &&
                txtN7.Text != "" ) 
            {
                int[] arr =
                {
                    Convert.ToInt16(txtN1.Text),
                    Convert.ToInt16(txtN2.Text),
                    Convert.ToInt16(txtN3.Text),
                    Convert.ToInt16(txtN4.Text),
                    Convert.ToInt16(txtN5.Text),
                    Convert.ToInt16(txtN6.Text),
                };
                Array.Sort(arr);

                string str = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] <= 9)
                    {
                        str += $"0{arr[i]}  ";
                    }
                    else { str += $"{arr[i]}  "; }
                }
                str += $"    {txtN7.Text}";
                lbox顯示.Items.Add(str);

                txtN1.Text = "";
                txtN2.Text = "";
                txtN3.Text = "";
                txtN4.Text = "";
                txtN5.Text = "";
                txtN6.Text = "";
                txtN7.Text = "";

                for(int i = 0;i<buttons.Count; i++)
                {
                    buttons[i].BackColor = Color.PeachPuff;
                }
                for (int i = 0; i < buttons2.Count; i++)
                {
                    buttons2[i].BackColor = Color.PeachPuff;
                }
            }
            else { MessageBox.Show("請選擇完整號碼:\n第一區:6個\n第二區:1個"); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbox顯示.Items.Clear();
            lbox兌獎顯示.Items.Clear();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lbox顯示.SelectedIndex >= 0)
            {
                lbox顯示.Items.RemoveAt(lbox顯示.SelectedIndex);
            }
            else { MessageBox.Show("請選擇一組號碼!!!"); }
        }

        private void btn本期_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            HashSet<int> uniqueNumbers = new HashSet<int>();
            while (uniqueNumbers.Count < 6)
            {
                // 產生一個介於 1 和 38 之間的隨機數字（包含 1 但不包含 38）??????????????
                int randomNumber = rnd.Next(1, 39);
                // 將數字加入 HashSet，由於 HashSet 不允許重複，它會自動檢查??????????????
                uniqueNumbers.Add(randomNumber);
            }
            int[] arr = uniqueNumbers.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 10)
                {
                    labels本期[i].Text = $"0{arr[i]}";
                }
                else
                {
                    labels本期[i].Text = arr[i].ToString();
                }
            }
            labels本期[6].Text = $"0{rnd.Next(1, 9)}";
        }

        private void btn兌獎_Click(object sender, EventArgs e)
        {
            if (txt本期1.Text == "")
            {
                MessageBox.Show("尚未開獎");
            }else
            {
                lbox兌獎顯示.Items.Clear();
                List<string> allArray = new List<string>();
                foreach (string item in lbox顯示.Items)
                {
                    allArray.Add(item);
                }

                string[] arr本期 =
                {
                    txt本期1.Text,
                    txt本期2.Text,
                    txt本期3.Text,
                    txt本期4.Text,
                    txt本期5.Text,
                    txt本期6.Text,
                    txt本期7.Text
                };


                for (int i = 0; i < allArray.Count; i++)
                {
                    int result1 = 0, result2 = 0;
                    string[] a = allArray[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (a[a.Length - 1] == txt本期7.Text)
                    {
                        result2++;
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (a[j] == arr本期[k])
                            {
                                result1++;
                            }
                        }
                    }
                    
                    string str = "";
                    if (result1 == 6 && result2 == 1) { str = "頭獎:$$$,$$$,$$$"; lbox紀錄.Items.Add(str);  MessageBox.Show("頭獎!!!"); }
                    else if (result1 == 6 && result2 == 0) { str = "貳獎$,$$$,$$$"; lbox紀錄.Items.Add(str); MessageBox.Show("貳獎!!!"); }
                    else if (result1 == 5 && result2 == 1) { str = "參獎：$150,000\n"; lbox紀錄.Items.Add(str); sum += 150_000;  }
                    else if (result1 == 5 && result2 == 0) { str = "肆獎：$20,000\n"; lbox紀錄.Items.Add(str); sum += 20_000; }
                    else if (result1 == 4 && result2 == 1) { str = "伍獎：$4,000\n"; lbox紀錄.Items.Add(str); sum += 4_000; }
                    else if (result1 == 4 && result2 == 0) { str = "陸獎：$800\n"; lbox紀錄.Items.Add(str); sum += 800; }
                    else if (result1 == 3 && result2 == 1) { str = "柒獎：$400\n"; lbox紀錄.Items.Add(str); sum += 400; }
                    else if (result1 == 2 && result2 == 1) { str = "捌獎：$200\n"; lbox紀錄.Items.Add(str); sum += 200; }
                    else if (result1 == 3 && result2 == 0) { str = "玖獎：$100\n"; lbox紀錄.Items.Add(str); sum += 100; }
                    else if (result1 == 1 && result2 == 1) { str = "普獎：$100\n"; lbox紀錄.Items.Add(str); sum += 100; }
                    else { str = "沒中!"; }
                    lbox兌獎顯示.Items.Add(str);
                    
                }
            }
        }

        private void btn紀錄_Click(object sender, EventArgs e)
        {
            lbox紀錄.Visible = !lbox紀錄.Visible;
            MessageBox.Show($"總中獎金額:${sum}");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();

                for (int i = 0; i < Convert.ToInt64(tboxSUM.Text); i++)
                {
                    HashSet<int> uniqueNumbers = new HashSet<int>();

                    while (uniqueNumbers.Count < 6)
                    {
                        // 產生一個介於 1 和 38 之間的隨機數字（包含 1 但不包含 38）??????????????
                        int randomNumber = rnd.Next(1, 39);
                        // 將數字加入 HashSet，由於 HashSet 不允許重複，它會自動檢查??????????????
                        uniqueNumbers.Add(randomNumber);
                    }
                    int[] arr2 = uniqueNumbers.ToArray();
                    string str = "";
                    for (int q = 0; q < arr2.Length; q++)
                    {
                        if (Convert.ToInt16(arr2[q]) <= 9)
                        {
                            str += $"0{arr2[q]}  ";
                        }
                        else { str += $"{arr2[q]}  "; }
                    }
                    str += $"    0{rnd.Next(1, 9)}";
                    lbox顯示.Items.Add(str.Trim());

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            
        }
    }
}
