using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public GameObject chest, terminal, computer, prefabDoppler;
    private bool alarm = false;
    void Start()
    {
        
    }
    public void Alarms(int x)
    {
        alarm = true;
        if (x == 0)
            StopAlarm();
        else
            StartCoroutine(Spawn(x));
    }
    void StopAlarm()
    {
        alarm = false;
        StopAllCoroutines();
    }

    IEnumerator Spawn(int x)
    {
        
        if(x==1)
        {
            GameObject btn = Instantiate(prefabDoppler, chest.transform.position, Quaternion.identity);
            btn.transform.SetParent(chest.transform);
            btn.SendMessage("State", 3);
        }
        else if (x==2)
        {
            GameObject btn = Instantiate(prefabDoppler, terminal.transform.position, Quaternion.identity);
            btn.transform.SetParent(terminal.transform);
            btn.SendMessage("State", 3);
        }
        else if(x==3)
        {
            //computer
            GameObject btn = Instantiate(prefabDoppler, computer.transform.position, Quaternion.identity);
            btn.transform.SetParent(computer.transform);
            btn.SendMessage("State", 3);
        }
        yield return new WaitForSeconds(0.4f);
        if(alarm)
            StartCoroutine(Spawn(x));
    }
}
