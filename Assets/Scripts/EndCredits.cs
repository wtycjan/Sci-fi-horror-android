using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndCredits : MonoBehaviour
{
    public GameObject text1, text2, text3, text4, text5;
    void Start()
    {
        StartCoroutine("Ending");
    }

    public IEnumerator Ending()
    {
        yield return new WaitForSeconds(.5f);
        text1.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        text1.SetActive(false);
        yield return new WaitForSeconds(.5f);
        text2.SetActive(true);
        yield return new WaitForSeconds(5f);
        text2.SetActive(false);
        yield return new WaitForSeconds(.5f);
        text3.SetActive(true);
        yield return new WaitForSeconds(3f);
        text3.SetActive(false);
        yield return new WaitForSeconds(.5f);
        text4.SetActive(true);
        yield return new WaitForSeconds(3f);
        text4.SetActive(false);
        yield return new WaitForSeconds(1.2f);
        text5.SetActive(true);
        yield return new WaitForSeconds(5f);
        text5.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
