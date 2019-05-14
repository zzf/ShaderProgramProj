using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaFramework;
using LuaInterface;
using System.IO;

public class TestCNullLuaNil : MonoBehaviour {

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
}
