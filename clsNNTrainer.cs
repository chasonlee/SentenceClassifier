using System;
using System.Collections.Generic;
using System.Text;

using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge.Controls;

namespace NeuroNetworkClassifier
{
	/// <summary>
	/// 【神经网络模型训练器】
	/// </summary>
    [Serializable]
    public class clsNNTrainer
    {
        public ActivationNetwork nn;
		public int training_times = 10000;
		public string modelmsg;
		public string filename = "Classifier.model";
		public bool saving_model = false;

		public clsNNTrainer(ActivationNetwork _nn, string _filename)
        {
            nn = _nn;
			filename = _filename;
			//记录模型信息
			modelmsg = "模型结构：[";
			for (int i = 0; i < _nn.layer_num.Length; i++)
				modelmsg += i < _nn.layer_num.Length - 1 ? _nn.layer_num[i] + "-" : _nn.layer_num[i].ToString();
			modelmsg += " 迭代" + _nn.trained_times + "次]    模型误差[100, 100]";
				
        }

        /// <summary>
		/// 训练神经网络
        /// </summary>
        /// <param name="sentvec">句子向量，用于验证误差</param>
        /// <param name="_training_times">迭代次数</param>
		public void Train(object objsentvec)
        {
			clsSentVector sentvec = (clsSentVector)objsentvec;

			//句子向量打包成训练集
			clsTrainSet trainSets = sentvec.VecFormat2TrainSet();

			System.Console.WriteLine("目标迭代次数：" + training_times + "次，神经网络训练中...");

			//随机初始化神经网络
            nn.Randomize();
			BackPropagationLearning teacher = new BackPropagationLearning(nn);
            for (int i = 0; i < training_times; i++)
            {
				System.Console.Write("第" + (i + 1) + "轮训练中...");
				teacher.RunEpoch(trainSets.input, trainSets.output);
				System.Console.WriteLine("训练完成！");

				//累计训练次数
				nn.trained_times++;

				//验证训练集
				clsModelError model_err = new clsModelError();

				System.Console.WriteLine("\t正在验证训练集...");
				double err = model_err.trainSetError(sentvec, this);

				//保存对训练集的误差
				nn.trainset_err.Add(err);
				System.Console.WriteLine("\t模型在训练集中的误差率：" + err * 100 + "%");

				//验证测试集
				System.Console.WriteLine("\t正在验证测试集...");
				err = model_err.testSetError(sentvec, this);

				//保存对测试集的误差
				nn.testset_err.Add(err);
				System.Console.WriteLine("\t模型在测试集中的误差率：" + err * 100 + "%");

				//保存模型
				clsModelSerialize serialize = new clsModelSerialize();
				serialize.Serialize(this, filename);

				//记录模型信息
				if (nn.trainset_err.Count > 0 && nn.testset_err.Count > 0)
				{
					modelmsg = "模型结构：[";
					for (int j = 0; j < nn.layer_num.Length; j++)
						modelmsg += j < nn.layer_num.Length - 1 ? nn.layer_num[j] + "-" : nn.layer_num[j].ToString();
					modelmsg += " 迭代" + nn.trained_times + "次]    模型误差[" +
						(nn.trainset_err[nn.trainset_err.Count - 1] * 100).ToString("f1") + ", " +
						(nn.testset_err[nn.testset_err.Count - 1] * 100).ToString("f1") + "]";
				}
			}
			System.Console.WriteLine("神经网络训练完毕！");
        }

		/// <summary>
		/// 继续训练神经网络
		/// </summary>
		/// <param name="sentvec">句子向量，用于验证误差</param>
		/// <param name="_training_times">迭代次数</param>
		public void ContinueTrain(object objsentvec)
		{
			clsSentVector sentvec = (clsSentVector)objsentvec;

			//句子向量打包成训练集
			clsTrainSet trainSets = sentvec.VecFormat2TrainSet();

			BackPropagationLearning teacher = new BackPropagationLearning(nn);
			System.Console.WriteLine("迭代次数：" + training_times + "次，神经网络训练中...");
			for (int i = nn.trained_times; i < training_times; i++)
			{
				System.Console.Write("第" + (i + 1) + "轮训练中...");
				teacher.RunEpoch(trainSets.input, trainSets.output);
				System.Console.WriteLine("训练完成！");

				//累计训练次数
				nn.trained_times++;

				//验证训练集
				clsModelError model_err = new clsModelError();
				System.Console.WriteLine("\t正在验证训练集...");
				double err = model_err.trainSetError(sentvec, this);

				//保存对训练集的误差
				nn.trainset_err.Add(err);
				System.Console.WriteLine("\t模型在训练集中的误差率：" + err * 100 + "%");

				//验证测试集
				System.Console.WriteLine("\t正在验证测试集...");
				err = model_err.testSetError(sentvec, this);

				//保存对测试集的误差
				nn.testset_err.Add(err);
				System.Console.WriteLine("\t模型在测试集中的误差率：" + err * 100 + "%");

				//保存模型
				clsModelSerialize serialize = new clsModelSerialize();
				serialize.Serialize(this, filename);
			}
			System.Console.WriteLine("神经网络训练完毕！");

			//记录模型信息
			if (nn.trainset_err.Count > 0 && nn.testset_err.Count > 0)
			{
				modelmsg = "模型结构：[";
				for (int j = 0; j < nn.layer_num.Length; j++)
					modelmsg += j < nn.layer_num.Length - 1 ? nn.layer_num[j] + "-" : nn.layer_num[j].ToString();
				modelmsg += " 迭代" + nn.trained_times + "次]    模型误差[" +
					(nn.trainset_err[nn.trainset_err.Count - 1] * 100).ToString("f1") + ", " +
					(nn.testset_err[nn.testset_err.Count - 1] * 100).ToString("f1") + "]";
			}
		}

        
    }
}
