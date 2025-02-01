int factorial(int n) {
    int output = 1;
    if (n > 1) {
        output = n * (factorial(n-1));
    }
    return output;
}

Console.WriteLine(factorial(6));