using System;
using System.Windows.Forms;

namespace TestSystem
{
    public partial class MDIParent : Form
    {
        public Form Main { get; set; }
        public Form QuestionListForm { get; set; }
        public ToolStripMenuItem LoginMenuItem { get; set; }
        public ToolStripMenuItem LogoutMenuItem { get; set; }

        public MDIParent()
        {
            InitializeComponent();
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            var childForm = new Main {MdiParent = this,WindowState = FormWindowState.Maximized};
            childForm.Show();
            Main = childForm;
            LoginMenuItem = loginMenuItem;
            LogoutMenuItem = logoutMenuItem;
            logoutMenuItem.Enabled = false;
        }

        private void 管理员登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LoginForm {StartPosition = FormStartPosition.CenterParent}.ShowDialog(this);
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionListForm.Close();
            var childForm = new Main {MdiParent = this,WindowState = FormWindowState.Maximized};
            childForm.Show();
            Main = childForm;
            loginMenuItem.Enabled = true;
            logoutMenuItem.Enabled = false;
        }
    }
}
