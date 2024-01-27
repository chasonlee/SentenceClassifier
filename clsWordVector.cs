using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace NeuroNetworkClassifier
{
    /// <summary>
    /// 【词向量】
    /// </summary>
	[Serializable]
    public class clsWordVector
    {
		//语料向量维度
		public int dim { get; set; }

		//数据集词典
		public Dictionary<string, int> vocab_dic = new Dictionary<string, int>();

		//数据集词向量映射列表
		public List<double[]> vocab_vec_map = new List<double[]>();

		/// <summary>
		/// 在数据集中建立词与向量的映射关系
		/// </summary>
		/// <param name="word"></param>
		/// <param name="vector"></param>
		public void MappingVocabWordVector(string word, double[] vector)
		{
			vocab_dic.Add(word, vocab_dic.Count);
			vocab_vec_map.Add(vector);
		}

		/// <summary>
		/// 在数据集中从词得到向量
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public double[] GetVec4Vocab(string word)
		{
			return vocab_vec_map[vocab_dic[word]];
		}

		/// <summary>
		/// 在数据集中判断词是否存在映射表里
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public bool IsVocabWordExist(string word)
		{
			return vocab_dic.ContainsKey(word);
		}

		/// <summary>
		/// 生成数据集的词向量映射表
		///	新词则随机生成数据词向量
		///	若还未加载语料词向量，则返回false
		/// </summary>
		/// <param name="wordvec"></param>
		public void GetVocabVecMap(clsWord2Vec word2vec, clsDataset dataset)
		{
			dim = word2vec.dim;
			vocab_dic.Clear();
			vocab_vec_map.Clear();
			for (int i = 0; i < dataset.vocab.Count; i++)
			{
				//跳过已加载的数据集词向量
				if (vocab_dic.ContainsKey(dataset.vocab[i])) continue;
				if (word2vec.IsWordExist(dataset.vocab[i]))
				{
					//添加语料中存在的词向量到数据集词向量中
					MappingVocabWordVector(dataset.vocab[i], word2vec.GetVec4Word(dataset.vocab[i]));
				}
				else
				{
					//随机生成语料中不存在的词向量到数据集词向量中
					double[] vec = new double[dim];
					for (int j = 0; j < dim; j++)
					{
						byte[] buffer = Guid.NewGuid().ToByteArray();
						int iSeed = BitConverter.ToInt32(buffer, 0);
						Random ran = new Random(iSeed);
						vec[j] = (ran.NextDouble() - 0.5) / 2;
					}
					MappingVocabWordVector(dataset.vocab[i], vec);
					dataset.unknowWordNum++;
				}
			}
		}

		
    }
}
