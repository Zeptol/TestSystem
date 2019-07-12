using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TestSystem.Common;
using TestSystem.Model;

namespace TestSystem
{
    public partial class Main : Form
    {
        private readonly string _title = "常识知识测验--共 {0} 题，当前是第 {1} 题，";
        private readonly string _time = "已用时 {0} 分 {1} 秒";
        private static int _currentIndex; //当前题目
        private static List<Ct> _list;
        private static string[] _answers;
        private Thread _thread;
        private Stopwatch _sw;
        public Main()
        {
            InitializeComponent();
            _list = new List<Ct>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_list.Any()) {return;}
            MessageBox.Show(@"题库中无题目，请先添加题目！");
            new LoginForm { StartPosition = FormStartPosition.CenterScreen }.Show(Parent);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var dt = SqlHelper.ExecuteDataTable("select * from ct");
            if (dt.Rows.Count == 0)
            {
                mainPanel.Hide();
            }
            else
            {
                _list = dt.ToList<Ct>();
                _answers = new string[_list.Count];
                var first = _list.First();
                lblQuestion.Text = first.TG;
                rb1.Text = first.A;
                rb2.Text = first.B;
                rb3.Text = first.C;
                rb4.Text = first.D;
                _currentIndex = 0;
                lblTitle.Text = string.Format(_title, _list.Count, _currentIndex);
                _thread = new Thread(Ticks);
                _thread.Start();
            }
        }

        private void Ticks()
        {
            _sw = new Stopwatch();
            _sw.Start();
            while (true)
            {
                var totalSecs = _sw.ElapsedMilliseconds / 1000;
                if (InvokeRequired)
                {
                    lblTime.Invoke((MethodInvoker)(() =>
                        lblTime.Text = string.Format(_time, totalSecs / 60, totalSecs % 60)));
                }
                else
                {
                    lblTime.Text = string.Format(_time, totalSecs / 60, totalSecs % 60);
                }
                Thread.Sleep(1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var first = _list.First();
            lblQuestion.Text = first.TG;
            rb1.Text = first.A;
            rb2.Text = first.B;
            rb3.Text = first.C;
            rb4.Text = first.D;
            _currentIndex = 1;
            lblTitle.Text = string.Format(_title, _list.Count, _currentIndex);
            Text = @"第1题";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_currentIndex==1)
            {
               return;
            }
            lblTitle.Text = string.Format(_title, _list.Count, --_currentIndex);
            var q = _list[_currentIndex-1];
            lblQuestion.Text = q.TG;
            rb1.Text = q.A;
            rb2.Text = q.B;
            rb3.Text = q.C;
            rb4.Text = q.D;
            Text = @"第" + _currentIndex + @"题";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentIndex == _list.Count)
            {
                MessageBox.Show(@"已经是最后一题！");
                return;
            }
            lblTitle.Text = string.Format(_title, _list.Count, ++_currentIndex);
            var q = _list[_currentIndex - 1];
            lblQuestion.Text = q.TG;
            rb1.Text = q.A;
            rb2.Text = q.B;
            rb3.Text = q.C;
            rb4.Text = q.D;
            Text = @"第" + _currentIndex + @"题";
            var answer = "";
            if (rb1.Checked)
            {
                answer = "A";
            }
            if (rb2.Checked)
            {
                answer = "B";
            }
            if (rb3.Checked)
            {
                answer = "C";
            }
            if (rb4.Checked)
            {
                answer = "D";
            }
            _answers[_currentIndex - 1] = answer;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var correctAnswers = _list.Select(t => t.DA).ToList();
            var intersect = _answers.Intersect(correctAnswers).ToList();
            var inputForm = new InputForm((double)intersect.Count * 100 / correctAnswers.Count)
                {StartPosition = FormStartPosition.CenterParent};
            inputForm.StopThread += InputForm_StopThread;
            inputForm.ShowDialog(this);
        }

        private long InputForm_StopThread()
        {
            _sw.Stop();
            _thread.Abort();
            return _sw.ElapsedMilliseconds / 60000;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            InputForm_StopThread();
        }

        private void RbClick(string answer)
        {
            if (_currentIndex > 0)
            {
                _answers[_currentIndex - 1] = answer;
            }
            if (_currentIndex == _list.Count)
            {
                //最后一题
                btnSubmit_Click(null, null);
            }
            else
            {
                btnNext_Click(null, null);
            }
        }
        private void rb1_Click(object sender, EventArgs e)
        {
            RbClick("A");
        }

        private void rb2_Click(object sender, EventArgs e)
        {
            RbClick("B");
        }

        private void rb3_Click(object sender, EventArgs e)
        {
            RbClick("C");
        }

        private void rb4_Click(object sender, EventArgs e)
        {
            RbClick("D");
        }
    }
}
