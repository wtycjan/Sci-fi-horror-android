using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkClientUI : MonoBehaviour
{
    static NetworkClient client;
    public NetworkCommands commands;
    public DoorsButtton doors;

    void Start()
    {
        client = new NetworkClient();
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
            commands.MonsterPosition(float.Parse(words[1]), float.Parse(words[2]));
        }
        else if (msg.value.Length > 6 && msg.value.Substring(0, 7) == "player:")
        {
            string[] words = msg.value.Split(' ');
            commands.PlayerPosition(float.Parse(words[1]), float.Parse(words[2]));
        }
        else if (msg.value.Length > 5 && msg.value.Substring(0, 6) == "Blocks")
            commands.DestroyBlocks(int.Parse(msg.value.Substring(msg.value.Length - 2)));
        else if (msg.value == "OpenHelp")
            commands.OpenHelp();
        else if (msg.value == "CloseHelp")
            commands.CloseHelp();
        else if (msg.value == "HackingStart")
            commands.HackingStart();
        else if (msg.value == "HackingEnd")
            commands.HackingEnd();
        else if (msg.value == "OpenPasswords")
            commands.OpenPasswords();
        else if (msg.value == "ClosePasswords")
            commands.ClosePasswords();
        else if (msg.value.Length > 3 && msg.value.Substring(0, 4) == "Pswd")
            GameData.password = (msg.value.Substring(msg.value.Length - 5));
        else if (msg.value == "UnlockDoor1")
            doors.UnlockDoor1();
        else if (msg.value == "OpenLockpicking")
            commands.OpenLockpicking();
        else if (msg.value == "CloseLockpicking")
            commands.CloseLockpicking();
        else if (msg.value == "EndCredits")
            commands.EndCredits();
        else if (msg.value == "Restart")
            commands.Restart();
        else if (msg.value == "LockpickingTutorial")
            commands.LockpickingTutorial();
        else if (msg.value == "CloseLockpickingTutorial")
            commands.CloseLockpickingTutorial();

    }
    public void Connect()
    {
        //192.168.8.143
        client.Connect(PlayerPrefs.GetString("IP"), 25000);
        //StartCoroutine(WaitForConnection());
    }

    static public void SendBtnInfo(int bDelta)  //doors
    {
        if(client.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = bDelta +"";
            client.Send(888, msg);
            Debug.Log("msg sent"+msg.value);
        }
    }

    static public void SendLockpicking(string bDelta)  //lockpiicking
    {
        if (client.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = bDelta;
            client.Send(888, msg);
            Debug.Log("msg sent" + msg.value);
        }
    }
    public void ServerSendMessage(string message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message;
        client.Send(888, msg);
        Debug.Log("msg sent" + msg.value);
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
    private IEnumerator WaitForConnection()
    {
        yield return new WaitForSeconds(1);
        while (!client.isConnected)
            yield return new WaitForSeconds(.5f);
    }


}
