using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameData.respawn)
            gameObject.SetActive(false);
        else
            StartCoroutine(Hide(9));
    }

    IEnumerator Hide(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
