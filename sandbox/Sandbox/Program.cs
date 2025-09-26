using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{

    static void Main(string[] args)
    {
        int x = 2;
        int y = 3;

        int sum = Adder(x, y);
        Console.WriteLine(sum);

        static int Adder(int a, int b)
        {
            return a + b;
        }
    
    }
}