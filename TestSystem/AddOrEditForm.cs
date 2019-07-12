using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using TestSystem.Common;
using TestSystem.Model;

namespace TestSystem
{
    public partial class AddOrEditForm : Form
    {
        private readonly Ct _model;

        public delegate void Reload();

        public event Reload ReloadDgv;//定义刷新父页面 dataGridView 的事件
        public AddOrEditForm(Ct model=null)
        {
            _model = model;
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTg.Text))
            {
                MessageBox.Show(@"题干不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbAnswer.Text))
            {
                MessageBox.Show(@"答案不能为空！");
                return;
            }
            if (!new List<string>{"A","B","C","D"}.Contains(tbAnswer.Text.Trim().ToUpper()))
            {
                MessageBox.Show(@"答案必须为 A,B,C,D 其中之一！");
                return;
            }
            var param = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = "@tg", Value = tbTg.Text.Trim()},
                new SqlParameter {ParameterName = "@a", Value = tbA.Text.Trim()},
                new SqlParameter {ParameterName = "@b", Value = tbB.Text.Trim()},
                new SqlParameter {ParameterName = "@c", Value = tbC.Text.Trim()},
                new SqlParameter {ParameterName = "@d", Value = tbD.Text.Trim()},
                new SqlParameter {ParameterName = "@da", Value = tbAnswer.Text.Trim().ToUpper()}
            };
            if (_model==null)
            {
                //新增
                MessageBox.Show(SqlHelper.ExecuteNonQuery("insert into ct (TG, A, B, C, D, DA) VALUES(@tg,@a,@b,@c,@d,@da)",param.ToArray()) > 0 ? "添加成功！" : "添加失败！");
            }
            else
            {
                param.Add(new SqlParameter{ParameterName = "@id",Value = _model.ID});
                //修改
                MessageBox.Show(SqlHelper.ExecuteNonQuery("update ct set tg=@tg,a=@a,b=@b,c=@c,d=@d,da=@da where id=@id", param.ToArray()) > 0 ? "修改成功！" : "修改失败！");
            }
            Close();
            ReloadDgv?.Invoke();//刷新父页面 dataGridView
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddOrEditForm_Load(object sender, EventArgs e)
        {
            if (_model == null) return;
            tbTg.Text = _model.TG;
            tbA.Text = _model.A;
            tbB.Text = _model.B;
            tbC.Text = _model.C;
            tbD.Text = _model.D;
            tbAnswer.Text = _model.DA;
        }
    }
}
