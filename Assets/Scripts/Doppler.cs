using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doppler : MonoBehaviour
{
    public GameObject prefabDoppler;
    public GameObject canvas;
    public int playerState = 1;
    int previousState = 1;
    void Start()
    {
        StartCoroutine(Spawn());
        //canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    IEnumerator Spawn()
    {
        previousState = playerState;
        GameObject btn = Instantiate(prefabDoppler, transform.position, Quaternion.identity);
        btn.transform.SetParent(canvas.transform);
        btn.SendMessage("State", playerState);
        float time = .75f - ((float)playerState / (float)10);
        print(time);
        yield return new WaitForSeconds(time);
        StartCoroutine(Spawn());
    }
    void PlayerState(int x)
    {
        playerState = x;
        if (playerState != previousState)
        {
            StopAllCoroutines();
            StartCoroutine(Spawn());
        } 
    }
}
