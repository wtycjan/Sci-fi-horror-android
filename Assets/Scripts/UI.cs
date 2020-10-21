using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    static NetworkClient client;
    public TMP_InputField input;
    public TMP_Text text;
    public Image screenInfo;
    private bool display = false;
    private void Start()
    {
        GameData.respawn = false;
        client = new NetworkClient();
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
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
