using System.ComponentModel.DataAnnotations;

int MAX = 100;

for (int i = 1; i <= MAX; i++) {
    string output = "";
    if (i % 3 == 0) {output += "Fizz";}
    if (i % 5 == 0) {output += "Buzz";}
    Console.WriteLine(
        output == "" ? i : output
    );
}