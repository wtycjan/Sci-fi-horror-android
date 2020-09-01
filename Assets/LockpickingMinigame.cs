using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockpickingMinigame : MonoBehaviour
{

    public void RedButton()
    {
        NetworkClientUI.SendLockpicking("Red");
    }

    public void YellowButtton()
    {
        NetworkClientUI.SendLockpicking("Yellow");
    }
    public void BlueButton()
    {
        NetworkClientUI.SendLockpicking("Blue");
    }
}
