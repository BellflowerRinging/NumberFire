using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        LuaEngine.luaEnv.Global.Get<Action<GameObject, GameObject>>("OnTriggerEnter")(gameObject, other.gameObject);
    }
}
