using System;
using System.Windows.Forms;
using TestSystem.Common;

namespace TestSystem
{
    public partial class FinishForm : Form
    {
        private readonly string _name;
        private readonly long? _totalMin;
        private readonly double _score;
        public FinishForm(string name, long? totalMin, double score)
        {
            _name = name;
            _totalMin = totalMin;
            _score = score;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FinishForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $@"知识测验-用户名：{_name}";
            lblEndTime.Text = $@"结束时间：{DateTime.Now:yyyy-MM-dd}";
            lblTotalMin.Text = $@"测试时间：{_totalMin}分钟";
            lblScore.Text = $@"得分：{_score}分";
            var topScore =(double) SqlHelper.ExecuteScalar("SELECT MAX(SCORE) FROM dbo.wtest");
            lblTopScore.Text = $@"系统最高分：{topScore}分";
        }
    }
}
