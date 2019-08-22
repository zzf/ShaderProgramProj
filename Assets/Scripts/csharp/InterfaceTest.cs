using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSharpTest
{
    interface IMyInterface
    {
        void Output(string content);
    }

    interface IChildInterface : IMyInterface
    {
        void ChildOutput(string child_content);
    }

    public class MyBook : IMyInterface
    {
//         void MyBook()
//         {
//              //C#中不能这样写，成员名不能与他们的封闭类型相同
//         }
        MyBook()
        {

        }
        public void Main()
        {

        }

        public void Output(string content)
        {
            //实现接口必须是public的，因为接口接口就是要给到外部调用的；

        }
    }

    public class MyChildBook : IChildInterface
    {
        MyChildBook()
        {

        }

        public void Main()
        {

        }

        public void Output(string content)
        {

        }

        public void ChildOutput(string child_content)
        {
            //必须实现全部接口
        }
    }
}
