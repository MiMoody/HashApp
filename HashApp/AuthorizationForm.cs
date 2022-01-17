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
    public partial class AuthorizationForm : Form
    {
        HashBDEntities db = new HashBDEntities();
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            new RegistrationForm().ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtLogin.Text != string.Empty && TxtPassword.Text != string.Empty)
            {
                string login = TxtLogin.Text;
                string password = TxtPassword.Text;
                string hash_password = HashClass.GetMD5Hash(password);
                if (db.Users.Any(p=>p.Login == login)){
                    if (hash_password == db.Users.Where(p=>p.Login == login).FirstOrDefault().Password) MessageBox.Show("Вы успешно авторизованы");
                    else MessageBox.Show("Проверьте корректность введенного пароля!");
                }
                else MessageBox.Show("Проверьте корректность введенного логина!");

            }
        }
    }
}
