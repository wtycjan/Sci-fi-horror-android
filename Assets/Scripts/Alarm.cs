using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public GameObject o1, o2, o3, prefabDoppler;
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
            GameObject btn = Instantiate(prefabDoppler, o1.transform.position, Quaternion.identity);
            btn.transform.SetParent(o1.transform);
            btn.SendMessage("State", 3);
        }
        else if (x==2)
        {
            GameObject btn = Instantiate(prefabDoppler, o2.transform.position, Quaternion.identity);
            btn.transform.SetParent(o2.transform);
            btn.SendMessage("State", 3);
        }
        else if(x==3)
        {
            GameObject btn = Instantiate(prefabDoppler, o3.transform.position, Quaternion.identity);
            btn.transform.SetParent(o3.transform);
            btn.SendMessage("State", 3);
        }
        yield return new WaitForSeconds(0.4f);
        if(alarm)
            StartCoroutine(Spawn(x));
    }
}
