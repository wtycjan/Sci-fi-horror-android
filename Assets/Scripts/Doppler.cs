using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Doppler : MonoBehaviour
{
    public GameObject prefabDoppler;
    public GameObject canvas;
    private Image image;
    public int playerState = 1;
    int previousState = 1;
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(Spawn());
        //canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    IEnumerator Spawn()
    {
        if(image.IsActive())
        {
        previousState = playerState;
        GameObject btn = Instantiate(prefabDoppler, transform.position, Quaternion.identity);
        btn.transform.SetParent(canvas.transform);
        btn.SendMessage("State", playerState);
        }
        float time = .75f - ((float)playerState / (float)10);
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
