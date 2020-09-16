using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NetworkCommands : MonoBehaviour
{
    public Image passwords;
    public Image hackingScreen1;
    public Image hackingScreen2;
    public Image lockpicking;
    public Image lockpickingTutorial;
    public Image monster;
    public Image player;
    public Image endcredits;


    public void OpenHelp()
    {
        hackingScreen1.gameObject.SetActive(true);
    }
    public void CloseHelp()
    {
        hackingScreen1.gameObject.SetActive(false);
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
        hackingScreen2.gameObject.SetActive(true);
        hackingScreen2.GetComponent<HackingMinigame>().StartHack();
    }
    public void HackingEnd()
    {
        hackingScreen2.gameObject.SetActive(false);
    }
    public void DestroyBlocks(int x)
    {
        hackingScreen2.GetComponent<HackingMinigame>().DestroyBlocks(x);
    }
    public void OpenLockpicking()
    {
        lockpicking.gameObject.SetActive(true);
    }
    public void CloseLockpicking()
    {
        lockpicking.gameObject.SetActive(false);
    }
    public void MonsterPosition(float x, float y)
    {
        //magic numbers foor location adjustment
        monster.rectTransform.localPosition = new Vector2(-9.2f*y -102 , 6.7f*x+2);
    }
    public void PlayerPosition(float x, float y)
    {
        //magic numbers foor location adjustment
        player.rectTransform.localPosition = new Vector2(-9.2f * y - 102, 6.7f * x+2);
    }
    public void EndCredits()
    {
        endcredits.gameObject.SetActive(true);
    }
    public void Restart()
    {
        print("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void LockpickingTutorial()
    {
        lockpickingTutorial.gameObject.SetActive(true);
    }
    public void CloseLockpickingTutorial()
    {
        lockpickingTutorial.gameObject.SetActive(false);
    }
}
