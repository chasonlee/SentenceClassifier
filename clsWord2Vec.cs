using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NeuroNetworkClassifier
{
	public class clsWord2Vec
	{
		//记录已加载的文件名
		public List<string> loadedFiles = new List<string>();

		//语料词典
		public Dictionary<string, int> word_dic = new Dictionary<string, int>();

		//语料词向量映射列表
		public List<double[]> word_vec_map = new List<double[]>();

		//语料向量维度
		public int dim { get; set; }

		//输出信息
		public string message { get; set; }

		/// <summary>
		/// 判断文件是否已经加载过
		/// </summary>
		/// <param name="file"></param>
		public bool IsFileLoaded(string file)
		{
			if (loadedFiles == null) loadedFiles = new List<string>();
			if (loadedFiles.Contains(file))
			{
				System.Console.WriteLine("词向量文件‘" + file + "’已加载过。");
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 在语料中建立词与向量的映射关系
		/// </summary>
		/// <param name="word"></param>
		/// <param name="vector"></param>
		public void MappingWordVector(string word, double[] vector)
		{
			if (word_dic == null) word_dic = new Dictionary<string, int>();
			if (word_vec_map == null) word_vec_map = new List<double[]>();
			word_dic.Add(word, word_dic.Count);
			word_vec_map.Add(vector);
		}

		/// <summary>
		/// 在语料中从词得到向量
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public double[] GetVec4Word(string word)
		{
			return word_vec_map[word_dic[word]];
		}

		/// <summary>
		/// 在语料中判断词是否存在
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public bool IsWordExist(string word)
		{
			if (word_dic == null) word_dic = new Dictionary<string, int>();
			return word_dic.ContainsKey(word);
		}

		/// <summary>
		/// 加载语料词向量文件
		/// </summary>
		/// <param name="file"></param>
		public void LoadWordVector4File(object obj_file)
		{
			string file = (string)obj_file;
			//跳过已加载的词向量文件
			if (IsFileLoaded(file))
			{
				message = "词向量文件已存在，不需要重复加载！";
				return;
			}
			System.Console.WriteLine("Loading vectors...");
			FileStream fs = null;
			try
			{
				fs = new FileStream(file, FileMode.Open);
			}
			catch (Exception ex)
			{
				message = "文件‘" + file + "’加载异常！请确认文件格式是否正确！";
				return;
			}

			StreamReader rd = new StreamReader(fs);
			string s;
			string[] head = rd.ReadLine().Split();
			dim = Convert.ToInt16(head[1]);
			string[] word;
			double[] vec;
			//读入文件所有行，存放到List<string>集合中
			while ((s = rd.ReadLine()) != null)
			{
				word = s.Split();
				vec = new double[dim];
				for (int i = 0; i < vec.Count(); i++)
				{
					vec[i] = Convert.ToDouble(word[i + 1]);
				}
				MappingWordVector(word[0], vec);
			}
			rd.Close();
			fs.Close();
			System.Console.WriteLine("Vectors loaded!");
			message = "词向量文件加载成功！";
			//记录刚加载的词向量文件
			loadedFiles.Clear();
			loadedFiles.Add(file);
		}
	}
}
