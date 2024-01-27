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
	public partial class frmHiddenNum : Form
	{
		frmMain form1;

		public frmHiddenNum()
		{
			InitializeComponent(); 
		}

		public frmHiddenNum(frmMain _form1)
		{
			InitializeComponent();
			form1 = _form1;
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			form1.neuronsCount.Clear();
			for (int i = 1; i < lvwNodes.Items.Count; i++)
			{
				form1.neuronsCount.Add(int.Parse(lvwNodes.Items[i].Text));
			}

			//训练新模型
			form1.TrainNewModel();
			this.Dispose();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void frmSetHiddenNum_Load(object sender, EventArgs e)
		{
			this.lvwNodes.Columns.Add("隐藏层节点", 200, HorizontalAlignment.Left); //一步添加 

			this.lvwNodes.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  

			ListViewItem lvi = new ListViewItem();

			lvi.ImageIndex = 0;     //通过与imageList绑定，显示imageList中第i项图标  

			lvi.Text = "10";

			this.lvwNodes.Items.Add(lvi);

			this.lvwNodes.EndUpdate();  //结束数据处理，UI界面一次性绘制。
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvwNodes.SelectedIndices.Count == 1)
			{
				txtNodeNum.ReadOnly = false;
				txtNodeNum.Text = lvwNodes.Items[lvwNodes.SelectedIndices[0]].Text;
			}
			else
			{
				txtNodeNum.Text = "";
				txtNodeNum.ReadOnly = true;
			}
			
		}
		private void btnModify_Click(object sender, EventArgs e)
		{
			if (lvwNodes.SelectedItems.Count == 1)
			{
				try
				{
					int num = int.Parse(txtNodeNum.Text);
				}
				catch (Exception ex)
				{
					MessageBox.Show("请输入一个正整数", "提示");
					return;
				}
			
				lvwNodes.SelectedItems[0].Text = txtNodeNum.Text;
			}
			
		}

		private void btnAddNode_Click(object sender, EventArgs e)
		{
			this.lvwNodes.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  
			ListViewItem lvi = new ListViewItem();
			lvi.ImageIndex = 0;     //通过与imageList绑定，显示imageList中第i项图标  
			lvi.Text = "10";
			this.lvwNodes.Items.Add(lvi);
			this.lvwNodes.EndUpdate();  //结束数据处理，UI界面一次性绘制。
		}

		private void btnDelNode_Click(object sender, EventArgs e)
		{
			this.lvwNodes.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
			if (lvwNodes.SelectedItems.Count == 1)
			{
				lvwNodes.SelectedItems[0].Remove();
			}
			else if (lvwNodes.SelectedItems.Count > 1)
			{
				int count = lvwNodes.SelectedItems.Count;
				if (MessageBox.Show("确定要一次性删除" + count + "个节点？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					for (int i = 0; i < count; i++)
					{
						lvwNodes.SelectedItems[0].Remove();
					}
				}
			}
			this.lvwNodes.EndUpdate();  //结束数据处理，UI界面一次性绘制。
		}

		private void txtNodeNum_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
				btnModify_Click(sender, e);
		}

		private void txtNodeNum_TextChanged(object sender, EventArgs e)
		{

		}

	}
}
