namespace NeuroNetworkClassifier
{
	partial class frmHiddenNum
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
			this.btnSubmit = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lvwNodes = new System.Windows.Forms.ListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnModify = new System.Windows.Forms.Button();
			this.btnDelNode = new System.Windows.Forms.Button();
			this.btnAddNode = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNodeNum = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSubmit
			// 
			this.btnSubmit.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnSubmit.Location = new System.Drawing.Point(113, 145);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(99, 40);
			this.btnSubmit.TabIndex = 2;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = false;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnCancel.Location = new System.Drawing.Point(262, 145);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(99, 40);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lvwNodes
			// 
			this.lvwNodes.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lvwNodes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
			this.lvwNodes.Location = new System.Drawing.Point(6, 20);
			this.lvwNodes.Name = "lvwNodes";
			this.lvwNodes.Size = new System.Drawing.Size(429, 51);
			this.lvwNodes.TabIndex = 4;
			this.lvwNodes.UseCompatibleStateImageBehavior = false;
			this.lvwNodes.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnModify);
			this.groupBox1.Controls.Add(this.btnDelNode);
			this.groupBox1.Controls.Add(this.btnAddNode);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtNodeNum);
			this.groupBox1.Controls.Add(this.lvwNodes);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(441, 112);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "隐藏层节点数设置";
			// 
			// btnModify
			// 
			this.btnModify.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnModify.Location = new System.Drawing.Point(171, 75);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(45, 28);
			this.btnModify.TabIndex = 9;
			this.btnModify.Text = "修改";
			this.btnModify.UseVisualStyleBackColor = false;
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnDelNode
			// 
			this.btnDelNode.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnDelNode.Location = new System.Drawing.Point(355, 75);
			this.btnDelNode.Name = "btnDelNode";
			this.btnDelNode.Size = new System.Drawing.Size(80, 28);
			this.btnDelNode.TabIndex = 8;
			this.btnDelNode.Text = "删除节点";
			this.btnDelNode.UseVisualStyleBackColor = false;
			this.btnDelNode.Click += new System.EventHandler(this.btnDelNode_Click);
			// 
			// btnAddNode
			// 
			this.btnAddNode.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnAddNode.Location = new System.Drawing.Point(269, 75);
			this.btnAddNode.Name = "btnAddNode";
			this.btnAddNode.Size = new System.Drawing.Size(80, 28);
			this.btnAddNode.TabIndex = 7;
			this.btnAddNode.Text = "添加节点";
			this.btnAddNode.UseVisualStyleBackColor = false;
			this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(6, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 14);
			this.label2.TabIndex = 6;
			this.label2.Text = "当前节点数：";
			// 
			// txtNodeNum
			// 
			this.txtNodeNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtNodeNum.Location = new System.Drawing.Point(103, 77);
			this.txtNodeNum.Name = "txtNodeNum";
			this.txtNodeNum.ReadOnly = true;
			this.txtNodeNum.Size = new System.Drawing.Size(62, 26);
			this.txtNodeNum.TabIndex = 5;
			this.txtNodeNum.TextChanged += new System.EventHandler(this.txtNodeNum_TextChanged);
			this.txtNodeNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNodeNum_KeyDown);
			// 
			// frmHiddenNum
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(465, 197);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSubmit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmHiddenNum";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "设置隐藏层节点数";
			this.Load += new System.EventHandler(this.frmSetHiddenNum_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListView lvwNodes;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNodeNum;
		private System.Windows.Forms.Button btnDelNode;
		private System.Windows.Forms.Button btnAddNode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnModify;
	}
}