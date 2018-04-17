using System;
using System.Collections.Generic;
using UnityEngine;

class InventoryManager : MonoBehaviour
{
	public List<string> keys =  new List<string>();
    static int instances = 0;

    void Awake()
    {
        instances++;
        if (instances > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
    }
}

