using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

static class CallCs
{
    [CSharpCallLua]
    public static List<Type> list = new List<Type>()
    {
        typeof(Action),
        typeof(Action<int,int>),
        typeof(Action<int,int,int,int>),
        typeof(Action<GameObject,GameObject>),
        typeof(GameObject),
        typeof(Transform),
    };

    [LuaCallCSharp]
    public static List<Type> listt = new List<Type>()
    {
        typeof(GameObject),
        typeof(Transform),
    };

}


public class HelloLua : MonoBehaviour
{
    Dictionary<char, string[]> ToDic(string[] array)
    {
        Dictionary<char, string[]> dic = new Dictionary<char, string[]>();
        Dictionary<char, List<string>> temp = new Dictionary<char, List<string>>();
        foreach (var ch in array)
        {
            if (!temp.ContainsKey(ch[0]))
                temp.Add(ch[0], new List<string>());
            temp[ch[0]].Add(ch);
        }

        foreach (var item in temp)
        {
            dic.Add(item.Key, item.Value.ToArray());
        }
        return dic;
    }

    [CSharpCallLua]
    public delegate int pring(int a, int b, out int oa);

    void Start()
    {
        // Prime(1, 50);

        // var array = new[] { "aa", "bc", "bb", "cb", "ab", "ac", "cc", "ca", "ba" };
        // Dictionary<char, string[]> dic = ToDic(array);
        // foreach (var item in dic)
        // {
        //     Debug.Log(item.Key);
        //     foreach (var ii in item.Value)
        //     {
        //         Debug.Log(ii);
        //     }
        // }

        LuaEngine.luaEnv.DoString("require 'Lua/LuaMain'");
        LuaEngine.luaEnv.Global.Get<Action>("Start")();
    }


    // Update is called once per frame
    void Update()
    {
        LuaEngine.luaEnv.Global.Get<Action>("Updata")();
    }

    void Prime(int star, int end)
    {
        if (star < 1) star = 1;
        if (end < star) end = star + 1;
        for (int i = star; i <= end; i++)
        {
            if (isPrime(i)) Debug.Log(i);
        }
    }

    bool isPrime(int num)
    {
        if (num == 1) return false;
        for (int i = 2; i < num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}



[CSharpCallLua]
public interface ILuaClass
{
    string Name { get; set; }

    int Age { get; set; }

    bool isFamle { get; set; }
    void PringName();
}

