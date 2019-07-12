using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using TestSystem.Common;
using TestSystem.Model;

namespace TestSystem
{
    public partial class QuestionListForm : Form
    {
        public QuestionListForm()
        {
            InitializeComponent();
        }

        private void QuestionListForm_Load(object sender, EventArgs e)
        {
            dgvQuestions.DataSource = SqlHelper.ExecuteDataTable("select * from ct");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           var child=  new AddOrEditForm {StartPosition = FormStartPosition.CenterParent, Text = @"添加"};
            child.ReloadDgv += Child_ReloadDgv;
            child.ShowDialog(this);
        }

        private void Child_ReloadDgv()
        {
            dgvQuestions.DataSource = SqlHelper.ExecuteDataTable("select * from ct");
            if (dgvQuestions.InvokeRequired)
            {
                dgvQuestions.Invoke(new Action(() => dgvQuestions.Refresh()));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvQuestions.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show(@"未选中任何行！");
                return;
            }

            var index = selectedRow.Index;
            var cells = dgvQuestions.Rows[index].Cells;
            var model = new Ct((int) cells["id"].Value, cells["tg"].Value.ToString(), cells["a"].Value.ToString(),
                cells["b"].Value.ToString(), cells["c"].Value.ToString(), cells["d"].Value.ToString(),
                cells["da"].Value.ToString());
            var child = new AddOrEditForm(model) { StartPosition = FormStartPosition.CenterParent, Text = @"修改" };
            child.ReloadDgv += Child_ReloadDgv;
            child.ShowDialog(this);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvQuestions.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show(@"未选中任何行！");
                return;
            }

            var index = selectedRow.Index;
            var id =(int) dgvQuestions.Rows[index].Cells["id"].Value;
            if (SqlHelper.ExecuteNonQuery("delete from ct where id=@id",
                    new SqlParameter { ParameterName = "@id", Value = id }) > 0)
            {
                MessageBox.Show(@"删除成功");
                Child_ReloadDgv();
            }
            else
            {
                MessageBox.Show(@"删除失败!");
            }
        }
    }
}
