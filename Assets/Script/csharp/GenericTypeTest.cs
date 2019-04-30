using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTest
{
    //Generic Class
    public class GenericTypeTest<T>
    {
        private T[] list = null;
        public GenericTypeTest(int size)
        {
            list = new T[size];
        }

        public T GetItem(int index)
        {
            return list[index];
        }

        public void SetItem(int index, T t)
        {
            list[index] = t;
        }
    }

    public class GameMain
    {
        public void Main()
        {
            GenericTypeTest<int> intlist = new GenericTypeTest<int>(3);
            GenericTypeTest<string> strlist = new GenericTypeTest<string>(5);

            for(int i = 0; i < 3; ++i)
            {
                intlist.SetItem(i, 1000 + i);
            }

            for(int i = 0; i < 5; ++i)
            {
                strlist.SetItem(i, "value_" + i.ToString());
            }
        }
        

        //Generic Function
        //Exchange values
        public void ExchangeValue<T>(ref T value1, ref T value2)
        {
            T temp = value1;
            value2 = value1;
            value1 = temp;
        }
        public void TestGenericFunc()
        {
            int int_value1 = 1, int_value2 = 2;
            string str_value1 = "string1", str_value2 = "string2";
            ExchangeValue<int>(ref int_value1, ref int_value2);
            ExchangeValue<string>(ref str_value1, ref str_value2);
        }

        //Generic Delegate
        public delegate void ChangeNumber<T>(T t);

        private void AddNum(int value)
        {

        }

        private void SumNum(int value)
        {

        }

        private void MultiplyNum(double value)
        {

        }
        
        public void TestChangeNumber()
        {
            ChangeNumber<int> cn1 = new ChangeNumber<int>(AddNum);
            ChangeNumber<int> cn2 = new ChangeNumber<int>(SumNum);
            ChangeNumber<double> cn3 = new ChangeNumber<double>(MultiplyNum);

            cn1(10);
            cn2(20);
            cn3(8.8f);

            ChangeNumber<double> cn4 = cn3;
            ChangeNumber<double> cn5 = new ChangeNumber<double>(MultiplyNum);
            cn4 += cn5;
            cn4(100.0);
        }
    }

    //在封装公共组件时，有时候不需要关注传递过来的参数时什么，这个时候可以用泛型；
    //用where对泛型进行约束
    public class UnityEntityTest<T> where T : GameMain
    {
        public void CacheData<T>(T data, string key)
        {

        }

        public void RemoveCacheData<T>(T data, string key)
        {

        }
    }
   
}
