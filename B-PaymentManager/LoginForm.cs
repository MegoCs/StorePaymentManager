﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_PaymentManager
{
    public partial class LoginForm : Form
    {
        ConnectionClass con;
        public LoginForm()
        {
            InitializeComponent();
            con = new ConnectionClass();
            con.startConnection();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (userNameTxt.Text != "" && userPassTxt.Text != "")
                {
                    con.SQLCODE("select * from SystemUsers where (userPass='" + userPassTxt.Text + "') and (userName='" + userNameTxt.Text + "')", false);
                    if (con.myReader.Read())
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("خطأ ف البيانات");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ ف استرجاع البيانات");
                Logger.WriteLog("[" + DateTime.Now + "] " + ex.Message + ".");
            }
        }
    }
}
