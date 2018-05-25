# NeuralNetwork
Simple example of a neural network in C#

## Clasification decimal numbers
1 inputs 
10 outputs 
```
Net nn = new Net(0.9, new int[] { 1, 10, 10});
```

Traning Set
```
List<DataSet> ds = new List<DataSet>();
            ds.Add(new DataSet(new double[] { 0.0 }, new double[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.1 }, new double[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.2 }, new double[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.3 }, new double[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.4 }, new double[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.5 }, new double[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.6 }, new double[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.7 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }));
            ds.Add(new DataSet(new double[] { 0.8 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }));
            ds.Add(new DataSet(new double[] { 0.9 }, new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }));
```
![alt text](https://github.com/pablopace/NeuralNetwork/blob/master/ImagesReadme/clasif.PNG)



## Solving XOR problem
2 inputs 
1 outputs 
```
Net nn = new Net(0.9, new int[] {2, 2, 1});
```
```
List<DataSet> ds = new List<DataSet>();
            ds.Add(new DataSet(new double[] { 0, 0 }, new double[] { 0 }));
            ds.Add(new DataSet(new double[] { 0, 1 }, new double[] { 1 }));
            ds.Add(new DataSet(new double[] { 1, 0 }, new double[] { 1 }));
            ds.Add(new DataSet(new double[] { 1, 1 }, new double[] { 0 }));
```
![alt text](https://github.com/pablopace/NeuralNetwork/blob/master/ImagesReadme/xor.PNG)



## Acknowledgments

* NetworkHelper class (user interface) was develop by Emiliano Musso https://social.technet.microsoft.com/wiki/contents/articles/36428.basis-of-neural-networks-in-c.aspx and adpated to my Net clases. Just minor modifications ware made to the class
