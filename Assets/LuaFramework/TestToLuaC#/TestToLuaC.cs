using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaFramework;
using LuaInterface;
using System.IO;

public class TestToLuaC : MonoBehaviour {

    private string m_luaString = @"
                                                        print('This is a program use DoString by lua script... ...')
                                                    ";

    private LuaState m_state = null;
	// Use this for initialization
	void Start () {
        // creat lua Virtual Mechine
        m_state = new LuaState();
        // start lua VM
        m_state.Start();        

        // add lua search path
        string path = AppConst.FrameworkRoot + Path.DirectorySeparatorChar + "Lua/TestToLuaC";
        m_state.AddSearchPath(path);

        // TestToLua1();
        TestToLua2();
        
    }

    void TestToLua1()
    {
        // Cal lua script by DoString
        m_state.DoString(m_luaString);

        string filename = "TestToLuaC";
        m_state.DoFile(filename);
    }

    void TestToLua2()
    {
        string filename = "TestToLuaC2";
        m_state.DoFile(filename);

        //这里获取不到
        GameLogger.Log("Get Lua Local Value : " + m_state["local_num"]);

        //可以读取到全局的变量
        GameLogger.Log("Get Lua Value : " + m_state["global_num"]);
        m_state["global_num"] = 10;
        GameLogger.Log("Set Lua Value : " + m_state["global_num"]);

        //调用lua方法
        LuaFunction luaFunc = m_state.GetFunction("Count");
        luaFunc.Call();
        GameLogger.Log("Get Lua Value : " + m_state["global_num"]);
        //也可以直接
        m_state.Call("Count", false);
        GameLogger.Log("Get Lua Value : " + m_state["global_num"]);

        //方法传入参数
        LuaFunction valueFunc = m_state.GetFunction("InputValue");
        valueFunc.BeginPCall();
        valueFunc.Push("-- 这是CSharp中的参数----");
        valueFunc.PCall();
        valueFunc.EndPCall();

        valueFunc.Call("--这是CSharp中直接调用传入参数-----");

        // Get Table
        LuaTable table = m_state.GetTable("mytable");
        table.Call("tableFunc");

        LuaFunction tableFunc = table.GetLuaFunction("tableFunc");
        GameLogger.Log("Lua Table Function");
        tableFunc.Call();
        //这里访问的时table的变量，不是local或者全局变量
        GameLogger.Log("Get Table Value local_num : " + table["local_num"]);
        GameLogger.Log("Get Table Value global_num : " + table["global_num"]);
        GameLogger.Log("Get Table Value table_num : " + table["table_num"]);
        for (int i = 0; i < table.Length; ++i)
        {
            GameLogger.Log("table " + i.ToString() + " : " + table[i+1]);
        }

        LuaDictTable dicTable = table.ToDictTable();
        foreach(var item in dicTable)
        {
            GameLogger.LogFormat("dicTable {0} -- {1}", item.Key, item.Value);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        // gc lua VM
        m_state.Dispose();

        GameLogger.Log("Lua Complete");
    }
}
