using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NeuroNetworkClassifier
{
	/// <summary>
	/// 【数据集词向量序列化】
	/// </summary>
	public class clsDataVecSerialize
    {
		/// <summary>
		/// 数据集与词向量序列化
		/// </summary>
		/// <param name="datavec"></param>
		public void Serialize(clsDataVector datavec, string filename = "DataVector.vecmap")
        {
			using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(fs, datavec);
				System.Console.WriteLine("文件‘" + filename + "’保存成功！\n");
            }
        }

		/// <summary>
		/// 数据集与词向量反序列化
		/// </summary>
		/// <returns></returns>
		public clsDataVector DeSerialize(string filename = "DataVector.vecmap")
        {
			clsDataVector datavec = new clsDataVector();
			try
			{
				using (FileStream fs = new FileStream(filename, FileMode.Open))
				{
					BinaryFormatter formatter = new BinaryFormatter();
					datavec = (clsDataVector)formatter.Deserialize(fs);
					System.Console.WriteLine("文件‘" + filename + "’读取成功！\n");
				}
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex + "\n文件‘" + filename + "’读取失败，请检查文件是否存在！\n");
				throw new FileNotFoundException("文件‘" + filename + "’读取失败，请检查文件是否存在！");
			}
            
			return datavec;
        }
    }
}