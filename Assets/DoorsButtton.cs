using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorsButtton : MonoBehaviour
{
    public Sounds sounds;
    public Button door1;

    public void Door1()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(1);
        StartCoroutine(HoldDoors());
    }
    public void Door2()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(2);
        StartCoroutine(HoldDoors());
    }
    public void Door3()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(3);
        StartCoroutine(HoldDoors());
    }
    public void Door4()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(4);
        StartCoroutine(HoldDoors());
    }
    public void Door5()
    {
        sounds.Sound1();
        NetworkClientUI.SendBtnInfo(5);
        StartCoroutine(HoldDoors());
    }

    private IEnumerator HoldDoors()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button b in buttons)
        {
            if (b == null)
            {
                continue;
            }
            b.interactable = false;
        }
        yield return new WaitForSeconds(2);
        foreach (Button b in buttons)
        {
            if (b == null)
            {
                continue;
            }
            if(b!=door1  || GameData.door1)
            b.interactable = true;
        }

    }
    public void UnlockDoor1()
    {
        door1.interactable = true;
        GameData.door1 = true;
    }

    }
