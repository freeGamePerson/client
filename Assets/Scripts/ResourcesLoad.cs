using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoad
{
    static ResourcesLoad instance;

    public static ResourcesLoad Instance
    {
        get
        {

            if (instance == null)
            {
                instance = new ResourcesLoad();
            }
            return instance;
        }
    }

    private ResourcesLoad() { }

    public Object LoadAsset(string path)
    {
        Object ob = Resources.Load(path);

        if (ob == null)
        {
            Debug.LogError("load error "+ path);
        }
        return ob;
    }
}
