using System;
using System.Windows.Forms;
using Perpustakaan.Model.Context;
using Perpustakaan.Model.Repository;

namespace Perpustakaan.Controller
{
    public class UserController
    {
        private UserRepository _repository;

        public bool IsValidUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("User name harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            bool isValidUser = false;

            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                _repository = new UserRepository(context);
                isValidUser = _repository.IsValidUser(userName, password);
            }

            if (!isValidUser)
            {
                MessageBox.Show("User name atau password salah !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }
    }
}
