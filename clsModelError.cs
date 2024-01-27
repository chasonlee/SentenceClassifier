using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace NeuroNetworkClassifier
{
	/// <summary>
	/// 【验证模型性能】
	/// </summary>
	public class clsModelError
	{
		List<int[]> trainErrInx = new List<int[]>();
		List<int[]> testErrInx = new List<int[]>();

		/// <summary>
		/// 比较两个数组是否完全相同
		/// </summary>
		/// <param name="out1"></param>
		/// <param name="out2"></param>
		/// <returns></returns>
		private bool sameOutput(double[] out1, double[]out2){
			if (out1.Count() != out2.Count()) return false;
			for (int j = 0; j < out1.Count(); j++)
			{
				if (out1[j] != out2[j])
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 格式化输出
		/// 将小数输出格式化为01输出
		/// 最大数为1，其余数为0
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		private double[] formatOutput(double[] output)
		{
			double maxd = 0;
			int maxinx=0;
			for (int i = 0; i < output.Count(); i++)
			{
				if (maxd < output[i])
				{
					maxd = output[i];
					maxinx = i;
				}
			}
			double[] foutput = new double[output.Count()];
			foutput[maxinx] = 1;
			return foutput;
		}
		/// <summary>
		/// 输出格式化为下标
		/// </summary>
		/// <param name="foutput"></param>
		/// <returns></returns>
		private int formatInt(double[] foutput)
		{
			for (int i = 0; i < foutput.Count(); i++)
			{
				if (foutput[i] > 0) return i;
			}
			return -1;
		}
		/// <summary>
		/// 保存误差日志
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="msg"></param>
		/// <param name="perf"></param>
		public void saveErrorLog(string fileName, string msg, double err, bool enter)
		{
			using (FileStream fs = new FileStream(fileName, FileMode.Append))
			{
				StreamWriter sw = new StreamWriter(fs);
				sw.WriteLine(DateTime.Now + " " + msg + err);
				if (enter == true) sw.WriteLine();
				sw.Close();
			}
			System.Console.WriteLine("误差日志已保存！");
		}

		/// <summary>
		/// 验证训练集误差率
		/// </summary>
		/// <param name="sentvec"></param>
		/// <param name="trainer"></param>
		/// <returns></returns>
		public double trainSetError(clsSentVector sentvec, clsNNTrainer trainer)
		{
			double err = 0;
			double[] output=new double[sentvec.typeNum];
			trainErrInx.Clear();
			for (int i = 0; i < sentvec.trainSetVec.Count(); i++)
			{
				//得到训练集输出
				output = trainer.nn.Compute(sentvec.trainSetVec[i]);
				//输出格式化
				double[] foutput = formatOutput(output);
				//比较输出与标签，并记录出错的下标
				if (sameOutput(foutput, sentvec.trainSetLabel[i]) == false)
				{
					err++;
					int trueOut = formatInt(sentvec.trainSetLabel[i]);
					int falseOut = formatInt(foutput);
					trainErrInx.Add(new int[] { i, trueOut, falseOut });
				}
			}
			err = err / sentvec.trainSetVec.Count();
			return err;
		}

		/// <summary>
		/// 验证测试集误差率
		/// </summary>
		/// <param name="sentvec"></param>
		/// <param name="trainer"></param>
		/// <returns></returns>
		public double testSetError(clsSentVector sentvec, clsNNTrainer trainer)
		{
			double err = 0;
			double[] output = new double[sentvec.typeNum];
			testErrInx.Clear();
			for (int i = 0; i < sentvec.testSetVec.Count(); i++)
			{
				//训练集输出
				output = trainer.nn.Compute(sentvec.testSetVec[i]);
				//输出格式化
				double[] foutput = formatOutput(output);
				//比较输出与标签，并记录出错的下标
				if (sameOutput(foutput, sentvec.testSetLabel[i]) == false)
				{
					err++;
					int trueOut = formatInt(sentvec.testSetLabel[i]);
					int falseOut = formatInt(foutput);
					testErrInx.Add(new int[] { i, trueOut, falseOut });
				}
			}
			err = err / sentvec.testSetVec.Count();
			return err;
		}

		/// <summary>
		/// 保存出错的例子
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="datalist"></param>
		public void saveErrExamples(string fileName, string modelmsg, clsDataset dataset)
		{
			using (FileStream fs = new FileStream(fileName, FileMode.Append)) 
			{
				StreamWriter sw = new StreamWriter(fs);
				string sent = "";
				sw.WriteLine(modelmsg);
				if (trainErrInx.Count() > 0) sw.WriteLine("\t训练集的错误：");
				for (int i = 0; i < trainErrInx.Count(); i++)
				{
					//添加本来的标签
					sent = "\ttag:" + trainErrInx[i][1];
					//添加输出的结果
					sent += " output:" + trainErrInx[i][2] + "\t";
					//得到出错的句子
					for (int j = 0; j < dataset.trainSet[trainErrInx[i][0]].words.Count(); j++)
					{
						sent += dataset.trainSet[trainErrInx[i][0]].words[j];
					}
					sw.WriteLine(sent);
				}
				if (testErrInx.Count() > 0) sw.WriteLine("\t测试集的错误：");
				for (int i = 0; i < testErrInx.Count(); i++)
				{
					//添加本来的标签
					sent = "\ttag:" + testErrInx[i][1];
					//添加输出的结果
					sent += " output:" + testErrInx[i][2] + "\t";
					//得到出错的句子
					for (int j = 0; j < dataset.testSet[testErrInx[i][0]].words.Count(); j++)
					{
						sent += dataset.testSet[testErrInx[i][0]].words[j];
					}
					sw.WriteLine(sent);
				}
				sw.WriteLine();
				sw.Close();
				System.Console.WriteLine("出错日志已保存！");
			}
		}

		/// <summary>
		/// 获取单句的模型输出
		/// </summary>
		/// <param name="trainer"></param>
		/// <param name="inputvec"></param>
		/// <returns></returns>
		public int GetModelOutput(clsNNTrainer trainer, double[] inputvec)
		{
			double[] output = new double[inputvec.Count()];

			//训练集输出
			output = trainer.nn.Compute(inputvec);

			//输出二值化
			double[] foutput = formatOutput(output);

			//格式化为int
			return formatInt(foutput);
		}
	}
}
