using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using TestSystem.Common;

namespace TestSystem
{
    public partial class InputForm : Form
    {
        public delegate long Stop();

        public event Stop StopThread;
        private readonly double _score;

        public InputForm(double score)
        {
            _score = score;
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show(@"名字不能为空！");
                return;
            }

            if (SqlHelper.ExecuteScalar("select uname from wtest where uname=@uname",
                    new SqlParameter {ParameterName = "@uname", Value = tbName.Text.Trim()}) != null)
            {
                MessageBox.Show(@"名字已存在！");
                return;
            }

            var totalMin = StopThread?.Invoke(); //点击确认键时总共用去的分钟数
            var param = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@uname", Value = tbName.Text.Trim()},
                new SqlParameter {ParameterName = "@totalMin", Value = totalMin},
                new SqlParameter {ParameterName = "@score", Value = _score},
            };
            var res = SqlHelper.ExecuteNonQuery(
                "INSERT INTO dbo.wtest (UNAME, TDATE, INTV, SCORE) VALUES(@uname,getdate(),@totalMin,@score)",
                param.ToArray());
            if (res > 0)
            {
                MessageBox.Show(@"保存成功！");
            }
            else
            {
                MessageBox.Show(@"保存失败！");
                return;
            }

            Close();
            ((MDIParent) Owner).Main.Close();
            var form = new FinishForm(tbName.Text.Trim(), totalMin, _score)
                {MdiParent = Owner, WindowState = FormWindowState.Maximized};
            Owner.Size = form.Size;
            form.Show();
        }
    }
}
