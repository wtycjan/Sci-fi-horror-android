using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking.NetworkSystem;

public class UI : MonoBehaviour
{
    static NetworkClient client;
    public TMP_InputField input;
    public TMP_Text text;
    public TMP_Text selectedLevel;
    public Image screenInfo;
    public NetworkCommands commands;
    private bool display = false;
    private bool levelIsSelected = false;

    private void Start()
    {
        GameData.respawn = false;
        GameData.door1 = false;
        GameData.paused = false;
        ConnectionConfig config = new ConnectionConfig();
        config.AddChannel(QosType.ReliableSequenced);
        config.AddChannel(QosType.UnreliableSequenced);
        config.SendDelay = 0;
        client = new NetworkClient();
        client.Configure(config, 10);
        client.RegisterHandler(888, ServerRecieveMessage);
        //GameData.IP = "192.168.8.143";
        input.text = PlayerPrefs.GetString("IP");
        client.Connect(PlayerPrefs.GetString("IP"), 25000);
    }
    private void Update()
    {
        if (client.isConnected)
            StartCoroutine("Connection");
    }
    public void EnterIP()
    {
        PlayerPrefs.SetString("IP", input.text);
    }
    public void Connect()
    {
        //192.168.8.143
        client.Connect(PlayerPrefs.GetString("IP"), 25000);
        if(!display)
            StartCoroutine("Tip");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    private IEnumerator Tip()
    {
        display = true;
        yield return new WaitForSeconds(.1f);
        if (!client.isConnected)
        {
            text.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(2.5f);
        text.gameObject.SetActive(false);
        display = false;
    }
    private IEnumerator Connection()
    {

        screenInfo.gameObject.SetActive(true);
        yield return new WaitForSeconds(.1f);
        ServerSendMessage("RequestData");
        yield return new WaitForSeconds(2.9f);
        SceneManager.LoadScene(GameData.selectedLevel);
   

    }

    public void ServerSendMessage(string message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message;
        client.Send(888, msg);
        //Debug.Log("msg sent" + msg.value);
    }
    void ServerRecieveMessage(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message.ReadMessage<StringMessage>().value;
        if (msg.value.Length > 7 && msg.value.Substring(0, 9) == "LoadLevel")
            GameData.selectedLevel = (int.Parse(msg.value.Substring(msg.value.Length - 1)));
    }
    }
