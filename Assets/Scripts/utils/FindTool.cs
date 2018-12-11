using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTool : MonoBehaviour
{
    Dictionary<string, FindTool> childs;

    FindTool parent;

    public Dictionary<string, FindTool> Childs
    {
        get
        {
            if (childs == null)
            {
                childs = new Dictionary<string, FindTool>();
            }
            return childs;
        }
    }

    private void Awake()
    {

        foreach (Transform item in transform)
        {
            FindTool tool = item.GetComponent<FindTool>();

            if (tool)
            {
                tool.parent = this;
                Childs[item.name] = tool;
            }
        }
    }

    private void OnDestroy()
    {
        if (this.parent && this.parent.Childs.ContainsKey(gameObject.name))
        {
            this.parent.Childs.Remove(gameObject.name);
        }
    }
}
