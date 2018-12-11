using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using System.Net;


public class SocketClient
{
    Socket socket;
    public static string remoteServerIP;
    public static string remoteServerPORT;

    static SocketClient instance;
    public static SocketClient Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SocketClient();
            }
            return instance;
        }
    }

    public Socket Socket
    {
        get
        {
            if (socket == null)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            return socket;
        }
    }
    IPEndPoint point;

    IPEndPoint GetPoint
    {
        get
        {
            if (point == null)
            {
                point = new IPEndPoint(IPAddress.Parse(remoteServerIP), int.Parse(remoteServerPORT));
            }
            return point;
        }
    }

    public string connectStatus = "noconnect";
    public string Connect()
    {
        try
        {
            connectStatus = "connecting";
            Debug.Log("=========>>L>");
            Socket.Connect(GetPoint);
            Debug.LogFormat("Connect to {0} , port :{1} ", GetPoint.Address.ToString(), GetPoint.Port);
            connectStatus = "success";
            return connectStatus;
        }
        catch (System.Exception e)
        {
            connectStatus = "connected";
            Debug.LogFormat("连接失败{0} msg :{1}", connectStatus, e.Message);
            return connectStatus;
        }

    }
    public static void Dispose()
    {
        if (instance != null && instance.socket != null && (instance.socket.Connected == true))
        {
            instance.socket.Disconnect(true);
            instance.socket.Close();
            //instance.socket.Dispose();
        }
    }


    //public void Register(string cmd ,)
    //{

    //}
}
