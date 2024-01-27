using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge.Controls;

namespace NeuroNetworkClassifier
{
	public partial class frmMain : Form
	{
		//词向量文件名（共用）
		private string wordvec_filename = null;

		//模型节点参数列表
		public List<int> neuronsCount = new List<int>(){ 10 };

		//模型临时保存文件名
		public string model_tmp_filename = "Classifier.model";

		//词向量模型参数
		private clsWord2Vec word2vec = new clsWord2Vec();
		private clsWordVector wordvec = new clsWordVector();
		private clsDataset dataset = new clsDataset();
		private clsSentVector sentvec = new clsSentVector();
		private clsDataVector datavec = new clsDataVector();
		private clsDataVecSerialize datavecser = new clsDataVecSerialize();
		private clsModelError model_err = new clsModelError();
		private clsNNTrainer trainer;

		private FileSystemWatcher fswWatcher = new FileSystemWatcher();
		private Thread tloadwordvec;
		private Thread ttrainmodel;

		private string[] files;
		private string[] classes;

		//词性标注模型参数
		private clsDataset dataset_2 = new clsDataset();
		private clsWordVector wordvec_2 = new clsWordVector();
		private clsSentVector sentvec_2 = new clsSentVector();
		private clsDataVector datavec_2 = new clsDataVector();
		private clsDataVecSerialize datavecser_2 = new clsDataVecSerialize();
		private clsModelPerf modelperf_2 = new clsModelPerf();
		private clsNNTrainer trainer_2;

		private FileSystemWatcher fswWatcher_2 = new FileSystemWatcher();
		private Thread tloadwordvec_2;
		private Thread ttrainmodel_2;

		private string[] files_2;
		private string[] classes_2;


		public frmMain()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

			// 信息显示
			ShowMessages();
			ShowMessages_2();
		}

		#region ************************************************词向量模型************************************************

		/// <summary>
		/// 信息显示
		/// </summary>
		private void ShowMessages()
		{
			lstMessage.Items.Clear();
			if (wordvec_filename == null)
				lstMessage.Items.Add("词向量文件名：\t词向量未加载");
			else
				lstMessage.Items.Add("词向量文件名：\t" + wordvec_filename);
			lstMessage.Items.Add("词向量维度：\t" + word2vec.dim);
			if (dataset == null) return;
			lstMessage.Items.Add("训练集数量：\t" + dataset.trainSet.Count());
			lstMessage.Items.Add("测试集数量：\t" + dataset.testSet.Count());
			lstMessage.Items.Add("最大词数：\t" + dataset.wordMaxNum);
			lstMessage.Items.Add("词典数量：\t" + dataset.vocab.Count);
			lstMessage.Items.Add("新词数量：\t" + dataset.unknowWordNum);
			lstMessage.Items.Add("句向量维度：\t" + dataset.wordMaxNum * wordvec.dim);
			lstMessage.Items.Add("分类数量：\t" + dataset.loadedFiles.Count);

			if (trainer != null && trainer.modelmsg != null) 
				lstMessage.Items.Add(trainer.modelmsg);
			else
				lstMessage.Items.Add("模型结构：\t模型未加载");
			
		}

