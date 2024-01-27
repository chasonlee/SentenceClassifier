using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroNetworkClassifier
{
	public partial class frmModelSetting : Form
	{
		frmMain mainForm = new frmMain();
		public frmModelSetting()
		{
			InitializeComponent();
		}
		public frmModelSetting(frmMain _mainForm)
		{
			InitializeComponent();
			mainForm = _mainForm;
			txtModelTmpName.Text = mainForm.model_tmp_filename;
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (txtModelTmpName.Text == "")
			{
				MessageBox.Show("请输入文件名！", "提示");
				return;
			}
			mainForm.model_tmp_filename = txtModelTmpName.Text;
			this.Dispose();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

	}
}
