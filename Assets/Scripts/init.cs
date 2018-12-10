using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
[System.Serializable]
public struct RemoteConfig
{
    public int port;
    public string ip;
}

public class init : MonoBehaviour
{
    private void Awake()
    {
        TextAsset textAsset;
        Object assets  = ResourcesLoad.Instance.LoadAsset("config");
        if (assets)
        {
            textAsset = (TextAsset)assets;
            string content = System.Text.Encoding.UTF8.GetString(textAsset.bytes);
            Debug.Log(content);
            JsonData remoteConfig = JsonMapper.ToObject(content);
            SocketClient.remoteServerIP = (string)remoteConfig[0]["ip"];
            SocketClient.remoteServerPORT = (string)remoteConfig[0]["port"];

            Debug.Log(SocketClient.remoteServerIP+ SocketClient.remoteServerPORT);
        }

        SocketClient.Instance.Connect();
        if (SocketClient.Instance.connectStatus == "success")
        {
            
        }
        Debug.Log(SocketClient.Instance.connectStatus);
    }
}
