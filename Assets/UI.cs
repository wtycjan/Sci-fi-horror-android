using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    static NetworkClient client;
    public InputField input;
    private void Start()
    {
        client = new NetworkClient();
        //GameData.IP = "192.168.8.143";
        input.text = PlayerPrefs.GetString("IP");
        Connect();
    }
    private void Update()
    {
        if (client.isConnected)
            SceneManager.LoadScene(1);
    }
    public void EnterIP()
    {
        PlayerPrefs.SetString("IP", input.text);
    }
    public void Connect()
    {
        //192.168.8.143
        client.Connect(PlayerPrefs.GetString("IP"), 25000);
    }
}
