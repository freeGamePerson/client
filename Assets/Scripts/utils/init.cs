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
        Object assets = ResourcesLoad.Instance.LoadAsset("config");
        if (assets)
        {
            textAsset = (TextAsset)assets;
            string content = System.Text.Encoding.UTF8.GetString(textAsset.bytes);
            Debug.Log(content);
            JsonData remoteConfig = JsonMapper.ToObject(content);

            NetWorkServices.Instance.StartUp((string)remoteConfig[0]["ip"], (string)remoteConfig[0]["port"]);
        }



    }
}
