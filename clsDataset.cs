using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SmartZero.LTP;

namespace NeuroNetworkClassifier
{
    /// <summary>
    /// 【数据集】
    /// </summary>
	[Serializable]
    public class clsDataset
    {
		//数据集词典
		public List<string> vocab { set; get; }

		//训练集
        public List<clsData> trainSet { set; get; }

		//测试集
        public List<clsData> testSet { set; get; }

		//句子最大词数
        public int wordMaxNum { set; get; }

		//语料词向量未登陆词数
		public int unknowWordNum { set; get; }

		//记录加载文件数量，即句子类型数量
		public int typeNum;

		//记录已加载的文件名
		public List<string> loadedFiles;

		/// <summary>
		/// 数据集构造函数
		/// </summary>
        public clsDataset()
        {
			vocab = new List<string>();
            trainSet = new List<clsData>();
            testSet = new List<clsData>();
			loadedFiles = new List<string>();
            wordMaxNum = 0;
			unknowWordNum = 0;
			typeNum = 0;
        }

		/// <summary>
		/// 提取文件名，作为分类标签
		/// </summary>
		/// <param name="files"></param>
		/// <returns></returns>
		public string[] GetClasses(string[] files)
		{
			string[] labels;
			string label;
			string[] classes = new string[files.Count()];
			for (int i = 0; i < files.Count(); i++)
			{
				labels = files[i].Split('\\');
				label = labels[labels.Count() - 1].Split('.')[0];
				classes[i] = label;
			}
			return classes;
		}
		/// <summary>
		/// 判断数据集文件是否已经加载过
		/// </summary>
		/// <param name="file"></param>
		public bool IsFileLoaded(string file)
		{
			if (loadedFiles.Contains(file))
			{
				System.Console.WriteLine("文件‘" + file + "’已加载过。");
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 加载全部数据集
		/// </summary>
		/// <param name="files"></param>
        public void LoadDatasetFiles(string[] files)
        {
            string sent, label;
            string[] words, labels;
            int split;
            int wordnum = 0;
            //初始化分词器
            if (Segmentor.InitSegmentor(@"ltp_data/cws.model", ""))
            {
                System.Console.WriteLine("分词器初始化成功");
            }
            else
            {
                System.Console.WriteLine("分词器初始化失败");
            }
			//清空所有数据
			vocab.Clear();
			trainSet.Clear();
			testSet.Clear();
			loadedFiles.Clear();
			wordMaxNum = 0;
			typeNum = 0;
            //加载全部训练样本
            for (int i = 0; i < files.Count(); i++)
            {
				//跳过已加载过的文件
				if (IsFileLoaded(files[i])) continue;

				//提取文件名，作为分类标签
				labels = files[i].Split('\\');
				label = labels[labels.Count() - 1].Split('.')[0];

                FileStream fs = new FileStream(files[i], FileMode.Open);
                StreamReader rd = new StreamReader(fs);
                while ((sent = rd.ReadLine()) != null)
                {
                    if (Segmentor.IsSegmentorInitialed())
                    {
                        //空格分词
                        sent = Segmentor.Segment(sent, " ");
                        //System.Console.WriteLine("words = " + sent);
                        //获取分词
                        words = sent.Split();
                        //记录最大词数
                        wordnum = words.Count();
                        if (wordMaxNum < wordnum) wordMaxNum = wordnum;
                        //创建词表
                        for (int k = 0; k < wordnum; k++)
                        {
                            if (!vocab.Contains(words[k]))
                            {
                                vocab.Add(words[k]);
                            }
                        }
                        //随机抽取测试集
                        byte[] buffer = Guid.NewGuid().ToByteArray();
                        int iSeed = BitConverter.ToInt32(buffer, 0);
                        Random ran = new Random(iSeed);
                        split = ran.Next(10);
                        if (split != 1)
                        {
                            trainSet.Add(new clsData(words, i, ""));
                        }
                        else
                        {
							testSet.Add(new clsData(words, i, ""));
                        }
                    }
                }
                rd.Dispose();
                fs.Dispose();
				//记录已加载的文件名
				loadedFiles.Add(files[i]);
				typeNum++;
            }
            Segmentor.ReleaseSegmentor();
        }

		/// <summary>
		/// 获取一句话的分词结果
		/// </summary>
		/// <param name="sent"></param>
		/// <returns></returns>
		public string[] GetInputWords(string sent)
		{
			string[] words = null;
			//初始化分词器
			if (Segmentor.InitSegmentor(@"ltp_data/cws.model", ""))
			{
				System.Console.WriteLine("分词器初始化成功");
			}
			else
			{
				System.Console.WriteLine("分词器初始化失败");
			}
			if (Segmentor.IsSegmentorInitialed())
			{
				//空格分词
				sent = Segmentor.Segment(sent, " ");
				System.Console.WriteLine("words = " + sent);
				//获取分词
				words = sent.Split();
			}
			Segmentor.ReleaseSegmentor();
			return words;
		}

		/// <summary>
		/// 加载全部数据集，带标注处理
		/// </summary>
		/// <param name="files"></param>
		public void LoadDatasetFiles_Tag(string[] files)
		{
			string sent = "这是一个很有趣的故事", tag, label;
			string[] words, tags, labels;
			int split;
			int wordnum = 0;
			//初始化分词器
			if (Segmentor.InitSegmentor(@"ltp_data/cws.model", ""))
			{
				System.Console.WriteLine("分词器初始化成功");
			}
			else
			{
				System.Console.WriteLine("分词器初始化失败");
			}
			//if (Segmentor.IsSegmentorInitialed())
			//{
			//	//空格分词
			//	sent = Segmentor.Segment(sent, " ");
			//	System.Console.WriteLine(sent);
			//}

			//初始化词性标注
			if (Postagger.InitPostagger(@"ltp_data/pos.model"))
			{
				System.Console.WriteLine("词性标注初始化成功");
			}
			else
			{
				System.Console.WriteLine("词性标注初始化失败");
			}

			//if (Postagger.IsPostaggerInitialed())
			//{
			//	tags = Postagger.Postag(sent, " ");
			//	System.Console.WriteLine("tags = " + tags);
			//}

			//加载全部训练样本
			for (int i = 0; i < files.Count(); i++)
			{
				//跳过已加载过的文件
				if (IsFileLoaded(files[i])) continue;

				//提取文件名，作为分类标签
				labels = files[i].Split('\\');
				label = labels[labels.Count() - 1].Split('.')[0];

				FileStream fs = new FileStream(files[i], FileMode.Open);
				StreamReader rd = new StreamReader(fs);
				while ((sent = rd.ReadLine()) != null)
				{
					if (Segmentor.IsSegmentorInitialed() && Postagger.IsPostaggerInitialed())
					{
						//空格分词
						sent = Segmentor.Segment(sent, " ");
						System.Console.WriteLine("words = " + sent);

						//词性标注
						tag = Postagger.Postag(sent, " ");
						System.Console.WriteLine("tags = " + tag);

						//获取分词
						words = sent.Split();

						//获取词性标注
						tags = tag.Split();

						//记录最大词数
						wordnum = words.Count();
						if (wordMaxNum < wordnum) wordMaxNum = wordnum;

						//创建词表
						for (int k = 0; k < wordnum; k++)
						{
							if (!vocab.Contains(words[k]))
							{
								vocab.Add(words[k]);
							}
						}
						//随机抽取测试集
						byte[] buffer = Guid.NewGuid().ToByteArray();
						int iSeed = BitConverter.ToInt32(buffer, 0);
						Random ran = new Random(iSeed);
						split = ran.Next(10);
						if (split != 1)
						{
							trainSet.Add(new clsData(words, tags, i, label));
						}
						else
						{
							testSet.Add(new clsData(words, tags, i, label));
						}
					}
				}
				rd.Dispose();
				fs.Dispose();
				//记录已加载的文件名
				loadedFiles.Add(files[i]);
				typeNum++;
			}
			Segmentor.ReleaseSegmentor();
			Postagger.ReleasePostagger();
		}
    }
	
}
