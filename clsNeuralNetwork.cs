using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace NeuroNetworkClassifier
{
    /// <summary>
    /// Represents a multi layer nueral network, that has n-many
    /// input nodes, n-many hidden nodes, and n-many output nodes.
    /// This class provides a method to do a full forward through
    /// network for a set of applied inputs
    /// </summary>
    
    [Serializable]

    public class clsNeuralNetwork
    {
        #region Instance Fields
		//private fields
        private double[,] i_to_h_wts;
        private double[,] h_to_o_wts;
        private double[] inputs;
        private double[] hidden;
        private double[] outputs;
        private double learningRate = 0.3;
        private Random gen = new Random();

        public int num_in;
		public int num_hid;
		public int num_out;
		public int trained_times;
		public List<double> trainset_perf = new List<double>();
		public List<double> testset_perf = new List<double>();

        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new NeuralNetwork, using the parameters
        /// provided
        /// </summary>
        /// <param name="num_in">Number of inputs nodes</param>
        /// <param name="num_hid">Number of hidden nodes</param>
        /// <param name="num_out">Number of output nodes</param>
        public clsNeuralNetwork(int num_in, int num_hid, int num_out)
        {
            this.num_in = num_in;
            this.num_hid = num_hid;
            this.num_out = num_out;
            i_to_h_wts = new double[num_in + 1, num_hid];
            h_to_o_wts = new double[num_hid + 1, num_out];
            inputs = new double[num_in + 1];
            hidden = new double[num_hid + 1];
			outputs = new double[num_out];
			trained_times = 0;
			System.Console.WriteLine("神经网络结构：" + num_in + " - " + num_hid + " - " + num_out);
        }
        #endregion
        #region Initialization of random weights
        /// <summary>
        /// Randomly initialise all the network weights.
        /// Need to start with some weights. 
        /// This method sets up the input to hidden nodes and
        /// hidden nodes to output nodes with random values
        /// </summary>
        public void initialiseNetwork()
        {
            // Set the input value for bias node
            inputs[num_in] = 1.0;
            hidden[num_hid] = 1.0;
            // Set weights between input & hidden nodes.
            for (int i = 0; i < num_in + 1; i++)
            {
                for (int j = 0; j < num_hid; j++)
                {
                    // Set random weights between -2 & 2
                    i_to_h_wts[i, j] = (gen.NextDouble() * 4) - 2;
                }
            }
            // Set weights between hidden & output nodes.
            for (int i = 0; i < num_hid + 1; i++)
            {
                for (int j = 0; j < num_out; j++)
                {
                    // Set random weights between -2 & 2
                    h_to_o_wts[i, j] = (gen.NextDouble() * 4) - 2;
                }
            }
        }
        #endregion

        #region Pass forward
        /// <summary>
        /// Does a complete pass through within the network, using the
        /// applied_inputs parameters. The pass thorugh is done to the
        /// input to hidden, and hidden to ouput layers
        /// </summary>
        /// <param name="applied_inputs">An double[] array which holds input values, which
        /// are then preseted to the networks input layer</param>
        public void pass_forward(double[] applied_inputs)
        {
            // Load a set of inputs into our current inputs
            for (int i = 0; i < num_in; i++)
            {
                inputs[i] = applied_inputs[i];
            }

            // Forward to hidden nodes, and calculate activations in hidden layer
            for (int i = 0; i < num_hid; i++)
            {
                double sum = 0.0;
                for (int j = 0; j < num_in + 1; j++)
                {
                    sum += inputs[j] * i_to_h_wts[j, i];
                }
                hidden[i] = clsActivationFunction.Sigmoid(sum);
            }
            // Forward to output nodes, and calculate activations in output layer
            for (int i = 0; i < num_out; i++)
            {
                double sum = 0.0;
                for (int j = 0; j < num_hid + 1; j++)
                {
                    sum += hidden[j] * h_to_o_wts[j, i];
                }
                //pass the sum, through the activation function, Sigmoid in this case
                //which allows for backward differentation
                outputs[i] = clsActivationFunction.Sigmoid(sum);
            }
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// gets / sets the number of input nodes for the Neural Network
        /// </summary>
        public int NumberOfInputs
        {
            get { return num_in; }
            set { num_in = value; }
        }

        /// <summary>
        /// gets / sets the number of hidden nodes for the Neural Network
        /// </summary>
        public int NumberOfHidden
        {
            get { return num_hid; }
            set { num_hid = value; }
        }

        /// <summary>
        /// gets / sets the number of output nodes for the Neural Network
        /// </summary>
        public int NumberOfOutputs
        {
            get { return num_out; }
            set { num_out = value; }
        }

        /// <summary>
        /// gets / sets the input to hidden weights for the Neural Network
        /// </summary>
        public double[,] InputToHiddenWeights
        {
            get { return i_to_h_wts; }
            set { i_to_h_wts = value; }
        }

        /// <summary>
        /// gets / sets the hidden to output weights for the Neural Network
        /// </summary>
        public double[,] HiddenToOutputWeights
        {
            get { return h_to_o_wts; }
            set { h_to_o_wts = value; }
        }

        /// <summary>
        /// gets / sets the input values for the Neural Network
        /// </summary>
        public double[] Inputs
        {
            get { return inputs; }
            set { inputs = value; }
        }

        /// <summary>
        /// gets / sets the hidden values for the Neural Network
        /// </summary>
        public double[] Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }

        /// <summary>
        /// gets / sets the outputs values for the Neural Network
        /// </summary>
        public double[] Outputs
        {
            get { return outputs; }
            set { outputs = value; }
        }

        /// <summary>
        /// gets / sets the LearningRate (eta) value for the Neural Network
        /// </summary>
        public double LearningRate
        {
            get { return learningRate; }
            set { learningRate = value; }
        }
        #endregion
    }
}
