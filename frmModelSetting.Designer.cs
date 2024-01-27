namespace NeuroNetworkClassifier
{
	partial class frmModelSetting
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtModelTmpName = new System.Windows.Forms.TextBox();
			this.btnConfirm = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "模型临时保存文件名:";
			// 
			// txtModelTmpName
			// 
			this.txtModelTmpName.Location = new System.Drawing.Point(137, 20);
			this.txtModelTmpName.Name = "txtModelTmpName";
			this.txtModelTmpName.Size = new System.Drawing.Size(203, 21);
			this.txtModelTmpName.TabIndex = 1;
			this.txtModelTmpName.Text = "Classifier.model";
			// 
			// btnConfirm
			// 
			this.btnConfirm.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConfirm.Location = new System.Drawing.Point(67, 67);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(75, 23);
			this.btnConfirm.TabIndex = 2;
			this.btnConfirm.Text = "确定";
			this.btnConfirm.UseVisualStyleBackColor = false;
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(208, 67);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmModelSetting
			// 
			this.AcceptButton = this.btnConfirm;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 115);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnConfirm);
			this.Controls.Add(this.txtModelTmpName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmModelSetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "模型设置";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtModelTmpName;
		private System.Windows.Forms.Button btnConfirm;
		private System.Windows.Forms.Button btnCancel;
	}
}