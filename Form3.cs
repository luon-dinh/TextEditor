using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form3 : Form
    {
        List<user> list = new List<user>();
        int index = 0;
        public static secur secur = new secur();
        public Form3()
        {
            InitializeComponent();
        }

        private void btnc_Click(object sender, EventArgs e)
        {   
            if(txtpass.Text.Equals(txtrepass.Text) )
            {
                StreamReader sr1 = new StreamReader(@"E:\user.txt");
                String line;
                while ((line = sr1.ReadLine()) != null)
                {
                    String[] sublist = line.Split(';');
                    String name1 = secur.Decrypt(sublist[1]);
                    String pass1 = secur.Decrypt(sublist[2]);
                    user user = new user(int.Parse(sublist[0]), name1, pass1);
                    list.Add(user);
                }
                sr1.Close();
                
                foreach(user us in list)
                {
                    if(us.GetUsername().Equals(txtuser.Text)&&us.GetPassword().Equals(txtpass.Text))
                    {
                        MessageBox.Show("Tài khoản đã tồn tại, vui lòng nhập tài khoản khác");
                        txtpass.Text = "";
                        txtuser.Text = "";
                        txtrepass.Text = "";
                        txtuser.Focus();
                        return;
                    }
                }
                String name = secur.Encrypt(txtuser.Text);
                String pass = secur.Encrypt(txtpass.Text);

                user s = new user(index, name, pass);
                StreamWriter sw = File.AppendText(@"E:\user.txt");
                sw.WriteLine(s.ToString());
                sw.Close();
                this.DialogResult = DialogResult.Yes;
                index++;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Pass và re-pass phải giống nhau, vui lòng nhập lại");
                txtpass.Text = "";
                txtuser.Text = "";
                txtrepass.Text = "";
                txtuser.Focus();
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
           
                
        }
    }
}
