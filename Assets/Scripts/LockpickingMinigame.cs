using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockpickingMinigame : MonoBehaviour
{
    private Sounds sounds;
    private void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sounds>();
    }
    public void RedButton()
    {
        NetworkClientUI.SendLockpicking("Red");
        sounds.HackingButtonSounds();
    }

    public void YellowButtton()
    {
        NetworkClientUI.SendLockpicking("Yellow");
        sounds.HackingButtonSounds();
    }
    public void BlueButton()
    {
        NetworkClientUI.SendLockpicking("Blue");
        sounds.HackingButtonSounds();
    }
}
