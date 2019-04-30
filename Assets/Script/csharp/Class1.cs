using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTest
{
    /// <summary>
    /// 输出到控制台和文件
    /// </summary>
    /// 
    public delegate void PrintString(string content);

    public delegate void BuyItem(string name);


    public class ContentOutput
    {
        ContentOutput()
        {

        }

        public void PrintToConsole(string content)
        {
            //
        }

        public void WriteToFile(string content)
        {

        }

        public void Main()
        {
            PrintString ps1 = new PrintString(PrintToConsole);
            PrintString ps2 = new PrintString(WriteToFile);
            ps1("This is output to console !");
            ps2("This is write to file !");

            PrintString pslist = null;
            pslist = ps1;
            pslist += ps2;

            pslist("this content will be printed in the console and writeed to the file !");
        }

        public void BuyBook(string book_name)
        {
            //this will buy a book
        }

        public void BuyGun(string gun_name)
        {
            //this will buy a gun
        }

        public void Test()
        {
            BuyItem bi1 = new BuyItem(BuyBook);
            bi1("book name is beautiful man !");
            BuyItem bi2 = new BuyItem(BuyGun);
            bi2(" AK47 ");


            BuyItem bi3 = bi1;
            bi3 += bi2;
            bi3("buy a book and b gun");
        }
    }
}
