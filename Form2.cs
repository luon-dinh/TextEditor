using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form2 : Form
    {
        public static secur secur = new secur();
        List<user> list = new List<user>();
        int flag = 0;
        public Form2()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(!File.Exists(@"E:\user.txt"))
            {
                File.Create(@"E:\user.txt");
            }
            Form3 form3 = new Form3();
            //this.Dispose();
            form3.ShowDialog();
            DialogResult result = form3.DialogResult;
            if(result==DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
                this.Dispose();
                flag = 1;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(File.Exists(@"E:\user.txt"))
            {
                list.Clear();
                StreamReader sr = new StreamReader(@"E:\user.txt");
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] sublist = line.Split(';');
                    String name = secur.Decrypt(sublist[1]);
                    String pass = secur.Decrypt(sublist[2]);
                    user user = new user(int.Parse(sublist[0]), name, pass);
                    list.Add(user);
                }
                sr.Close();
                foreach (user s in list)
                {
                    if (s.GetUsername().Equals(txtUsername.Text) && s.GetPassword().Equals(txtPassword.Text))
                    {
                        this.DialogResult = DialogResult.Yes;
                        this.Dispose();
                        flag++;
                    }
                }
                if(flag==0)
                {
                    MessageBox.Show("Đăng nhập sai, vui lòng đăng nhập lại hoặc tạo tài khoản mới");
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    txtUsername.Focus();
                }
            }
            else
            {
                File.Create(@"E:\user.txt");
                MessageBox.Show("Đăng nhập sai, vui lòng đăng nhập lại hoặc tạo tài khoản mới");
                txtPassword.Text = "";
                txtUsername.Text = "";
                txtUsername.Focus();
            }
        }

     

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flag == 0)
                Application.Exit();
        }
    }
}
