using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;

public class NetWorkServices : MonoBehaviour
{

    static NetWorkServices netWorkServices;

    public static byte[] buffer = new byte[4096];
    public static NetWorkServices Instance
    {
        get
        {
            if (netWorkServices == null)
            {
                netWorkServices = (new GameObject("NetWorkServices")).AddComponent<NetWorkServices>();
            }
            return netWorkServices;
        }
    }

    private void Awake()
    {

    }
    private void Start()
    {

    }



    void ReceiveCallback(IAsyncResult asyncResult)
    {
        int len = SocketClient.Instance.Socket.EndReceive(asyncResult);
        //Receive();
        Debug.Log("接受到数据:   "+ len);
    }

    public void Connect()
    {
        SocketClient.Instance.Connect();
        if (SocketClient.Instance.connectStatus == "success")
        {
            string args = "1111";

            byte[] bs = System.Text.Encoding.UTF8.GetBytes(args);
            SocketClient.Instance.Socket.Send(bs);
            Receive();
        }
        Debug.Log(SocketClient.Instance.connectStatus);
    }

    void Receive()
    {
        SocketClient.Instance.Socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, buffer);
    }

    public void StartUp(string ip, string port)
    {
        SocketClient.remoteServerIP = ip;
        SocketClient.remoteServerPORT = port;

        Debug.Log(SocketClient.remoteServerIP + SocketClient.remoteServerPORT);
    }

    private void Update()
    {

    }

    private void OnDestroy()
    {
        SocketClient.Dispose();
    }
}
