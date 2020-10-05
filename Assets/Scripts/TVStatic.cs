using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVStatic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameData.respawn)
            StartCoroutine(Hide(2));
        else
            gameObject.SetActive(false);
    }

    IEnumerator Hide(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }

}
