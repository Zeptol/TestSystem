using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using TestSystem.Common;

namespace TestSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblHint1.Text = lblHint2.Text = "";
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                lblHint1.Text = @"用户名不能为空";
                if (string.IsNullOrWhiteSpace(tbPwd.Text))
                {
                    lblHint2.Text = @"密码不能为空";
                }
                return;
            }

            var dt = SqlHelper.ExecuteDataTable("select * from admin where UNAME=@name",
                new SqlParameter {ParameterName = "@name", Value = tbName.Text.Trim()});
            if (dt.Rows.Count > 0)
            {
                if (string.Equals(dt.Rows[0]["PASSWORD"].ToString(), tbPwd.Text.GetMd5(), StringComparison.CurrentCultureIgnoreCase))
                {
                    ((MDIParent)Owner).Main.Close();
                    var form=new QuestionListForm {MdiParent = Owner, WindowState = FormWindowState.Maximized,Text = tbName.Text.Trim()};
                    Owner.Size = form.Size;
                    Owner.Height += 20;
                    form.Show();
                    ((MDIParent)Owner).QuestionListForm = form;
                    ((MDIParent) Owner).LogoutMenuItem.Enabled = true;
                    ((MDIParent) Owner).LoginMenuItem.Enabled = false;
                    Close();
                }
                else
                {
                    lblHint2.Text = @"密码错误";
                }
            }
            else
            {
                lblHint1.Text = @"用户不存在";
            }
        }
    }
}
