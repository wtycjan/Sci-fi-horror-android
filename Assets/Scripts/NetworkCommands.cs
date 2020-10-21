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
    public GameObject pauseScreen;
    private Doppler doppler1;
    private Doppler doppler2;
    public GameObject alarm;
    public GameObject timer;
    private MotionSensors sensors;
    private void Start()
    {
        doppler1 = player.GetComponent<Doppler>();
        doppler2 = monster.GetComponent<Doppler>();
        sensors = GetComponent<MotionSensors>();
    }

    public void OpenHelp()
    {
        hackingScreen1.gameObject.SetActive(true);
        sensors.DisableAll();
    }
    public void CloseHelp()
    {
        hackingScreen1.gameObject.SetActive(false);
        HackingEnd();
    }

    public void OpenPasswords()
    {
        passwords.gameObject.SetActive(true);
        sensors.DisableAll();
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
        sensors.DisableAll();
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
        sensors.DisableAll();
    }
    public void CloseLockpicking()
    {
        lockpicking.gameObject.SetActive(false);
    }
    public void MonsterPosition(float x, float y)
    {
        //magic numbers foor location adjustment
        monster.rectTransform.localPosition = new Vector2(-9.2f * y - 143.2F, 6.7f * x + 2);
    }
    public void PlayerPosition(float x, float y)
    {
        //magic numbers foor location adjustment
        player.rectTransform.localPosition = new Vector2(-9.2f * y - 143.2F, 6.7f * x + 2);
    }
    public void EndCredits()
    {
        endcredits.gameObject.SetActive(true);
        sensors.DisableAll();
    }
    public void Restart()
    {
        print("restart");
        GameData.respawn = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void LockpickingTutorial()
    {
        lockpickingTutorial.gameObject.SetActive(true);
        sensors.DisableAll();
    }
    public void CloseLockpickingTutorial()
    {
        lockpickingTutorial.gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        pauseScreen.SetActive(true);
    }
    public void Unpause()
    {
        pauseScreen.SetActive(false);
    }
    public void PlayerState(int x)
    {
        doppler1.SendMessage("PlayerState", x);
    }
    public void MonsterState(int x)
    {
        doppler2.SendMessage("PlayerState", x);
        print(x);
    }
    public void Alarms(int x)
    {
        alarm.SendMessage("Alarms", x);
    }
    public void Timer(int x)
    {
        timer.SendMessage("SetTimer", x);
    }
}
