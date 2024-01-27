using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNetworkClassifier
{
    /// <summary>
    /// 【句子数据】
    /// 保存各分词及句子分类下标
    /// </summary>
	[Serializable]
    public class clsData
    {
		//一个句子的全部分词
        public string[] words { set; get; }

		//所有分词的词性标注
		public string[] tags { set; get; }

		//一个句子的分类下标
        public int y { set; get; }

		//句子分类标签
		public string label { set; get; }

		/// <summary>
		/// 句子数据构造函数
		/// </summary>
		/// <param name="_words"></param>
		/// <param name="_y"></param>
		public clsData(string[] _words, int _y, string _label)
        {
            words = _words;
            y = _y;
        }

		/// <summary>
		/// 句子数据构造函数
		/// 带词性标注
		/// </summary>
		/// <param name="_words"></param>
		/// <param name="_tags"></param>
		/// <param name="_y"></param>
		public clsData(string[] _words, string[] _tags, int _y, string _label)
		{
			words = _words;
			tags = _tags;
			y = _y;
		}

    }
}
