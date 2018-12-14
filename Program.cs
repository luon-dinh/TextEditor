using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TextEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new textEditor());

        }
       
    }
    public class user
    {
        int index = 0;
        int id { get; set; }

        private string username;

        public string GetUsername()
        {
            return username;
        }

        private void SetUsername(string value)
        {
            username = value;
        }

        private string password;

        public string GetPassword()
        {
            return password;
        }

        private void SetPassword(string value)
        {
            password = value;
        }

        public user(int index, String name, String pass)
        {
            this.index = index;
            this.SetUsername(name);
            this.SetPassword(pass);
        }
        public override string ToString()
        {
            return this.index + ";" + this.username + ";" + this.password;
        }
    }
}
