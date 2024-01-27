using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroNetworkClassifier
{
	/// <summary>
	/// °æ≤‚ ‘ºØ°ø
	/// </summary>
    [Serializable]
	public class clsTestSet
    {
		public double[] testSetVec;
		public double[] testSetOutput;

		public clsTestSet(double[] _testSetVec, double[] _testSetOutput)
		{
			testSetVec = _testSetVec;
			testSetOutput = _testSetOutput;
		}

    }
}
