using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hacking : MonoBehaviour
{
    public Image passwords;
    public Image hackingScreen;


    public void OpenHelp()
    {
        gameObject.SetActive(true);
    }
    public void CloseHelp()
    {
        gameObject.SetActive(false);
        HackingEnd();
    }

    public void OpenPasswords()
    {
        passwords.gameObject.SetActive(true);
    }
    public void ClosePasswords()
    {
        passwords.gameObject.SetActive(false);
    }
    public void AddPassword(string pswd)
    {
        passwords.GetComponentInChildren<Text>().text += "\n" + pswd;
    }
    public void HackingStart()
    {
        hackingScreen.gameObject.SetActive(true);
        hackingScreen.GetComponent<HackingMinigame>().StartHack();
    }
    public void HackingEnd()
    {
        hackingScreen.gameObject.SetActive(false);
    }
    public void DestroyBlocks(int x)
    {
        hackingScreen.GetComponent<HackingMinigame>().DestroyBlocks(x);
    }
}
