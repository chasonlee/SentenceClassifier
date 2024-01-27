using System;
using System.Collections.Generic;
using System.Text;

namespace NeuroNetworkClassifier
{
    /// <summary>
    /// Provides the activation functions
    /// </summary>
    public class clsActivationFunction
    {
        /// <summary>
        /// Takes a value for a current network node, and applies a sigmoid
        /// activation function to it, which is then returned
        /// </summary>
        /// <param name="x">The value to apply the activation to</param>
        /// <returns>The activation value, after a sigmoid function</returns>
        public static double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Pow(Math.E, -x));
        }

        public static double Step(double x)
        {
            return x >= 0 ? 1 : 0;
        }
    }
}
