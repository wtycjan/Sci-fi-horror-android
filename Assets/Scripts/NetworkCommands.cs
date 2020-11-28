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
    public Image elevatorConsole;

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
    [SerializeField]
    private Vector2 startPlayerServerPosition;
    [SerializeField]
    private Vector2 startMonsterServerPosition;
    [SerializeField]
    private float yLevelPosition;
    private float axTransfrom;
    private float ayTransfrom;
    private float bxTransfrom;
    private float byTransfrom;
    private float axTransfrom1;
    private float ayTransfrom1;
    private float bxTransfrom1;
    private float byTransfrom1;
    private float axTransfrom2=-999;
    private float ayTransfrom2=-999;
    private float bxTransfrom2=-9999;
    private float byTransfrom2=-999;

    private bool upperLevel = false;



    private void Start()
    {
        doppler1 = player.GetComponent<Doppler>();
        doppler2 = monster.GetComponent<Doppler>();
        sensors = GetComponent<MotionSensors>();

        startPlayerAppPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        startMonsterAppPosition = new Vector2(monster.transform.position.x, monster.transform.position.y);
        axTransfrom1 = (startMonsterServerPosition.x - startPlayerServerPosition.x) / (startMonsterAppPosition.x - startPlayerAppPosition.x);
        ayTransfrom1 = (startMonsterServerPosition.y - startPlayerServerPosition.y) / (startMonsterAppPosition.y - startPlayerAppPosition.y);
        bxTransfrom1 = startPlayerServerPosition.x - (axTransfrom1 * startPlayerAppPosition.x);
        byTransfrom1 = startPlayerServerPosition.y - (ayTransfrom1 * startPlayerAppPosition.y);

        axTransfrom = axTransfrom1;
        ayTransfrom = ayTransfrom1;
        bxTransfrom = bxTransfrom1;
        byTransfrom = byTransfrom1;
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
        Text text = passwords.GetComponentInChildren<Text>();
        if(!text.text.Contains(pswd))
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
    public void MonsterLevel(float y)
    {
        if (y < yLevelPosition && upperLevel)
        {
            monster.mass = 1.1f;
        }
        else if (y > yLevelPosition && !upperLevel)
            monster.mass = 1.1f;
        else
            monster.mass = 1;

    }
    public void PlayerLevel(float y)
    {
        if (y < yLevelPosition && upperLevel)
            player.mass = 1.1f;
        else if (y > yLevelPosition && !upperLevel)
            player.mass = 1.1f;
        else
            player.mass = 1;
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
    }
    public void Alarms(int x)
    {
        alarm.SendMessage("Alarms", x);
    }
    public void Timer(int x)
    {
        timer.SendMessage("SetTimer", x);
    }
    public void OpenElevatorConsole()
    {
        elevatorConsole.gameObject.SetActive(true);
        sensors.DisableAll();
    }
    public void CloseElevatorConsole()
    {
        elevatorConsole.gameObject.SetActive(false);
    }
    public void LoadLevel(int x)
    {
        
        print(x);
    }

    public void SwitchLevel()
    {
        upperLevel = !upperLevel;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Rigidbody2D>();
        doppler1 = player.GetComponent<Doppler>();
        doppler2 = monster.GetComponent<Doppler>();

        if (axTransfrom2 == -999)
        {
            startPlayerAppPosition = new Vector2(player.transform.position.x, player.transform.position.y);
            startMonsterAppPosition = new Vector2(monster.transform.position.x, monster.transform.position.y);
            axTransfrom2 = (startMonsterServerPosition.x - startPlayerServerPosition.x) / (startMonsterAppPosition.x - startPlayerAppPosition.x);
            ayTransfrom2 = (startMonsterServerPosition.y - startPlayerServerPosition.y) / (startMonsterAppPosition.y - startPlayerAppPosition.y);
            bxTransfrom2 = startPlayerServerPosition.x - (axTransfrom2 * startPlayerAppPosition.x);
            byTransfrom2 = startPlayerServerPosition.y - (ayTransfrom2* startPlayerAppPosition.y);
        }

        if (upperLevel == false)
        {
            axTransfrom = axTransfrom1;
            ayTransfrom = ayTransfrom1;
            bxTransfrom = bxTransfrom1;
            byTransfrom = byTransfrom1;
        }
        else
        {
            axTransfrom = axTransfrom2;
            ayTransfrom = ayTransfrom2;
            bxTransfrom = bxTransfrom2;
            byTransfrom = byTransfrom2;
        }
            
    }


}
