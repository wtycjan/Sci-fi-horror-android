using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorsButtton : MonoBehaviour
{


    public void Door1()
    {
        NetworkClientUI.SendBtnInfo(1);
    }
    public void Door2()
    {
        NetworkClientUI.SendBtnInfo(2);
    }
    public void Door3()
    {
        NetworkClientUI.SendBtnInfo(3);
    }
    public void Door4()
    {
        NetworkClientUI.SendBtnInfo(4);
    }
    public void Door5()
    {
        NetworkClientUI.SendBtnInfo(5);
    }
}
