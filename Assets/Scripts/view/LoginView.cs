using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    FindTool tool;
    void Start()
    {
        tool = GetComponent<FindTool>();

        if (tool == null)
        {
            tool = gameObject.AddComponent<FindTool>();
        }

        tool.Childs["Text"].GetComponent<Text>().text = "请登录";
        tool.GetComponent<Button>().onClick.AddListener(()=>
        {
            NetWorkServices.Instance.Connect();
        });
    }

    void Update()
    {

    }
}
