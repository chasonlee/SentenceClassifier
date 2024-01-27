using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNetworkClassifier
{
	/// <summary>
	/// 【数据集及其词向量】
	/// 打包两个类，以便序列化保存
	/// </summary>
	[Serializable]
	public class clsDataVector
	{
		public clsDataset dataset;
		public clsWordVector wordvec;
	}
}
