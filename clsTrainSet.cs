using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroNetworkClassifier
{
	/// <summary>
	/// ¡¾ÑµÁ·¼¯¡¿
	/// </summary>
    [Serializable]
    public class clsTrainSet
    {

		public double[][] input;
		public double[][] output;

		public clsTrainSet(double[][] _input, double[][] _output)
		{
			input = _input;
			output = _output;
		}

    }
}
