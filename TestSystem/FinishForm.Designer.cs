namespace TestSystem
{
    partial class FinishForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblTotalMin = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTopScore = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(136, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(62, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("宋体", 12F);
            this.lblEndTime.Location = new System.Drawing.Point(136, 56);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(56, 16);
            this.lblEndTime.TabIndex = 1;
            this.lblEndTime.Text = "label2";
            // 
            // lblTotalMin
            // 
            this.lblTotalMin.AutoSize = true;
            this.lblTotalMin.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTotalMin.Location = new System.Drawing.Point(136, 88);
            this.lblTotalMin.Name = "lblTotalMin";
            this.lblTotalMin.Size = new System.Drawing.Size(56, 16);
            this.lblTotalMin.TabIndex = 2;
            this.lblTotalMin.Text = "label3";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("宋体", 12F);
            this.lblScore.Location = new System.Drawing.Point(136, 120);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(56, 16);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "label4";
            // 
            // lblTopScore
            // 
            this.lblTopScore.AutoSize = true;
            this.lblTopScore.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTopScore.Location = new System.Drawing.Point(136, 154);
            this.lblTopScore.Name = "lblTopScore";
            this.lblTopScore.Size = new System.Drawing.Size(56, 16);
            this.lblTopScore.TabIndex = 4;
            this.lblTopScore.Text = "label5";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(185, 204);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 47);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "确 定";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FinishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 318);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTopScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblTotalMin);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblTitle);
            this.Name = "FinishForm";
            this.Text = "测试结果";
            this.Load += new System.EventHandler(this.FinishForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblTotalMin;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTopScore;
        private System.Windows.Forms.Button btnExit;
    }
}