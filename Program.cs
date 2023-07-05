using ProbabilisticAlgorithm;

CountMinSketch cms = new CountMinSketch(4, 100);
cms.Add("apple", 5);
cms.Add("banana", 3);
cms.Add("cherry", 74);
cms.Add("cherry", 70);
cms.Add("cherry", 6);
cms.Add("cherry", 7);
int count = cms.Count("apple");
Console.WriteLine(count); 
