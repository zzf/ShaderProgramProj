using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaFramework;
using LuaInterface;
using System.IO;

public class TestCNullLuaNil : Base {

    private LuaState m_luastate = null;
	// Use this for initialization
	void Start () {
        m_luastate = new LuaState();
        m_luastate.Start();

        //绑定C#的方法
        LuaBinder.Bind(m_luastate);
        // add lua search path
        string path = AppConst.FrameworkRoot + Path.DirectorySeparatorChar + "Lua/TestToLuaC";
        m_luastate.AddSearchPath(path);

        string luafile = "TestLuaNil";
        m_luastate.DoFile(luafile);

        Test_01();

        StartCoroutine(DelayCall1());

        StartCoroutine(DelayCall2());

        StartCoroutine(DelayCall3());

        StartCoroutine(DelayCall5());

        StartCoroutine(DelayCall6());
    }

    void Test_01()
    {
        GameObject go = new GameObject("Go");
        LuaFunction luafunc = m_luastate.GetFunction("InitValue");
        luafunc.Call(go);
        GameObject.DestroyImmediate(go);
        //GameObject.Destroy(go);

        LuaFunction luafunc2 = m_luastate.GetFunction("TestValue");
        luafunc2.Call();
    }

    void Test02()
    {
        LuaFunction luafunc1 = m_luastate.GetFunction("InitValue2");
        luafunc1.Call();
        LuaFunction luafunc2 = m_luastate.GetFunction("TestValue2");
        luafunc2.Call();
    }

    void Test03()
    {
        LuaFunction luafunc = m_luastate.GetFunction("TestValue3");
        luafunc.Call();
    }

    void Test04()
    {
        LuaFunction luafunc = m_luastate.GetFunction("TestValue4");
        object[] objs = luafunc.Invoke<object[]>();
        if(objs.Length > 0)
        {
            GameLogger.LogGreen("objs.Length = " + objs.Length.ToString());
            var data = objs[0];
            data = objs[1];
            data = objs[objs.Length - 1];
            var child1 = ((LuaTable)data)[1];
            var child2 = ((LuaTable)data)[2];
            GameLogger.LogGreen("-------------child1 = " + child1 + "; child2 = " + child2);
            //GameLogger.LogGreen("objs[0] = " + ((int)(objs[0])).ToString());
            //GameLogger.LogGreen("objs[end] = " + (int)(objs[objs.Length-1]));
        }

        objs = new object[] { long.MaxValue - 1, long.MaxValue - 2, long.MaxValue - 3, long.MaxValue - 4 };
        //这里long不能直接强转为int
        var data1 = System.Convert.ToInt64(objs[0]);
        data1 = (long)(objs[1]);
        data1 = (long)(objs[2]);
        long data2 = (long)(objs[3]);
        long data3 = data2 + 1;
    }

    void Test05()
    {
        GameObject go = new GameObject();
        GameLogger.LogGreen("Test05");
    }

    //C#传递lua表到Lua脚本
    void TestTableToLua()
    {
        m_luastate.LuaCreateTable(0, 0);
        LuaTable tab = m_luastate.CheckLuaTable(-1);
        tab["name"] = "zzf";
        tab["id"] = 10001;

        m_luastate.LuaCreateTable();
        LuaTable tab1 = m_luastate.CheckLuaTable(-1);
        for(int i = 0; i < 10; ++i)
        {
            m_luastate.LuaCreateTable(0, 0);
            LuaTable tempTab = m_luastate.CheckLuaTable(-1);
            for(int j = 0; j < 10; ++j)
            {
                tempTab[j + 1] = 100 + j;
            }
            tab1[i + 1] = tempTab;
        }
        tab["data"] = tab1;
        LuaFunction luaFunc = m_luastate.GetFunction("TestTableToLua");
        luaFunc.Call(tab);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private IEnumerator DelayCall1()
    {
        yield return new WaitForSeconds(1);
        Test02();
    }

    private IEnumerator DelayCall2()
    {
        yield return new WaitForSeconds(3);
        Test03();
    }

    private IEnumerator DelayCall3()
    {
        yield return new WaitForSeconds(4);
        Test04();
    }

    private IEnumerator DelayCall5()
    {
        yield return new WaitForSeconds(5);
        Test05();
    }

    private IEnumerator DelayCall6()
    {
        yield return new WaitForSeconds(2);
        TestTableToLua();
    }
}
