---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by admin.
--- DateTime: 2019/5/14 15:56
---
lua_obj = nil
lua_obj2 = nil

function InitValue(go)
    print('Lua Call function InitValue params: ' .. tostring(go.name))

    lua_obj = go
    print("lua_obj = " .. tostring(lua_obj))
end

function TestValue()
    print("lua_obj == nil : " .. tostring(lua_obj == nil))
    print("lua_obj == null : " .. tostring(lua_obj == null))
    print("lua_obj:Equal(nil) : " .. tostring(lua_obj:Equals(nil)))
    print("lua_obj:Equal(null) : " .. tostring(lua_obj:Equals(null)))
end

function InitValue2()
    print("InitValue2")
    lua_obj2 = UnityEngine.GameObject.New("Lua_obj2")
    print("lua_obj2 = " .. tostring(lua_obj2))
end

function TestValue2()
    print("TestValue2")
    UnityEngine.GameObject.DestroyImmediate(lua_obj2)
    print("lua_obj2 == nil : " .. tostring(lua_obj2 == nil))
    print("lua_obj2 == null : " .. tostring(lua_obj2 == null))
    print("lua_obj2:Equal(nil) : " .. tostring(lua_obj2:Equals(nil)))
    print("lua_obj2:Equal(null) : " .. tostring(lua_obj2:Equals(null)))
end

function TestValue3()
    print("TestValue3")
    local lua_obj3 = UnityEngine.GameObject.New("lua_obj3")
    UnityEngine.GameObject.DestroyImmediate(lua_obj3)
    print("lua_obj3 == nil : " .. tostring(lua_obj3 == nil))
    print("lua_obj3 == null : " .. tostring(null == lua_obj3))
    print("lua_obj3:Equal(nil) : " .. tostring(lua_obj3:Equals(nil)))
    print("lua_obj3:Equal(null) : " .. tostring(lua_obj3:Equals(null)))
end

function TestValue4()
    local tt = {0, "data", 2, 3, 4, {"child01", 1}}
    return tt
end