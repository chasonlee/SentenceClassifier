namespace NeuroNetworkClassifier
{
	partial class frmMain
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.btnTrainingModel = new System.Windows.Forms.Button();
			this.btnModelPerformance = new System.Windows.Forms.Button();
			this.btnContinueTraining = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnModelSetting = new System.Windows.Forms.Button();
			this.btnDraw = new System.Windows.Forms.Button();
			this.btnSaveMap = new System.Windows.Forms.Button();
			this.btnSaveModel = new System.Windows.Forms.Button();
			this.ssrModelStatus = new System.Windows.Forms.StatusStrip();
			this.ssrLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnStopTraining = new System.Windows.Forms.Button();
			this.btnLoadModel = new System.Windows.Forms.Button();
			this.btnLoadMap = new System.Windows.Forms.Button();
			this.btnLoadDataset = new System.Windows.Forms.Button();
			this.btnLoadWordVec = new System.Windows.Forms.Button();
			this.lstMessage = new System.Windows.Forms.ListBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnSaveModel_2 = new System.Windows.Forms.Button();
			this.ssrModelStatus_2 = new System.Windows.Forms.StatusStrip();
			this.ssrLabel_2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnStopTraining_2 = new System.Windows.Forms.Button();
			this.btnLoadModel_2 = new System.Windows.Forms.Button();
			this.btnGetMap_2 = new System.Windows.Forms.Button();
			this.btnLoadDataset_2 = new System.Windows.Forms.Button();
			this.btnLoadWordVec_2 = new System.Windows.Forms.Button();
			this.lstMessage_2 = new System.Windows.Forms.ListBox();
			this.btnContinueTraining_2 = new System.Windows.Forms.Button();
			this.btnTrainingModel_2 = new System.Windows.Forms.Button();
			this.btnModelPerformance_2 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnSaveModel_3 = new System.Windows.Forms.Button();
			this.ssrModelStatus_3 = new System.Windows.Forms.StatusStrip();
			this.ssrLabel_3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnStopTraining_3 = new System.Windows.Forms.Button();
			this.btnLoadModel_3 = new System.Windows.Forms.Button();
			this.btnGetMap_3 = new System.Windows.Forms.Button();
			this.btnLoadDataset_3 = new System.Windows.Forms.Button();
			this.btnLoadWordVec_3 = new System.Windows.Forms.Button();
			this.lstMessage_3 = new System.Windows.Forms.ListBox();
			this.btnContinueTraining_3 = new System.Windows.Forms.Button();
			this.btnTrainingModel_3 = new System.Windows.Forms.Button();
			this.btnModelPerformance_3 = new System.Windows.Forms.Button();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lstModelOutput = new System.Windows.Forms.ListBox();
			this.txtModelInput = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			this.ssrModelStatus.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.ssrModelStatus_2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.ssrModelStatus_3.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnTrainingModel
			// 
			this.btnTrainingModel.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnTrainingModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTrainingModel.Location = new System.Drawing.Point(218, 422);
			this.btnTrainingModel.Name = "btnTrainingModel";
			this.btnTrainingModel.Size = new System.Drawing.Size(91, 31);
			this.btnTrainingModel.TabIndex = 10;
			this.btnTrainingModel.Text = "训练新模型";
			this.btnTrainingModel.UseVisualStyleBackColor = false;
			this.btnTrainingModel.Click += new System.EventHandler(this.btnTrainingModel_Click);
			// 
			// btnModelPerformance
			// 
			this.btnModelPerformance.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnModelPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnModelPerformance.Location = new System.Drawing.Point(431, 422);
			this.btnModelPerformance.Name = "btnModelPerformance";
			this.btnModelPerformance.Size = new System.Drawing.Size(91, 31);
			this.btnModelPerformance.TabIndex = 11;
			this.btnModelPerformance.Text = "验证模型";
			this.btnModelPerformance.UseVisualStyleBackColor = false;
			this.btnModelPerformance.Click += new System.EventHandler(this.btnModelPerformance_Click);
			// 
			// btnContinueTraining
			// 
			this.btnContinueTraining.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnContinueTraining.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnContinueTraining.Location = new System.Drawing.Point(218, 459);
			this.btnContinueTraining.Name = "btnContinueTraining";
			this.btnContinueTraining.Size = new System.Drawing.Size(91, 31);
			this.btnContinueTraining.TabIndex = 12;
			this.btnContinueTraining.Text = "继续训练模型";
			this.btnContinueTraining.UseVisualStyleBackColor = false;
			this.btnContinueTraining.Click += new System.EventHandler(this.btnContinueTraining_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnModelSetting);
			this.groupBox1.Controls.Add(this.btnDraw);
			this.groupBox1.Controls.Add(this.btnSaveMap);
			this.groupBox1.Controls.Add(this.btnSaveModel);
			this.groupBox1.Controls.Add(this.ssrModelStatus);
			this.groupBox1.Controls.Add(this.btnStopTraining);
			this.groupBox1.Controls.Add(this.btnLoadModel);
			this.groupBox1.Controls.Add(this.btnLoadMap);
			this.groupBox1.Controls.Add(this.btnLoadDataset);
			this.groupBox1.Controls.Add(this.btnLoadWordVec);
			this.groupBox1.Controls.Add(this.lstMessage);
			this.groupBox1.Controls.Add(this.btnContinueTraining);
			this.groupBox1.Controls.Add(this.btnTrainingModel);
			this.groupBox1.Controls.Add(this.btnModelPerformance);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(528, 524);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "仅包含词向量的模型";
			// 
			// btnModelSetting
			// 
			this.btnModelSetting.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnModelSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnModelSetting.Location = new System.Drawing.Point(163, 422);
			this.btnModelSetting.Name = "btnModelSetting";
			this.btnModelSetting.Size = new System.Drawing.Size(49, 68);
			this.btnModelSetting.TabIndex = 24;
			this.btnModelSetting.Text = "模型      设置";
			this.btnModelSetting.UseVisualStyleBackColor = false;
			this.btnModelSetting.Click += new System.EventHandler(this.btnModelSetting_Click);
			// 
			// btnDraw
			// 
			this.btnDraw.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDraw.Location = new System.Drawing.Point(431, 459);
			this.btnDraw.Name = "btnDraw";
			this.btnDraw.Size = new System.Drawing.Size(91, 31);
			this.btnDraw.TabIndex = 23;
			this.btnDraw.Text = "误差曲线图";
			this.btnDraw.UseVisualStyleBackColor = false;
			this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
			// 
			// btnSaveMap
			// 
			this.btnSaveMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnSaveMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSaveMap.Location = new System.Drawing.Point(6, 172);
			this.btnSaveMap.Name = "btnSaveMap";
			this.btnSaveMap.Size = new System.Drawing.Size(91, 31);
			this.btnSaveMap.TabIndex = 22;
			this.btnSaveMap.Text = "保存映射表";
			this.btnSaveMap.UseVisualStyleBackColor = false;
			this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
			// 
			// btnSaveModel
			// 
			this.btnSaveModel.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnSaveModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSaveModel.Location = new System.Drawing.Point(6, 459);
			this.btnSaveModel.Name = "btnSaveModel";
			this.btnSaveModel.Size = new System.Drawing.Size(91, 31);
			this.btnSaveModel.TabIndex = 21;
			this.btnSaveModel.Text = "保存模型";
			this.btnSaveModel.UseVisualStyleBackColor = false;
			this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
			// 
			// ssrModelStatus
			// 
			this.ssrModelStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssrLabel});
			this.ssrModelStatus.Location = new System.Drawing.Point(3, 499);
			this.ssrModelStatus.Name = "ssrModelStatus";
			this.ssrModelStatus.Size = new System.Drawing.Size(522, 22);
			this.ssrModelStatus.TabIndex = 19;
			// 
			// ssrLabel
			// 
			this.ssrLabel.Name = "ssrLabel";
			this.ssrLabel.Size = new System.Drawing.Size(44, 17);
			this.ssrLabel.Text = "状态：";
			// 
			// btnStopTraining
			// 
			this.btnStopTraining.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnStopTraining.Enabled = false;
			this.btnStopTraining.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStopTraining.Location = new System.Drawing.Point(315, 422);
			this.btnStopTraining.Name = "btnStopTraining";
			this.btnStopTraining.Size = new System.Drawing.Size(49, 68);
			this.btnStopTraining.TabIndex = 18;
			this.btnStopTraining.Text = "停止      训练";
			this.btnStopTraining.UseVisualStyleBackColor = false;
			this.btnStopTraining.Click += new System.EventHandler(this.btnStopTraining_Click);
			// 
			// btnLoadModel
			// 
			this.btnLoadModel.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadModel.Location = new System.Drawing.Point(6, 422);
			this.btnLoadModel.Name = "btnLoadModel";
			this.btnLoadModel.Size = new System.Drawing.Size(91, 31);
			this.btnLoadModel.TabIndex = 17;
			this.btnLoadModel.Text = "加载模型";
			this.btnLoadModel.UseVisualStyleBackColor = false;
			this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
			// 
			// btnLoadMap
			// 
			this.btnLoadMap.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadMap.Location = new System.Drawing.Point(6, 135);
			this.btnLoadMap.Name = "btnLoadMap";
			this.btnLoadMap.Size = new System.Drawing.Size(91, 31);
			this.btnLoadMap.TabIndex = 16;
			this.btnLoadMap.Text = "加载映射表";
			this.btnLoadMap.UseVisualStyleBackColor = false;
			this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
			// 
			// btnLoadDataset
			// 
			this.btnLoadDataset.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadDataset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadDataset.Location = new System.Drawing.Point(6, 72);
			this.btnLoadDataset.Name = "btnLoadDataset";
			this.btnLoadDataset.Size = new System.Drawing.Size(91, 31);
			this.btnLoadDataset.TabIndex = 15;
			this.btnLoadDataset.Text = "加载数据集";
			this.btnLoadDataset.UseVisualStyleBackColor = false;
			this.btnLoadDataset.Click += new System.EventHandler(this.btnLoadDataset_Click);
			// 
			// btnLoadWordVec
			// 
			this.btnLoadWordVec.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadWordVec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadWordVec.Location = new System.Drawing.Point(6, 35);
			this.btnLoadWordVec.Name = "btnLoadWordVec";
			this.btnLoadWordVec.Size = new System.Drawing.Size(91, 31);
			this.btnLoadWordVec.TabIndex = 14;
			this.btnLoadWordVec.Text = "加载词向量";
			this.btnLoadWordVec.UseVisualStyleBackColor = false;
			this.btnLoadWordVec.Click += new System.EventHandler(this.btnLoadWordVec_Click);
			// 
			// lstMessage
			// 
			this.lstMessage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lstMessage.FormattingEnabled = true;
			this.lstMessage.HorizontalScrollbar = true;
			this.lstMessage.ItemHeight = 14;
			this.lstMessage.Location = new System.Drawing.Point(103, 20);
			this.lstMessage.Name = "lstMessage";
			this.lstMessage.Size = new System.Drawing.Size(419, 396);
			this.lstMessage.TabIndex = 13;
			this.lstMessage.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstMessage_DrawItem);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Controls.Add(this.tabPage3);
			this.tabControl.Controls.Add(this.tabPage5);
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(548, 560);
			this.tabControl.TabIndex = 15;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(540, 534);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "词向量模型";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(540, 534);
			this.tabPage2.TabIndex = 2;
			this.tabPage2.Text = "词性标注模型";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnSaveModel_2);
			this.groupBox3.Controls.Add(this.ssrModelStatus_2);
			this.groupBox3.Controls.Add(this.btnStopTraining_2);
			this.groupBox3.Controls.Add(this.btnLoadModel_2);
			this.groupBox3.Controls.Add(this.btnGetMap_2);
			this.groupBox3.Controls.Add(this.btnLoadDataset_2);
			this.groupBox3.Controls.Add(this.btnLoadWordVec_2);
			this.groupBox3.Controls.Add(this.lstMessage_2);
			this.groupBox3.Controls.Add(this.btnContinueTraining_2);
			this.groupBox3.Controls.Add(this.btnTrainingModel_2);
			this.groupBox3.Controls.Add(this.btnModelPerformance_2);
			this.groupBox3.Location = new System.Drawing.Point(6, 5);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(528, 524);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "包含词向量、词性标注的模型";
			// 
			// btnSaveModel_2
			// 
			this.btnSaveModel_2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnSaveModel_2.Location = new System.Drawing.Point(6, 202);
			this.btnSaveModel_2.Name = "btnSaveModel_2";
			this.btnSaveModel_2.Size = new System.Drawing.Size(91, 31);
			this.btnSaveModel_2.TabIndex = 21;
			this.btnSaveModel_2.Text = "保存模型";
			this.btnSaveModel_2.UseVisualStyleBackColor = false;
			// 
			// ssrModelStatus_2
			// 
			this.ssrModelStatus_2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssrLabel_2});
			this.ssrModelStatus_2.Location = new System.Drawing.Point(3, 499);
			this.ssrModelStatus_2.Name = "ssrModelStatus_2";
			this.ssrModelStatus_2.Size = new System.Drawing.Size(522, 22);
			this.ssrModelStatus_2.TabIndex = 19;
			// 
			// ssrLabel_2
			// 
			this.ssrLabel_2.Name = "ssrLabel_2";
			this.ssrLabel_2.Size = new System.Drawing.Size(44, 17);
			this.ssrLabel_2.Text = "状态：";
			// 
			// btnStopTraining_2
			// 
			this.btnStopTraining_2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnStopTraining_2.Enabled = false;
			this.btnStopTraining_2.Location = new System.Drawing.Point(6, 347);
			this.btnStopTraining_2.Name = "btnStopTraining_2";
			this.btnStopTraining_2.Size = new System.Drawing.Size(91, 31);
			this.btnStopTraining_2.TabIndex = 18;
			this.btnStopTraining_2.Text = "停止训练";
			this.btnStopTraining_2.UseVisualStyleBackColor = false;
			this.btnStopTraining_2.Click += new System.EventHandler(this.btnStopTraining_2_Click);
			// 
			// btnLoadModel_2
			// 
			this.btnLoadModel_2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadModel_2.Location = new System.Drawing.Point(6, 165);
			this.btnLoadModel_2.Name = "btnLoadModel_2";
			this.btnLoadModel_2.Size = new System.Drawing.Size(91, 31);
			this.btnLoadModel_2.TabIndex = 17;
			this.btnLoadModel_2.Text = "加载模型";
			this.btnLoadModel_2.UseVisualStyleBackColor = false;
			// 
			// btnGetMap_2
			// 
			this.btnGetMap_2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnGetMap_2.Location = new System.Drawing.Point(6, 94);
			this.btnGetMap_2.Name = "btnGetMap_2";
			this.btnGetMap_2.Size = new System.Drawing.Size(91, 31);
			this.btnGetMap_2.TabIndex = 16;
			this.btnGetMap_2.Text = "生成映射表";
			this.btnGetMap_2.UseVisualStyleBackColor = false;
			this.btnGetMap_2.Click += new System.EventHandler(this.btnGetMap_2_Click);
			// 
			// btnLoadDataset_2
			// 
			this.btnLoadDataset_2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadDataset_2.Location = new System.Drawing.Point(6, 57);
			this.btnLoadDataset_2.Name = "btnLoadDataset_2";
			this.btnLoadDataset_2.Size = new System.Drawing.Size(91, 31);
			this.btnLoadDataset_2.TabIndex = 15;
			this.btnLoadDataset_2.Text = "加载数据集";
			this.btnLoadDataset_2.UseVisualStyleBackColor = false;
			this.btnLoadDataset_2.Click += new System.EventHandler(this.btnLoadDataset_2_Click);
			// 
			// btnLoadWordVec_2
			// 
			this.btnLoadWordVec_2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadWordVec_2.Location = new System.Drawing.Point(6, 20);
			this.btnLoadWordVec_2.Name = "btnLoadWordVec_2";
			this.btnLoadWordVec_2.Size = new System.Drawing.Size(91, 31);
			this.btnLoadWordVec_2.TabIndex = 14;
			this.btnLoadWordVec_2.Text = "加载词向量";
			this.btnLoadWordVec_2.UseVisualStyleBackColor = false;
			this.btnLoadWordVec_2.Click += new System.EventHandler(this.btnLoadWordVec_Click);
			// 
			// lstMessage_2
			// 
			this.lstMessage_2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lstMessage_2.FormattingEnabled = true;
			this.lstMessage_2.HorizontalScrollbar = true;
			this.lstMessage_2.ItemHeight = 14;
			this.lstMessage_2.Location = new System.Drawing.Point(103, 20);
			this.lstMessage_2.Name = "lstMessage_2";
			this.lstMessage_2.Size = new System.Drawing.Size(419, 466);
			this.lstMessage_2.TabIndex = 13;
			// 
			// btnContinueTraining_2
			// 
			this.btnContinueTraining_2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnContinueTraining_2.Location = new System.Drawing.Point(6, 310);
			this.btnContinueTraining_2.Name = "btnContinueTraining_2";
			this.btnContinueTraining_2.Size = new System.Drawing.Size(91, 31);
			this.btnContinueTraining_2.TabIndex = 12;
			this.btnContinueTraining_2.Text = "继续训练模型";
			this.btnContinueTraining_2.UseVisualStyleBackColor = false;
			// 
			// btnTrainingModel_2
			// 
			this.btnTrainingModel_2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnTrainingModel_2.Location = new System.Drawing.Point(6, 273);
			this.btnTrainingModel_2.Name = "btnTrainingModel_2";
			this.btnTrainingModel_2.Size = new System.Drawing.Size(91, 31);
			this.btnTrainingModel_2.TabIndex = 10;
			this.btnTrainingModel_2.Text = "训练新模型";
			this.btnTrainingModel_2.UseVisualStyleBackColor = false;
			// 
			// btnModelPerformance_2
			// 
			this.btnModelPerformance_2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnModelPerformance_2.Location = new System.Drawing.Point(6, 411);
			this.btnModelPerformance_2.Name = "btnModelPerformance_2";
			this.btnModelPerformance_2.Size = new System.Drawing.Size(91, 31);
			this.btnModelPerformance_2.TabIndex = 11;
			this.btnModelPerformance_2.Text = "验证模型性能";
			this.btnModelPerformance_2.UseVisualStyleBackColor = false;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(540, 534);
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Text = "角色标注模型";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnSaveModel_3);
			this.groupBox4.Controls.Add(this.ssrModelStatus_3);
			this.groupBox4.Controls.Add(this.btnStopTraining_3);
			this.groupBox4.Controls.Add(this.btnLoadModel_3);
			this.groupBox4.Controls.Add(this.btnGetMap_3);
			this.groupBox4.Controls.Add(this.btnLoadDataset_3);
			this.groupBox4.Controls.Add(this.btnLoadWordVec_3);
			this.groupBox4.Controls.Add(this.lstMessage_3);
			this.groupBox4.Controls.Add(this.btnContinueTraining_3);
			this.groupBox4.Controls.Add(this.btnTrainingModel_3);
			this.groupBox4.Controls.Add(this.btnModelPerformance_3);
			this.groupBox4.Location = new System.Drawing.Point(6, 5);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(528, 524);
			this.groupBox4.TabIndex = 14;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "包含词向量、词性标注、角色标注的模型";
			// 
			// btnSaveModel_3
			// 
			this.btnSaveModel_3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnSaveModel_3.Location = new System.Drawing.Point(6, 202);
			this.btnSaveModel_3.Name = "btnSaveModel_3";
			this.btnSaveModel_3.Size = new System.Drawing.Size(91, 31);
			this.btnSaveModel_3.TabIndex = 21;
			this.btnSaveModel_3.Text = "保存模型";
			this.btnSaveModel_3.UseVisualStyleBackColor = false;
			// 
			// ssrModelStatus_3
			// 
			this.ssrModelStatus_3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssrLabel_3});
			this.ssrModelStatus_3.Location = new System.Drawing.Point(3, 499);
			this.ssrModelStatus_3.Name = "ssrModelStatus_3";
			this.ssrModelStatus_3.Size = new System.Drawing.Size(522, 22);
			this.ssrModelStatus_3.TabIndex = 19;
			// 
			// ssrLabel_3
			// 
			this.ssrLabel_3.Name = "ssrLabel_3";
			this.ssrLabel_3.Size = new System.Drawing.Size(44, 17);
			this.ssrLabel_3.Text = "状态：";
			// 
			// btnStopTraining_3
			// 
			this.btnStopTraining_3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnStopTraining_3.Enabled = false;
			this.btnStopTraining_3.Location = new System.Drawing.Point(6, 347);
			this.btnStopTraining_3.Name = "btnStopTraining_3";
			this.btnStopTraining_3.Size = new System.Drawing.Size(91, 31);
			this.btnStopTraining_3.TabIndex = 18;
			this.btnStopTraining_3.Text = "停止训练";
			this.btnStopTraining_3.UseVisualStyleBackColor = false;
			// 
			// btnLoadModel_3
			// 
			this.btnLoadModel_3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadModel_3.Location = new System.Drawing.Point(6, 165);
			this.btnLoadModel_3.Name = "btnLoadModel_3";
			this.btnLoadModel_3.Size = new System.Drawing.Size(91, 31);
			this.btnLoadModel_3.TabIndex = 17;
			this.btnLoadModel_3.Text = "加载模型";
			this.btnLoadModel_3.UseVisualStyleBackColor = false;
			// 
			// btnGetMap_3
			// 
			this.btnGetMap_3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnGetMap_3.Location = new System.Drawing.Point(6, 94);
			this.btnGetMap_3.Name = "btnGetMap_3";
			this.btnGetMap_3.Size = new System.Drawing.Size(91, 31);
			this.btnGetMap_3.TabIndex = 16;
			this.btnGetMap_3.Text = "生成映射表";
			this.btnGetMap_3.UseVisualStyleBackColor = false;
			// 
			// btnLoadDataset_3
			// 
			this.btnLoadDataset_3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadDataset_3.Location = new System.Drawing.Point(6, 57);
			this.btnLoadDataset_3.Name = "btnLoadDataset_3";
			this.btnLoadDataset_3.Size = new System.Drawing.Size(91, 31);
			this.btnLoadDataset_3.TabIndex = 15;
			this.btnLoadDataset_3.Text = "加载数据集";
			this.btnLoadDataset_3.UseVisualStyleBackColor = false;
			// 
			// btnLoadWordVec_3
			// 
			this.btnLoadWordVec_3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnLoadWordVec_3.Location = new System.Drawing.Point(6, 20);
			this.btnLoadWordVec_3.Name = "btnLoadWordVec_3";
			this.btnLoadWordVec_3.Size = new System.Drawing.Size(91, 31);
			this.btnLoadWordVec_3.TabIndex = 14;
			this.btnLoadWordVec_3.Text = "加载词向量";
			this.btnLoadWordVec_3.UseVisualStyleBackColor = false;
			this.btnLoadWordVec_3.Click += new System.EventHandler(this.btnLoadWordVec_Click);
			// 
			// lstMessage_3
			// 
			this.lstMessage_3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lstMessage_3.FormattingEnabled = true;
			this.lstMessage_3.HorizontalScrollbar = true;
			this.lstMessage_3.ItemHeight = 14;
			this.lstMessage_3.Location = new System.Drawing.Point(103, 20);
			this.lstMessage_3.Name = "lstMessage_3";
			this.lstMessage_3.Size = new System.Drawing.Size(419, 466);
			this.lstMessage_3.TabIndex = 13;
			// 
			// btnContinueTraining_3
			// 
			this.btnContinueTraining_3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnContinueTraining_3.Location = new System.Drawing.Point(6, 310);
			this.btnContinueTraining_3.Name = "btnContinueTraining_3";
			this.btnContinueTraining_3.Size = new System.Drawing.Size(91, 31);
			this.btnContinueTraining_3.TabIndex = 12;
			this.btnContinueTraining_3.Text = "继续训练模型";
			this.btnContinueTraining_3.UseVisualStyleBackColor = false;
			// 
			// btnTrainingModel_3
			// 
			this.btnTrainingModel_3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnTrainingModel_3.Location = new System.Drawing.Point(6, 273);
			this.btnTrainingModel_3.Name = "btnTrainingModel_3";
			this.btnTrainingModel_3.Size = new System.Drawing.Size(91, 31);
			this.btnTrainingModel_3.TabIndex = 10;
			this.btnTrainingModel_3.Text = "训练新模型";
			this.btnTrainingModel_3.UseVisualStyleBackColor = false;
			// 
			// btnModelPerformance_3
			// 
			this.btnModelPerformance_3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnModelPerformance_3.Location = new System.Drawing.Point(6, 411);
			this.btnModelPerformance_3.Name = "btnModelPerformance_3";
			this.btnModelPerformance_3.Size = new System.Drawing.Size(91, 31);
			this.btnModelPerformance_3.TabIndex = 11;
			this.btnModelPerformance_3.Text = "验证模型性能";
			this.btnModelPerformance_3.UseVisualStyleBackColor = false;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.groupBox2);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(540, 534);
			this.tabPage5.TabIndex = 1;
			this.tabPage5.Text = "单句操作";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lstModelOutput);
			this.groupBox2.Controls.Add(this.txtModelInput);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(528, 521);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "单句测试";
			// 
			// lstModelOutput
			// 
			this.lstModelOutput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lstModelOutput.FormattingEnabled = true;
			this.lstModelOutput.ItemHeight = 14;
			this.lstModelOutput.Location = new System.Drawing.Point(103, 20);
			this.lstModelOutput.Name = "lstModelOutput";
			this.lstModelOutput.Size = new System.Drawing.Size(419, 466);
			this.lstModelOutput.TabIndex = 2;
			// 
			// txtModelInput
			// 
			this.txtModelInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtModelInput.Location = new System.Drawing.Point(103, 492);
			this.txtModelInput.Name = "txtModelInput";
			this.txtModelInput.Size = new System.Drawing.Size(419, 23);
			this.txtModelInput.TabIndex = 1;
			this.txtModelInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModelInput_KeyPress);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.pictureBox1);
			this.groupBox5.Location = new System.Drawing.Point(562, 31);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(443, 541);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "模型性能图像";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(6, 20);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(430, 510);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(1017, 575);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.tabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "基于神经网络的句子分类模型";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ssrModelStatus.ResumeLayout(false);
			this.ssrModelStatus.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ssrModelStatus_2.ResumeLayout(false);
			this.ssrModelStatus_2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ssrModelStatus_3.ResumeLayout(false);
			this.ssrModelStatus_3.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnTrainingModel;
		private System.Windows.Forms.Button btnModelPerformance;
		private System.Windows.Forms.Button btnContinueTraining;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox lstMessage;
		private System.Windows.Forms.Button btnLoadWordVec;
		private System.Windows.Forms.Button btnLoadDataset;
		private System.Windows.Forms.Button btnLoadMap;
		private System.Windows.Forms.Button btnLoadModel;
		private System.Windows.Forms.Button btnStopTraining;
		private System.Windows.Forms.StatusStrip ssrModelStatus;
		private System.Windows.Forms.ToolStripStatusLabel ssrLabel;
		private System.Windows.Forms.Button btnSaveModel;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtModelInput;
		private System.Windows.Forms.ListBox lstModelOutput;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnSaveModel_2;
		private System.Windows.Forms.StatusStrip ssrModelStatus_2;
		private System.Windows.Forms.ToolStripStatusLabel ssrLabel_2;
		private System.Windows.Forms.Button btnStopTraining_2;
		private System.Windows.Forms.Button btnLoadModel_2;
		private System.Windows.Forms.Button btnGetMap_2;
		private System.Windows.Forms.Button btnLoadDataset_2;
		private System.Windows.Forms.Button btnLoadWordVec_2;
		private System.Windows.Forms.ListBox lstMessage_2;
		private System.Windows.Forms.Button btnContinueTraining_2;
		private System.Windows.Forms.Button btnTrainingModel_2;
		private System.Windows.Forms.Button btnModelPerformance_2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnSaveModel_3;
		private System.Windows.Forms.StatusStrip ssrModelStatus_3;
		private System.Windows.Forms.ToolStripStatusLabel ssrLabel_3;
		private System.Windows.Forms.Button btnStopTraining_3;
		private System.Windows.Forms.Button btnLoadModel_3;
		private System.Windows.Forms.Button btnGetMap_3;
		private System.Windows.Forms.Button btnLoadDataset_3;
		private System.Windows.Forms.Button btnLoadWordVec_3;
		private System.Windows.Forms.ListBox lstMessage_3;
		private System.Windows.Forms.Button btnContinueTraining_3;
		private System.Windows.Forms.Button btnTrainingModel_3;
		private System.Windows.Forms.Button btnModelPerformance_3;
		private System.Windows.Forms.Button btnSaveMap;
		private System.Windows.Forms.Button btnDraw;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnModelSetting;
	}
}

