using static System.Console;
int i = 1;
do                              //do while Döngüsü
{
    WriteLine($"do While: dönüş değeri : {i}");
    i++;
} while (i <= 10);
int j =1;
while (j <= 10)                 //while Döngüsü
{
    WriteLine($"While: dönüş değeri : {j}");
    j++;
}
for (int k = 0; k <= 10; k++)    //for Döngüsü
{
    WriteLine($"for: dönüş değeri : {k}");
}
ReadKey();
