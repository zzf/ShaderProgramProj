﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class CSharpLuaTest_CommonTransferWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(CSharpLuaTest.CommonTransfer), typeof(System.Object));
		L.RegFunction("SetPlayerInfo", SetPlayerInfo);
		L.RegFunction("New", _CreateCSharpLuaTest_CommonTransfer);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCSharpLuaTest_CommonTransfer(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				CSharpLuaTest.CommonTransfer obj = new CSharpLuaTest.CommonTransfer();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: CSharpLuaTest.CommonTransfer.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPlayerInfo(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
				string arg2 = ToLua.CheckString(L, 3);
				CSharpLuaTest.CommonTransfer.SetPlayerInfo(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 4)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
				string arg2 = ToLua.CheckString(L, 3);
				int arg3 = (int)LuaDLL.luaL_checknumber(L, 4);
				CSharpLuaTest.CommonTransfer.SetPlayerInfo(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 5)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
				string arg2 = ToLua.CheckString(L, 3);
				int arg3 = (int)LuaDLL.luaL_checknumber(L, 4);
				int arg4 = (int)LuaDLL.luaL_checknumber(L, 5);
				CSharpLuaTest.CommonTransfer.SetPlayerInfo(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: CSharpLuaTest.CommonTransfer.SetPlayerInfo");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

