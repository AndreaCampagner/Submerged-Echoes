using System;
using System.Collections.Generic;
using UnityEngine;

class InventoryManager : MonoBehaviour
{
    public int keys = 0;
    static int instances = 0;

    void Awake()
    {
        instances++;
        if (instances > 1)
            Destroy(this);
        DontDestroyOnLoad(this);
    }
}

