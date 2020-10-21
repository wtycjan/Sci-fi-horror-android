using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorsButtton : MonoBehaviour
{
    public Sounds sounds;
    public Button door1;
    public GameObject doorImage;
    private MotionSensors sensors;
    private void Start()
    {
        sensors = GetComponent<MotionSensors>();
    }

    public void Door1a()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(1);
        BlockDoors();
    }
    public void Door1b()
    {
        StartCoroutine(HoldDoors(1));
    }

    public void Door2a()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(2);
        BlockDoors();
    }
    public void Door2b()
    {
        StartCoroutine(HoldDoors(2));
    }
    public void Door3a()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(3);
        BlockDoors();
    }
    public void Door3b()
    {
        StartCoroutine(HoldDoors(3));
    }
    public void Door4a()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(4);
        BlockDoors();
    }
    public void Door4b()
    {
        sounds.Sound1();
        StartCoroutine(HoldDoors(4));
    }
    public void Door5a()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(5);
        BlockDoors();
    }
    public void Door5b()
    {
        StartCoroutine(HoldDoors(5));
    }
    public void Door6a()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(6);
        BlockDoors();
    }
    public void Door6b()
    {
        StartCoroutine(HoldDoors(6));
    }
    private IEnumerator HoldDoors(int x)
    {

        yield return new WaitForSeconds(.1f);
        NetworkClientUI.SendBtnInfo(x);
        yield return new WaitForSeconds(2);
        BlockDoors();
    }
    public void UnlockDoor1()
    {
        doorImage.SetActive(false);
        door1.gameObject.SetActive(true);
        GameData.door1 = true;
    }

    void BlockDoors()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button b in buttons)
        {
            if (b == null)
            {
                continue;
            }
            if (b != door1 || GameData.door1)
                b.interactable = !b.interactable;
        }
        sensors.DisableAll();
    }
    }