		/// <summary>
		/// 加载词向量
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoadWordVec_Click(object sender, EventArgs e)
		{
			//正在训练则不执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型正在训练，请停止后再进行此操作。", "提示");
				return;
			}
			string[] filepath;
			OpenFileDialog ofdWordvec = new OpenFileDialog();
			ofdWordvec.InitialDirectory = Application.StartupPath;
			ofdWordvec.Filter = null;
			ofdWordvec.FilterIndex = 2;
			ofdWordvec.RestoreDirectory = true;
			if (ofdWordvec.ShowDialog() == DialogResult.OK)
			{
				ssrLabel.Text = "状态：词向量加载中...";
				ssrLabel_2.Text = "状态：词向量加载中...";

				filepath = ofdWordvec.FileName.Split('\\');
				wordvec_filename = filepath[filepath.Count() - 1];

				tloadwordvec = new Thread(new ParameterizedThreadStart(word2vec.LoadWordVector4File));
				tloadwordvec.IsBackground = true;
				tloadwordvec.Start(ofdWordvec.FileName);

				//加载词向量文件
				//wordvec.LoadWordVector4File(wordvec_filename);
				tloadwordvec.Join();

				// 信息显示
				ShowMessages();
				ShowMessages_2();
				ssrLabel.Text = "状态：" + word2vec.message;
				//ssrLabel.Text = "状态：词向量已加载。";
				//ssrLabel_2.Text = "状态：词向量已加载。";
				MessageBox.Show(word2vec.message, "提示");
			}
		}

		/// <summary>
		/// 加载数据集，并生成映射表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoadDataset_Click(object sender, EventArgs e)
		{
			//正在训练则不执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型正在训练，请停止后再进行此操作。", "提示");
				return;
			} 
			if (word2vec.loadedFiles.Count == 0)
			{
				MessageBox.Show("请先加载词向量！", "提示");
				return;
			}
			OpenFileDialog ofdWordvec = new OpenFileDialog();
			ofdWordvec.InitialDirectory = Application.StartupPath;
			ofdWordvec.Filter = null;
			ofdWordvec.FilterIndex = 2;
			ofdWordvec.RestoreDirectory = true;
			ofdWordvec.Multiselect = true;
			ofdWordvec.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";

			if (ofdWordvec.ShowDialog() == DialogResult.OK)
			{
				files = ofdWordvec.FileNames;

				//加载数据集
				dataset.LoadDatasetFiles(files);

				//提取分类标签
				classes = dataset.GetClasses(dataset.loadedFiles.ToArray());

				ssrLabel.Text = "状态：数据集已加载。";
				//MessageBox.Show("数据集加载成功！", "提示");

				//生成数据集的词向量映射表
				wordvec.GetVocabVecMap(word2vec, dataset);

				//信息显示
				ShowMessages();
				ssrLabel.Text = "状态：映射表已生成。";

				//保存参数
				datavec.dataset = dataset;
				datavec.wordvec = wordvec;
				datavecser.Serialize(datavec);

				MessageBox.Show("数据集及其词向量映射表已保存！", "提示");
			}
		}

		/// <summary>
		/// 加载映射表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoadMap_Click(object sender, EventArgs e)
		{
			//正在训练则不执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型正在训练，请停止后再进行此操作。", "提示");
				return;
			}
			clsModelSerialize serialize = new clsModelSerialize();
			OpenFileDialog ofdMap = new OpenFileDialog();
			ofdMap.InitialDirectory = Application.StartupPath;
			ofdMap.Filter = null;
			ofdMap.FilterIndex = 2;
			ofdMap.RestoreDirectory = true;
			ofdMap.Filter = "All files (*.*)|*.*|vecmap files (*.vecmap)|*.vecmap";
			if (ofdMap.ShowDialog() == DialogResult.OK)
			{
				//加载参数
				try
				{
					datavec = datavecser.DeSerialize(ofdMap.FileName);
					dataset = datavec.dataset;
					wordvec = datavec.wordvec;

					//获取分类标签
					classes = dataset.GetClasses(dataset.loadedFiles.ToArray());
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
				ShowMessages();
				ssrLabel.Text = "状态：映射表已加载。";
			}
			
		}

		/// <summary>
		/// 保存映射表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveMap_Click(object sender, EventArgs e)
		{
			//正在训练则不执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型正在训练，请停止后再进行此操作。", "提示");
				return;
			}
			//检查映射表是否存在
			if (dataset == null || dataset.trainSet == null || dataset.trainSet.Count == 0)
			{
				MessageBox.Show("请生成或加载映射表！", "提示");
				return;
			}
			clsModelSerialize serialize = new clsModelSerialize();
			SaveFileDialog sfdWordvec = new SaveFileDialog();
			sfdWordvec.InitialDirectory = Application.StartupPath;
			sfdWordvec.Filter = null;
			sfdWordvec.FilterIndex = 2;
			sfdWordvec.RestoreDirectory = true;
			sfdWordvec.Filter = "All files (*.*)|*.*|vecmap files (*.vecmap)|*.vecmap";
			string filename = "DataVector_" + wordvec.dim + "_[" + dataset.trainSet.Count() + "-" + dataset.testSet.Count() + "]_" +
									dataset.wordMaxNum + "_" + dataset.wordMaxNum * wordvec.dim + "_" + dataset.loadedFiles.Count + ".vecmap";
			sfdWordvec.FileName = filename;

			if (sfdWordvec.ShowDialog() == DialogResult.OK)
			{
				//保存参数
				datavec.dataset = dataset;
				datavec.wordvec = wordvec;
				datavecser.Serialize(datavec, sfdWordvec.FileName);

				ShowMessages();
				ssrLabel.Text = "状态：映射表已保存。   文件名：" + filename;
			}
		}

		/// <summary>
		/// 生成数据集词向量
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//private void btnGenerateWordVec_Click(object sender, EventArgs e)
		//{
		//	OpenFileDialog ofdWordvec = new OpenFileDialog();
		//	ofdWordvec.InitialDirectory = Application.StartupPath;
		//	ofdWordvec.Filter = null;
		//	ofdWordvec.FilterIndex = 2;
		//	ofdWordvec.RestoreDirectory = true;
		//	if (ofdWordvec.ShowDialog() == DialogResult.OK)
		//	{
		//		wordvec_filename = ofdWordvec.FileName;
		//	}
		//	else
		//	{
		//		return;
		//	}

		//	//加载词向量文件
		//	wordvec.LoadWordVector4File(wordvec_filename);
		//	dataset.LoadDatasetFiles(files);
		//	System.Console.WriteLine("训练集数量：" + dataset.trainSet.Count());
		//	System.Console.WriteLine("测试集数量：" + dataset.testSet.Count());
		//	System.Console.WriteLine("句子最大词数：" + dataset.wordMaxNum);
		//	System.Console.WriteLine("数据集字典数量：" + dataset.vocab.Count);

		//	//生成数据集的词向量映射表
		//	wordvec.GetVocabVecMap(dataset);
		//	System.Console.WriteLine("数据集新词数量：" + dataset.unknowWordNum);

		//	//生成训练集的句子向量
		//	sentvec.GetTrainSentVector(dataset, wordvec);
		//	System.Console.WriteLine("句子向量维度：" + sentvec.dim);

		//	//信息显示
		//	ShowMessages();

		//	//保存参数
		//	datavec.dataset = dataset;
		//	datavec.wordvec = wordvec;
		//	datavecser.Serialize(datavec);
		//	MessageBox.Show("数据集与词向量已保存！", "提示");

		//}

		/// <summary>
		/// 加载模型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoadModel_Click(object sender, EventArgs e)
		{
			//正在训练则不执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型正在训练，请停止后再进行此操作。", "提示");
				return;
			} 
			clsModelSerialize serialize = new clsModelSerialize();
			OpenFileDialog ofdWordvec = new OpenFileDialog();
			ofdWordvec.InitialDirectory = Application.StartupPath;
			ofdWordvec.Filter = null;
			ofdWordvec.FilterIndex = 2;
			ofdWordvec.RestoreDirectory = true;
			ofdWordvec.Filter = "All files (*.*)|*.*|model files (*.model)|*.model";
			if (ofdWordvec.ShowDialog() == DialogResult.OK)
			{
				try
				{
					//加载模型
					trainer = serialize.DeSerialize(ofdWordvec.FileName);
					model_tmp_filename = trainer.filename;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
				ShowMessages();
                btnDraw_Click(sender, e);
                ssrLabel.Text = "状态：模型已加载。";
			}
			
		}

		/// <summary>
		/// 保存模型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveModel_Click(object sender, EventArgs e)
		{
			//正在训练则不执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型正在训练，请停止后再进行此操作。", "提示");
				return;
			} 
			if (trainer == null || trainer.nn == null)
			{
				MessageBox.Show("请先加载模型或训练新模型。", "提示");
				return;
			}

			clsModelSerialize serialize = new clsModelSerialize();
			SaveFileDialog sfdWordvec = new SaveFileDialog();
			sfdWordvec.InitialDirectory = Application.StartupPath;
			sfdWordvec.Filter = null;
			sfdWordvec.FilterIndex = 2;
			sfdWordvec.RestoreDirectory = true;
			string filename;
			if (trainer.nn.trainset_err.Count > 0 && trainer.nn.testset_err.Count > 0){
				filename = "Classifier_[" + dataset.trainSet.Count() + "-" + dataset.testSet.Count() + "]_";
				for (int i = 0; i < trainer.nn.layer_num.Length; i++)
					filename += i < trainer.nn.layer_num.Length - 1 ? trainer.nn.layer_num[i] + "-" : trainer.nn.layer_num[i].ToString();
				filename += "_" + trainer.nn.trained_times +
							"--" + (int)(trainer.nn.trainset_err[trainer.nn.trainset_err.Count - 1] * 100) +
							"--" + (int)(trainer.nn.testset_err[trainer.nn.testset_err.Count - 1] * 100) + ".model";
			}

			else
			{
				filename = "Classifier_";
				for (int i = 0; i < trainer.nn.layer_num.Length; i++)
					filename += i < trainer.nn.layer_num.Length - 1 ? trainer.nn.layer_num[i] + "-" : trainer.nn.layer_num[i].ToString();
				filename += "_" + trainer.nn.trained_times + "--0--0.model";
			}
				

			sfdWordvec.FileName = filename;
			if (sfdWordvec.ShowDialog() == DialogResult.OK)
			{
				try
				{
					//保存模型
					 serialize.Serialize(trainer, sfdWordvec.FileName);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
				ShowMessages();
				ssrLabel.Text = "状态：模型已保存。   文件名：" + filename;
			}
		}

		/// <summary>
		/// 模型设置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModelSetting_Click(object sender, EventArgs e)
		{
			frmModelSetting frmModSet = new frmModelSetting(this);
			frmModSet.Show();
		}

		/// <summary>
		/// 训练新模型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTrainingModel_Click(object sender, EventArgs e)
		{
			//正在训练则不重复执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型已在训练中...", "提示");
				return;
			} 

			//提示是否要用新模型覆盖旧的
			if (trainer != null && trainer.nn.trained_times > 1 && MessageBox.Show("训练新模型将会覆盖默认模型文件，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				return;
			}
			frmHiddenNum frmshn = new frmHiddenNum(this);
			frmshn.Show();
		}

		/// <summary>
		/// 训练新模型
		/// </summary>
		public void TrainNewModel()
		{
			if (dataset == null || dataset.trainSet == null || dataset.trainSet.Count == 0)
			{
				//加载参数
				try
				{
					datavec = datavecser.DeSerialize();
					dataset = datavec.dataset;
					wordvec = datavec.wordvec;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
			}

			//生成训练集的句子向量
			sentvec.GetTrainSentVector(dataset, wordvec);

			//生成测试集的句子向量
			sentvec.GetTestSentVector(dataset, wordvec);

			//句子向量打包成训练集
			clsTrainSet trainSets = sentvec.VecFormat2TrainSet();

			//设置输出层节点数
			neuronsCount.Add(sentvec.typeNum);

			//构造多层神经网络
			ActivationNetwork nn = new ActivationNetwork(
				(IActivationFunction)new SigmoidFunction(1.0),
				sentvec.dim, neuronsCount.ToArray());

			//生成训练模型
			trainer = new clsNNTrainer(nn, model_tmp_filename);

			//多线程训练新模型
			ttrainmodel = new Thread(new ParameterizedThreadStart(trainer.Train));
			ttrainmodel.IsBackground = true;
			ttrainmodel.Start(sentvec);

			//监视模型文件初始化
			UsingFileSystemWatcher();

			//启用监视
			fswWatcher.EnableRaisingEvents = true;

			//训练新模型
			//trainer.Train(sentvec);

			// 信息显示
			ShowMessages();
			ssrLabel.Text = "状态：模型训练中...";

			//控件状态设置
			btnStopTraining.Enabled = true;
			pictureBox1.Image = null;
		}

		/// <summary>
		/// 继续训练模型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnContinueTraining_Click(object sender, EventArgs e)
		{
			//正在训练则不重复执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型已在训练中...", "提示");
				return;
			} 

			if (dataset.trainSet.Count == 0)
			{
				//加载参数
				try
				{
					datavec = datavecser.DeSerialize();
					dataset = datavec.dataset;
					wordvec = datavec.wordvec;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
			}

			//加载模型
			if (trainer == null)
			{
				clsModelSerialize serialize = new clsModelSerialize();
				OpenFileDialog ofdWordvec = new OpenFileDialog();
				ofdWordvec.InitialDirectory = Application.StartupPath;
				ofdWordvec.Filter = null;
				ofdWordvec.FilterIndex = 2;
				ofdWordvec.RestoreDirectory = true;
				if (ofdWordvec.ShowDialog() == DialogResult.OK)
				{
					try
					{
						trainer = serialize.DeSerialize(ofdWordvec.FileName);
						trainer.filename = model_tmp_filename;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
						return;
					}
				}
				else
				{
					return;
				}
			}
			
			//生成训练集的句子向量
			sentvec.GetTrainSentVector(dataset, wordvec);

			//生成测试集的句子向量
			sentvec.GetTestSentVector(dataset, wordvec);

			//多线程继续训练模型
			ttrainmodel = new Thread(new ParameterizedThreadStart(trainer.ContinueTrain));
			ttrainmodel.IsBackground = true;
			ttrainmodel.Start(sentvec);

			//继续训练模型
			//trainer.ContinueTrain(sentvec, 100000);

			//监视模型文件初始化
			UsingFileSystemWatcher();

			//启用监视
			fswWatcher.EnableRaisingEvents = true;

			// 信息显示
			ShowMessages();
			ssrLabel.Text = "状态：模型训练中...";

			//控件状态设置
			btnStopTraining.Enabled = true;
		}

		/// <summary>
		/// 停止训练
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStopTraining_Click(object sender, EventArgs e)
		{
			//正在训练才停止
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				//终止训练线程
				ttrainmodel.Abort();
				
				//停止监视
				fswWatcher.EnableRaisingEvents = false;

				//显示信息
				ShowMessages();
				ssrLabel.Text = "状态：模型训练已停止。";
			}
			btnStopTraining.Enabled = false;
			
		}
		/// <summary>
		/// 验证模型误差
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModelPerformance_Click(object sender, EventArgs e)
		{
			//正在训练则不执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型正在训练，请停止后再进行此操作。", "提示");
				return;
			} 
			if (dataset.trainSet.Count == 0)
			{
				//加载参数
				try
				{
					datavec = datavecser.DeSerialize();
					dataset = datavec.dataset;
					wordvec = datavec.wordvec;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
			}
			
			
			//加载模型
			if (trainer == null)
			{
				clsModelSerialize serialize = new clsModelSerialize();
				try
				{
					trainer = serialize.DeSerialize(model_tmp_filename);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
			}

			//生成训练集的句子向量
			sentvec.GetTrainSentVector(dataset, wordvec);

			//生成测试集的句子向量
			sentvec.GetTestSentVector(dataset, wordvec);

			//验证训练集
			System.Console.WriteLine("正在验证训练集...");
			double err = model_err.trainSetError(sentvec, trainer);
			System.Console.WriteLine("模型在训练集中的误差率：" + err * 100 + "%");

			//保存误差日志
			model_err.saveErrorLog("Error.log", trainer.modelmsg + "训练集的误差率为：", err, false);

			//验证测试集
			System.Console.WriteLine("正在验证测试集...");
			err = model_err.testSetError(sentvec, trainer);
			System.Console.WriteLine("模型在测试集中的误差率：" + err * 100 + "%");

			//保存误差日志
			model_err.saveErrorLog("Error.log", trainer.modelmsg + "测试集的误差率为：", err, true);

			//保存出错日志
			model_err.saveErrExamples("Error Example.log", trainer.modelmsg, dataset);
		}

		/// <summary>
		/// 文件监视初始化
		/// </summary>
		void UsingFileSystemWatcher()
		{
			//6.2
			//FileSystemWatcher：侦听文件系统更改通知，并在目录或目录中的文件发生更改时引发事件。
			//获取或设置要监视的目录的路径。
			fswWatcher.Path = Application.StartupPath;
			//获取或设置要监视的更改类型。
			fswWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.LastAccess;
			//获取或设置筛选字符串，用于确定在目录中监视哪些文件。
			//此處只能監控某一種文件，不能監控件多種文件，但可以監控所有文件
			fswWatcher.Filter = model_tmp_filename;
			//获取或设置一个值，该值指示是否监视指定路径中的子目录。
			fswWatcher.IncludeSubdirectories = true;


			#region 6.3 觸發的事件
			//文件或目錄創建時事件
			fswWatcher.Created += new FileSystemEventHandler(fswWatcher_Created);
			//文件或目錄變更時事件
			fswWatcher.Changed += new FileSystemEventHandler(fswWatcher_Changed);

			#endregion

			//获取或设置一个值，该值指示是否启用此组件。
			//fswWatcher.EnableRaisingEvents = true;

		}

		/// <summary>
		/// 文件或目錄創建時事件方法
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void fswWatcher_Created(object sender, FileSystemEventArgs e)
		{
			//停止监视
			fswWatcher.EnableRaisingEvents = false;

			//阻塞保存模型
			while (trainer.saving_model == true)
				if (ssrLabel.Text != "状态：模型保存中...")
					ssrLabel.Text = "状态：模型保存中...";
			
			if (trainer.nn.trainset_err.Count > 0 && trainer.nn.testset_err.Count > 0)
				ssrLabel.Text = "状态：模型训练中...   [已迭代" + trainer.nn.trained_times + "次]    模型误差[" +
							(trainer.nn.trainset_err[trainer.nn.trainset_err.Count - 1] * 100).ToString("f1") + ", " +
							(trainer.nn.testset_err[trainer.nn.testset_err.Count - 1] * 100).ToString("f1") + "]";
			else
				ssrLabel.Text = "状态：模型训练中...   [已迭代" + trainer.nn.trained_times + "次]    模型误差[100, 100]";


			//误差曲线图
			btnDraw_Click(sender, e);

			Thread.Sleep(500);

			//启用监视
			fswWatcher.EnableRaisingEvents = true;
		}

		/// <summary>
		/// 文件或目錄變更時事件的方法
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void fswWatcher_Changed(object sender, FileSystemEventArgs e)
		{
			//停止监视
			fswWatcher.EnableRaisingEvents = false;

			System.Console.WriteLine("\n**********fswWatcher_Changed*********");

			//阻塞保存模型
			while (trainer.saving_model == true)
				if (ssrLabel.Text != "状态：模型保存中...")
					ssrLabel.Text = "状态：模型保存中...";
			
			if (trainer.nn.trainset_err.Count > 0 && trainer.nn.testset_err.Count > 0)
				ssrLabel.Text = "状态：模型训练中...   [已迭代" + trainer.nn.trained_times + "次]    模型误差[" +
							(trainer.nn.trainset_err[trainer.nn.trainset_err.Count - 1] * 100).ToString("f1") + ", " +
							(trainer.nn.testset_err[trainer.nn.testset_err.Count - 1] * 100).ToString("f1") + "]";
			else
				ssrLabel.Text = "状态：模型训练中...   [已迭代" + trainer.nn.trained_times + "次]    模型误差[100, 100]";

			//误差曲线图
			btnDraw_Click(sender, e);

			Thread.Sleep(500);

			//启用监视
			fswWatcher.EnableRaisingEvents = true;
		}

		#endregion



		/// <summary>
		/// 单句输入
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtModelInput_KeyPress(object sender, KeyPressEventArgs e)
		{
			//回车确定
			if (e.KeyChar == (char)13 && txtModelInput.Text != "")
			{
				//检查词向量是否加载
				if (word2vec.loadedFiles == null || word2vec.loadedFiles.Count == 0)
				{
					MessageBox.Show("请先加载词向量！", "提示");
					return;
				}
				//检查是否加载数据集
				if (dataset.trainSet == null || dataset.trainSet.Count == 0)
				{
					MessageBox.Show("请先加载数据集，以便计算句子向量！", "提示");
					return;
				}
				if (wordvec.vocab_dic == null || wordvec.vocab_dic.Count() == 0)
				{
					MessageBox.Show("请先生成映射表！", "提示");
					return;
				}
				//检查模型是否加载
				if (trainer == null)
				{
					MessageBox.Show("请先加载模型！", "提示");
					return;
				}
				//先分词，再生成句子向量，最后得到模型输出结果
				int modelout = model_err.GetModelOutput(trainer, sentvec.GetOneVector(dataset, word2vec, wordvec, dataset.GetInputWords(txtModelInput.Text)));
				lstModelOutput.Items.Add("【" + classes[modelout] + "】\t" + txtModelInput.Text + "\n");
				lstModelOutput.SelectedIndex = lstModelOutput.Items.Count - 1;
				txtModelInput.Clear();
			}
			//Esc删除输入
			else if (e.KeyChar == (char)27)
			{
				txtModelInput.Clear();
			}
		}


		



		private void lstMessage_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();
			StringFormat strFmt = new System.Drawing.StringFormat();
			strFmt.LineAlignment = StringAlignment.Center; //文本水平居中
			e.Graphics.DrawString(lstMessage.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, strFmt);
		}

		private void lstModelOutput_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();
			StringFormat strFmt = new System.Drawing.StringFormat();
			strFmt.LineAlignment = StringAlignment.Center; //文本水平居中
			e.Graphics.DrawString(lstModelOutput.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, strFmt);
		}



		private void button1_Click(object sender, EventArgs e)
		{
			//多线程继续训练模型
			ttrainmodel = new Thread(new ParameterizedThreadStart(test_thread));
			ttrainmodel.IsBackground = true;
			ttrainmodel.Start(this);
			this.ssrLabel.Text = "test_click";
		}

		private void test_thread(object obj)
		{
			frmMain form1 = (frmMain)obj;
			form1.ssrLabel.Text = "test";


			//训练正在进行中
			if (form1.ttrainmodel != null && form1.ttrainmodel.IsAlive == true)
			{
				form1.ssrLabel.Text = "状态：模型训练中...";
			}
			else
			{
				form1.ssrLabel.Text = "状态：";
			}
		}

		/// <summary>
		/// 误差曲线图
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDraw_Click(object sender, EventArgs e)
		{
			if (trainer == null || trainer.nn == null || trainer.nn.trained_times <= 1) return;
			DrawingCurve bmp = new DrawingCurve();
			Curve2D cuv2D = new Curve2D();
			string[] keys = new string[trainer.nn.trained_times];
			float[] values = new float[trainer.nn.trainset_err.Count + trainer.nn.testset_err.Count];
			for (int i = 0; i < keys.Length; i++)
			{
				keys[i] = (i + 1).ToString();
			}
			int k = 0;
			for (; k < trainer.nn.trainset_err.Count; k++)
			{
				values[k] = (float)trainer.nn.trainset_err[k] * 100;
			}
			for (; k < values.Length; k++)
			{
				values[k] = (float)trainer.nn.testset_err[k - trainer.nn.trainset_err.Count] * 100;
			}
			cuv2D.Keys = keys;
			cuv2D.Values = values;
			pictureBox1.Image = bmp.DrawImage(cuv2D);

		}


		#region ************************************************词性标注模型************************************************
		/// <summary>
		/// 信息显示
		/// </summary>
		private void ShowMessages_2()
		{
			lstMessage_2.Items.Clear();
			if (wordvec_filename == null)
				lstMessage_2.Items.Add("词向量文件名：\t词向量未加载");
			else
				lstMessage_2.Items.Add("词向量文件名：\t" + wordvec_filename);
			lstMessage_2.Items.Add("词向量维度：\t" + wordvec.dim);
			if (dataset == null) return;
			lstMessage_2.Items.Add("训练集数量：\t" + dataset.trainSet.Count());
			lstMessage_2.Items.Add("测试集数量：\t" + dataset.testSet.Count());
			lstMessage_2.Items.Add("最大词数：\t" + dataset.wordMaxNum);
			lstMessage_2.Items.Add("词典数量：\t" + dataset.vocab.Count);
			lstMessage_2.Items.Add("新词数量：\t" + dataset.unknowWordNum);

			if (trainer != null && trainer.modelmsg != null)
				lstMessage_2.Items.Add(trainer.modelmsg);
			else
				lstMessage_2.Items.Add("模型结构：\t模型未加载");

		}

		/// <summary>
		/// 加载数据集，带词性标注
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoadDataset_2_Click(object sender, EventArgs e)
		{
			//正在训练则不执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型正在训练，请停止后再进行此操作。", "提示");
				return;
			}
			if (word2vec.loadedFiles.Count == 0)
			{
				MessageBox.Show("请先加载词向量！", "提示");
				return;
			}
			OpenFileDialog ofdWordvec = new OpenFileDialog();
			ofdWordvec.InitialDirectory = Application.StartupPath;
			ofdWordvec.Filter = null;
			ofdWordvec.FilterIndex = 2;
			ofdWordvec.RestoreDirectory = true;
			ofdWordvec.Multiselect = true;
			ofdWordvec.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";

			if (ofdWordvec.ShowDialog() == DialogResult.OK)
			{
				files = ofdWordvec.FileNames;
				//加载数据集
				dataset.LoadDatasetFiles_Tag(files);
				//信息显示
				ShowMessages();
				ssrLabel.Text = "状态：数据集已加载。";
				MessageBox.Show("数据集加载成功！", "提示");
			}
		}


		/// <summary>
		/// 生成映射表，带词性标注
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGetMap_2_Click(object sender, EventArgs e)
		{
			//正在训练则不执行
			if (ttrainmodel != null && ttrainmodel.IsAlive == true)
			{
				MessageBox.Show("模型正在训练，请停止后再进行此操作。", "提示");
				return;
			}
			else if (word2vec.loadedFiles.Count == 0)
			{
				MessageBox.Show("请先加载词向量！", "提示");
				return;
			}
			else if (dataset.loadedFiles.Count == 0)
			{
				MessageBox.Show("请先加载数据集！", "提示");
				return;
			}
			//生成数据集的词向量映射表
			wordvec.GetVocabVecMap(word2vec, dataset);

			//信息显示
			ShowMessages();
			ssrLabel.Text = "状态：映射表已生成。";

			//保存参数
			datavec.dataset = dataset;
			datavec.wordvec = wordvec;
			datavecser.Serialize(datavec);

			MessageBox.Show("数据集及其词向量映射表已保存！", "提示");
		}

		#endregion

		private void btnStopTraining_2_Click(object sender, EventArgs e)
		{

		}


	}
}
