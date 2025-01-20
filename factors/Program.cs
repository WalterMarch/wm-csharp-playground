int NUMBER = 100;
List<int> factorList = [1, NUMBER];

for (int i = 2; i < NUMBER; i++) {
    if (!factorList.Contains(i) && NUMBER % i ==0) {
        factorList.Add(i);
        if (NUMBER / i != i) {factorList.Add(NUMBER / i);}
    }
}

factorList.Sort();

foreach (int factor in factorList) {
    Console.Write(factor + " ");
}

Console.WriteLine();