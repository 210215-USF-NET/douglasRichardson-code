using System;
using System.Collections;

namespace ActionDelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<ArrayList> addNumbers = delegate(ArrayList thisArrayList){
                int sum = 0;
                foreach (int num in thisArrayList)
                {
                    sum = sum + num;
                }
                Console.WriteLine("The sum: "+sum);
            };

            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(1);
            myArrayList.Add(4);
            addNumbers(myArrayList);
        }
    }
}
