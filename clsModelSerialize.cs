using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NeuroNetworkClassifier
{
	/// <summary>
	/// 【神经网络模型序列化】
	/// </summary>
    public class clsModelSerialize
    {
		/// <summary>
		/// 模型序列化
		/// </summary>
		/// <param name="trainer"></param>
        public void Serialize(clsNNTrainer trainer, string filename = "Classifier.model")
        {
			System.Console.WriteLine("模型‘" + filename + "’正在序列化保存...");
			trainer.saving_model = true;
			using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(fs, trainer);
			}
			trainer.saving_model = false;
			System.Console.WriteLine("模型‘" + filename + "’保存成功！\n");
        }

		/// <summary>
		/// 模型反序列化
		/// </summary>
		/// <returns></returns>
        public clsNNTrainer DeSerialize(string filename = "Classifier.model")
        {
			try
			{
				clsNNTrainer trainer;
				System.Console.WriteLine("正在反序列化加载模型‘" + filename + "’...");
				using (FileStream fs = new FileStream(filename, FileMode.Open))
				{
					BinaryFormatter formatter = new BinaryFormatter();
					trainer = (clsNNTrainer)formatter.Deserialize(fs);
				}
				System.Console.WriteLine("模型‘" + filename + "’加载成功！\n");

				if (trainer.nn.trainset_err.Count > 0 && trainer.nn.testset_err.Count > 0)
				{
					trainer.modelmsg = "模型结构：[";
					for (int j = 0; j < trainer.nn.layer_num.Length; j++)
						trainer.modelmsg += j < trainer.nn.layer_num.Length - 1 ? trainer.nn.layer_num[j] + "-" : trainer.nn.layer_num[j].ToString();
					trainer.modelmsg += " 迭代" + trainer.nn.trained_times + "次]    模型性能[" +
						(trainer.nn.trainset_err[trainer.nn.trainset_err.Count - 1] * 100).ToString("f1") + ", " +
						(trainer.nn.testset_err[trainer.nn.testset_err.Count - 1] * 100).ToString("f1") + "]";
				}
				else
				{
					trainer.modelmsg = "模型结构：[";
					for (int j = 0; j < trainer.nn.layer_num.Length; j++)
						trainer.modelmsg += j < trainer.nn.layer_num.Length - 1 ? trainer.nn.layer_num[j] + "-" : trainer.nn.layer_num[j].ToString();
					trainer.modelmsg += " 迭代" + trainer.nn.trained_times + "次]    模型性能[0, 0]";
				}

				
				//System.Console.WriteLine(trainer.modelmsg);
				return trainer;
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex + "\n模型‘" + filename + "’加载失败，请检查文件是否存在！\n");
				throw new FileNotFoundException("模型‘" + filename + "’加载失败，请检查文件是否存在！");
			}
			
        }
    }
}