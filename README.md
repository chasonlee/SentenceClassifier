# SentenceClassifier
an ANN-based chinese sentence classifier

## 说明
- 这是一个基于中文词向量和BP神经网络的中文句子分类器，句子向量目前只是简单的词向量拼接，若出现新词，则为其随机生成词向量。
- 已测试的开发环境：WIN10 + VS2015

## 训练模型
- 进入bin\x64\Debug目录下，运行**NeuroNetworkClassifier.exe**，点击**加载词向量**，选择当前目录下的**wiki.zh.text.jian.seg.vector**词向量文件。
- 加载词向量完成后，加载数据集，选择**dataset5**文件夹下的所有文件，加载过程可能需要十几秒。数据集加载完成后，程序会将数据随机分离成训练集和测试集。现在在当前目录下会生成一个**DataVector.vecmap**文件，这是当前生成的向量映射表，以后需要继续训练模型时，可以直接加载此映射表，不需要再加载词向量和数据集。
- 通过点击**保存映射表**，可以将此映射表另存为其他名字。
- 有了训练集和测试集后，接下来点击**训练新模型**，可以在新窗口中设置神经网络的隐藏层结构，默认只有一层，10个节点，点击数字后可以在下方修改，也可以添加更多隐藏层，并任意修改节点数，确定后便会开始训练模型，模型训练迭代两次后就能看到动态的性能曲线图。训练开始后，可以随时停止和开始训练，训练结果默认每次迭代都会保存到**Classifier.model**。

## 加载模型
- 运行 **NeuroNetworkClassifier.exe** ，可以直接点击加载模型，选择当前目录下的**Classifier_[1492-167]_12400-20-12_650--3--44.model** 
![](https://github.com/ChasonLee/SentenceClassifier/raw/master/img/model1.jpg)
- 这是我自己训练过的模型。目前由于训练样本太少，测试集的误差率依然很高，红色是训练集误差，蓝色是测试集误差。
- 现在再点击**加载模型**，选择**Classifier_[20296-2184]_10400-20-12_560--2--6.model** 
![](https://github.com/ChasonLee/SentenceClassifier/raw/master/img/model2.jpg)
- 这个是较大样本的训练结果，可以看到现在的模型性能表现相对较好。

## 引用
- 中文词向量来源于维基百科，参考：[中英文维基百科语料上的Word2Vec实验](http://www.52nlp.cn/%E4%B8%AD%E8%8B%B1%E6%96%87%E7%BB%B4%E5%9F%BA%E7%99%BE%E7%A7%91%E8%AF%AD%E6%96%99%E4%B8%8A%E7%9A%84word2vec%E5%AE%9E%E9%AA%8C)
- 加载数据集时，使用的中文分词算法来源于[哈工大LTP](http://www.ltp-cloud.com/)
　　
