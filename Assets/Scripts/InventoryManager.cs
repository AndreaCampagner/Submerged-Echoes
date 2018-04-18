﻿using System;
using System.Collections.Generic;
using UnityEngine;

class InventoryManager : MonoBehaviour
{
	public List<string> keys;
    static int instances = 0;

    void Awake()
    {
        keys = new List<string>();
        instances++;
        if (instances > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
    }

    public void OnEnd()
    {
        keys.Clear();
    }
}

