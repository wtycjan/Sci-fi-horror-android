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
    //public Image monster;
    //public Image player;
    public Rigidbody2D monster;
    public Rigidbody2D player;
    public Image endcredits;
    public GameObject pauseScreen;
    private Doppler doppler1;
    private Doppler doppler2;
    public GameObject alarm;
    public GameObject timer;
    private MotionSensors sensors;

    private Vector2 startPlayerAppPosition;
    private Vector2 startMonsterAppPosition;
    private Vector2 startPlayerServerPosition;
    private Vector2 startMonsterServerPosition;
    private float axTransfrom;
    private float ayTransfrom;
    private float bxTransfrom;
    private float byTransfrom;


    private void Start()
    {
        doppler1 = player.GetComponent<Doppler>();
        doppler2 = monster.GetComponent<Doppler>();
        sensors = GetComponent<MotionSensors>();

        startPlayerServerPosition= new Vector2(-8.9f ,- 23.16f );
        startMonsterServerPosition = new Vector2(-26.8f ,- 6.8f);
        startPlayerAppPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        startMonsterAppPosition = new Vector2(monster.transform.position.x, monster.transform.position.y);
        axTransfrom = (startMonsterServerPosition.x - startPlayerServerPosition.x) / (startMonsterAppPosition.x - startPlayerAppPosition.x);
        ayTransfrom = (startMonsterServerPosition.y - startPlayerServerPosition.y) / (startMonsterAppPosition.y - startPlayerAppPosition.y);
        bxTransfrom = startPlayerServerPosition.x - (axTransfrom * startPlayerAppPosition.x);
        byTransfrom = startPlayerServerPosition.y - (ayTransfrom * startPlayerAppPosition.y);
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
    public void StartPosition(float px, float py, float mx, float my)
    {
        startPlayerServerPosition = new Vector2(py, px);
        startMonsterServerPosition = new Vector2(my, mx);
        startPlayerAppPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        startMonsterAppPosition = new Vector2(monster.transform.position.x, monster.transform.position.y);
        axTransfrom = (startMonsterServerPosition.x - startPlayerServerPosition.x) / (startMonsterAppPosition.x - startPlayerAppPosition.x);
        ayTransfrom = (startMonsterServerPosition.y - startPlayerServerPosition.y) / (startMonsterAppPosition.y - startPlayerAppPosition.y);
        bxTransfrom = startPlayerServerPosition.x - (axTransfrom * startPlayerAppPosition.x);
        byTransfrom = startPlayerServerPosition.y - (ayTransfrom * startPlayerAppPosition.y);
    }
    public void MonsterPosition(float x, float y)
    {
        monster.MovePosition(new Vector2((y - bxTransfrom) / axTransfrom, (x - byTransfrom) / ayTransfrom));
    }
    public void PlayerPosition(float x, float y)
    {
        player.MovePosition(new Vector2((y - bxTransfrom) / axTransfrom, (x - byTransfrom) / ayTransfrom));
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
