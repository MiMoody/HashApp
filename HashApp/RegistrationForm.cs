using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashApp
{
    public partial class RegistrationForm : Form
    {
        HashBDEntities db = new HashBDEntities();
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            if (TxtLogin.Text !=string.Empty && TxtPassword.Text != string.Empty)
            {
                try
                {
                    var name = TxtName.Text;
                    var login = TxtLogin.Text;
                    var password = TxtPassword.Text;
                    string hash_password = HashClass.GetMD5Hash(password);
                    Users user = new Users { Login = login, Name = name, Password = hash_password };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен!");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Такой пользователь уже существует!");
                }
            }
            else MessageBox.Show("Вы не заполнили поля!");
        }
    }
}
