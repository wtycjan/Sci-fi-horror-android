using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;


public class NetworkClientUI : MonoBehaviour
{
    static NetworkClient client;
    public NetworkCommands commands;
    public DoorsButtton doors;

    NumberFormatInfo nfi;
    private void OnGUI()
    {
        //GUI.Label(new Rect(20, Screen.height - 20, 200, 80), "Connnected:" + client.isConnected);
    }
    void Start()
    {
        nfi = new NumberFormatInfo();
        nfi.NumberDecimalSeparator = ".";

        ConnectionConfig config = new ConnectionConfig();
        config.AddChannel(QosType.ReliableSequenced);
        config.AddChannel(QosType.UnreliableSequenced);
        config.SendDelay = 0;
        client = new NetworkClient();
        client.Configure(config, 10);
        client.RegisterHandler(888, ServerRecieveMessage);
        Connect();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        
    }
    void ServerRecieveMessage(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message.ReadMessage<StringMessage>().value;

        if (msg.value.Length>7 && msg.value.Substring(0, 8) == "monster:")
        {
            string[] words = msg.value.Split(' ');
            commands.MonsterPosition(float.Parse(words[1], nfi), float.Parse(words[2], nfi));
            commands.MonsterLevel(float.Parse(words[3], nfi));
        }
        if (msg.value.Length > 6 && msg.value.Substring(0, 7) == "player:")
        {
            string[] words = msg.value.Split(' ');
            commands.PlayerPosition(float.Parse(words[1], nfi), float.Parse(words[2], nfi));
            commands.PlayerLevel(float.Parse(words[3], nfi));
        }
        if (msg.value.Length > 5 && msg.value.Substring(0, 6) == "Blocks")
            commands.DestroyBlocks(int.Parse(msg.value.Substring(msg.value.Length - 2)));
        if (msg.value == "OpenHelp")
            commands.OpenHelp();
        if (msg.value == "CloseHelp")
            commands.CloseHelp();
        if (msg.value == "HackingStart")
            commands.HackingStart();
        if (msg.value == "HackingEnd")
            commands.HackingEnd();
        if (msg.value == "OpenPasswords")
            commands.OpenPasswords();
        if (msg.value == "ClosePasswords")
            commands.ClosePasswords();
        if (msg.value.Length > 3 && msg.value.Substring(0, 4) == "Pswd")
            GameData.password = (msg.value.Substring(msg.value.Length - 5));
        if (msg.value.Length > 10 && msg.value.Substring(0, 11) == "AddPassword")
            commands.AddPassword(msg.value.Substring(msg.value.Length - 5));
        if (msg.value == "UnlockDoor1")
            doors.UnlockDoor1();
        if (msg.value == "OpenLockpicking")
            commands.OpenLockpicking();
        if (msg.value == "CloseLockpicking")
            commands.CloseLockpicking();
        if (msg.value == "EndCredits")
            commands.EndCredits();
        if (msg.value == "Restart")
            commands.Restart();
        if (msg.value == "LockpickingTutorial")
            commands.LockpickingTutorial();
        if (msg.value == "CloseLockpickingTutorial")
            commands.CloseLockpickingTutorial();
        if (msg.value == "ExitGame")
            commands.ExitGame();
        if (msg.value == "Pause")
            commands.Pause();
        if (msg.value == "Unpause")
            commands.Unpause();
        if (msg.value.Length > 10 && msg.value.Substring(0, 11) == "PlayerState")
            commands.PlayerState(int.Parse(msg.value.Substring(msg.value.Length - 1)));
        if (msg.value.Length > 4 && msg.value.Substring(0, 5) == "Alarm")
            commands.Alarms(int.Parse(msg.value.Substring(msg.value.Length - 1)));
        if (msg.value.Length > 11 && msg.value.Substring(0, 12) == "MonsterState")
            commands.MonsterState(int.Parse(msg.value.Substring(msg.value.Length - 1)));
        if (msg.value.Length > 4 && msg.value.Substring(0, 5) == "Timer")
            commands.Timer(int.Parse(msg.value.Substring(msg.value.Length - 3)));

    }

    public void Connect()
    {
        //192.168.8.143
        client.Connect(PlayerPrefs.GetString("IP"), 25000);
        StartCoroutine(CheckConnection());
        StartCoroutine(RequestData());
    }

    static public void SendBtnInfo(int bDelta)  //doors
    {
        if(client.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = bDelta +"";
            client.Send(888, msg);
            //Debug.Log("msg sent"+msg.value);
        }
    }

    static public void SendLockpicking(string bDelta)  //lockpiicking
    {
        if (client.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = bDelta;
            client.Send(888, msg);
            //Debug.Log("msg sent" + msg.value);
        }
    }
    public void ServerSendMessage(string message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message;
        client.Send(888, msg);
        //Debug.Log("msg sent" + msg.value);
    }

    public string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
    private IEnumerator CheckConnection()
    {
        yield return new WaitForSeconds(1);
        if (!client.isConnected)
            SceneManager.LoadScene(0);
        StartCoroutine(CheckConnection());
    }
    private IEnumerator RequestData()
    {
        yield return new WaitForSeconds(.1f);
        if (client.isConnected)
            ServerSendMessage("RequestData");
        else
            StartCoroutine(RequestData());
    }


}
