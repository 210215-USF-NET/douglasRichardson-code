using System;
namespace CalculatorBL
{
    public class CalculatorRun
    {
        public int Addition(int x, int y){
            return x+y;
        }
        public int Substraction(int x, int y){
            return x-y;
        }
        public int Multiplication(int x, int y){
            return x*y;
        }
        public int Division(int x, int y){
            return x/y;
        }
        public int Fib(int x){
            int firstnumber = 0, secondnumber = 1, result = 0;  
            if (x == 0) return 0; //To return the first Fibonacci number   
            if (x == 1) return 1; //To return the second Fibonacci number   
            for (int i = 2; i <= x; i++)  
            {  
                result = firstnumber + secondnumber;  
                firstnumber = secondnumber;  
                secondnumber = result;  
            }  
   
            return result;  
        }
        public Boolean PrimeNumber(int x){
            if (x <= 1)
                return false;
            else if (x % 2 == 0)
                return x == 2;

            long N = (long) (Math.Sqrt(x) + 0.5);

            for (int i = 3; i <= N; i += 2)
            if (x % i == 0)
                return false; 

            return true;
        }
        public Boolean EquationBalanced(){
            return true;
        }
    }
}