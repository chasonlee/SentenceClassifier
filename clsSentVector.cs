using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroNetworkClassifier
{
	/// <summary>
	/// 【句子向量】
	/// </summary>
	[Serializable]
	public class clsSentVector
	{
		//训练集句子向量
		public List<double[]> trainSetVec { get; set; }

		//训练集句子类型标签
		public List<double[]> trainSetLabel { get; set; }

		//测试集句子向量
		public List<double[]> testSetVec { get; set; }

		//测试集句子类型标签
		public List<double[]> testSetLabel { get; set; }

		//句子向量维数
		public int dim;

		//记录加载文件数量，即句子类型数量
		public int typeNum;

		/// <summary>
		/// 句子向量构造函数
		/// </summary>
		public clsSentVector()
		{
			trainSetVec = new List<double[]>();
			trainSetLabel = new List<double[]>();
			testSetVec = new List<double[]>();
			testSetLabel = new List<double[]>();
			dim = 0;
		} 
		/// <summary>
		/// 获取训练集的句子向量
		/// </summary>
		/// <param name="dataset"></param>
		/// <param name="wordvec"></param>
		/// <returns></returns>
		public void GetTrainSentVector(clsDataset dataset, clsWordVector wordvec){
			//记录分类数量
			typeNum = dataset.typeNum;
			//记录句子向量维度
			dim = wordvec.dim * dataset.wordMaxNum;
			double[] sent_vec;
			double[] word_vec;
			trainSetVec.Clear();
			trainSetLabel.Clear();
			//遍历所有训练集
			for (int i = 0; i < dataset.trainSet.Count; i++)
			{
				sent_vec = new double[dim];
				//遍历单个训练集中的每个词
				for (int j = 0; j < dataset.wordMaxNum; j++)
				{
					if (j < dataset.trainSet[i].words.Count())
					{
						word_vec = wordvec.GetVec4Vocab(dataset.trainSet[i].words[j]);
					}
					else
					{
						word_vec = new double[wordvec.dim];
					}
					word_vec.CopyTo(sent_vec, j * wordvec.dim);
					word_vec = null;
				}
				//记录句子向量
				trainSetVec.Add(sent_vec);
				//记录分类标签
				double[] trainSetOutput = new double[typeNum];
				trainSetOutput[dataset.trainSet[i].y] = 1;
				trainSetLabel.Add(trainSetOutput);
				sent_vec = null;
			}
		}

		/// <summary>
		/// 句子向量与标签打包成clsTrainSet类
		/// </summary>
		/// <returns></returns>
		public clsTrainSet VecFormat2TrainSet()
		{
			return new clsTrainSet(trainSetVec.ToArray(),trainSetLabel.ToArray());
		}

		/// <summary>
		/// 获取测试集句子向量
		/// </summary>
		/// <param name="dataset"></param>
		/// <param name="wordvec"></param>
		public void GetTestSentVector(clsDataset dataset, clsWordVector wordvec)
		{
			//记录句子向量维度
			dim = wordvec.dim * dataset.wordMaxNum;
			double[] sent_vec;
			double[] word_vec;
			testSetVec.Clear();
			testSetLabel.Clear();
			//遍历所有训练集
			for (int i = 0; i < dataset.testSet.Count; i++)
			{
				sent_vec = new double[dim];
				//遍历单个训练集中的每个词
				for (int j = 0; j < dataset.wordMaxNum; j++)
				{
					if (j < dataset.testSet[i].words.Count())
					{
						word_vec = wordvec.GetVec4Vocab(dataset.testSet[i].words[j]);
					}
					else
					{
						word_vec = new double[wordvec.dim];
					}
					word_vec.CopyTo(sent_vec, j * wordvec.dim);
					word_vec = null;
				}
				//记录句子向量
				testSetVec.Add(sent_vec);
				//记录分类标签
				double[] testSetOutput = new double[typeNum];
				testSetOutput[dataset.testSet[i].y] = 1;
				testSetLabel.Add(testSetOutput);
				sent_vec = null;
			}
			typeNum = dataset.typeNum;
		}

		/// <summary>
		/// 句子向量与标签打包成clsTestSet类
		/// </summary>
		/// <returns></returns>
		public clsTestSet[] VecFormat2TestSet()
		{
			clsTestSet[] testsets = new clsTestSet[testSetVec.Count()];
			for (int i = 0; i < testsets.Count(); i++)
			{
				testsets[i] = new clsTestSet(testSetVec[i], testSetLabel[i]);
			}
			return testsets;
		}

		/// <summary>
		/// 获取一句话的词向量
		/// </summary>
		/// <param name="wordvec"></param>
		/// <param name="inputsent"></param>
		public double[] GetOneVector(clsDataset dataset, clsWord2Vec word2vec, clsWordVector wordvec, string[] words)
		{
			//记录句子向量维度
			dim = wordvec.dim * dataset.wordMaxNum;
			double[] sent_vec = new double[dim];
			double[] word_vec;
			//遍历句子中的每个词
			for (int i = 0; i < dataset.wordMaxNum; i++)
			{
				if (i < words.Count())
				{
					if (wordvec.IsVocabWordExist(words[i]))
					{
						word_vec = wordvec.GetVec4Vocab(words[i]);
					}
					else if(word2vec.IsWordExist(words[i]))
					{
						word_vec = word2vec.GetVec4Word(words[i]);
					}
					else
					{
						//随机生成语料中不存在的词向量到数据集词向量中
						double[] vec = new double[wordvec.dim];
						for (int k = 0; k < wordvec.dim; k++)
						{
							byte[] buffer = Guid.NewGuid().ToByteArray();
							int iSeed = BitConverter.ToInt32(buffer, 0);
							Random ran = new Random(iSeed);
							vec[k] = (ran.NextDouble() - 0.5) / 2;
						}
						word_vec = vec;
					}
				}
				else
				{
					word_vec = new double[wordvec.dim];
				}
				word_vec.CopyTo(sent_vec, i * wordvec.dim);
				word_vec = null;
			}
			return sent_vec;
		}

		/// <summary>
		/// 获取带标注的训练集句子向量
		/// </summary>
		public void GetTrainSentVector_Tag(clsDataset dataset, clsWordVector wordvec)
		{
			//记录分类数量
			typeNum = dataset.typeNum;
			//记录句子向量维度
			dim = wordvec.dim * dataset.wordMaxNum;
			double[] sent_vec;
			double[] word_vec;
			trainSetVec.Clear();
			trainSetLabel.Clear();
			//遍历所有训练集
			for (int i = 0; i < dataset.trainSet.Count; i++)
			{
				sent_vec = new double[dim];
				//遍历单个训练集中的每个词
				for (int j = 0; j < dataset.wordMaxNum; j++)
				{
					if (j < dataset.trainSet[i].words.Count())
					{
						word_vec = wordvec.GetVec4Vocab(dataset.trainSet[i].words[j]);
					}
					else
					{
						word_vec = new double[wordvec.dim];
					}
					word_vec.CopyTo(sent_vec, j * wordvec.dim);
					word_vec = null;
				}
				//记录句子向量
				trainSetVec.Add(sent_vec);

				//记录分类标签
				double[] trainSetOutput = new double[typeNum];
				trainSetOutput[dataset.trainSet[i].y] = 1;
				trainSetLabel.Add(trainSetOutput);
				sent_vec = null;
			}
		}
	}
}
