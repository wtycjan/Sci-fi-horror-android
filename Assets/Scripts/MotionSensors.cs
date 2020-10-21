using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensors : MonoBehaviour
{
    public GameObject motion1, motion2, motion3, motion4, motion5, motion6;
    private bool m1, m2, m3, m4, m5, m6;
    private Sounds sounds;
    private AudioSource audioSrc;
    private void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sounds>();
    }
    public void Motion1()
    {
        if (motion1.activeSelf == false &&!m1)
        {
            DisableAllExcept(1);
            StartCoroutine(EnableMotion(1));
        }     
        else if (!m1)
        {
            StartCoroutine(DisableMotion(1));
        }   
    }
    public void Motion2()
    {
        if (motion2.activeSelf == false && !m2)
        {
            DisableAllExcept(2);
            StartCoroutine(EnableMotion(2));
        }
        else if (!m2)
        {
            StartCoroutine(DisableMotion(2));
        }
    }
    public void Motion3()
    {
        if (motion3.activeSelf == false && !m3)
        {
            DisableAllExcept(3);
            StartCoroutine(EnableMotion(3));
        }
        else if (!m3)
        {
            StartCoroutine(DisableMotion(3));
        }
    }
    public void Motion4()
    {
        if (motion4.activeSelf == false && !m4)
        {
            DisableAllExcept(4);
            StartCoroutine(EnableMotion(4));
        }
        else if (!m4)
        {
            StartCoroutine(DisableMotion(4));
        }
    }

    public void Motion5()
    {
        if (motion5.activeSelf == false && !m5)
        {
            DisableAllExcept(5);
            StartCoroutine(EnableMotion(5));
        }
        else if (!m5)
        {
            StartCoroutine(DisableMotion(5));
        }
    }
    public void Motion6()
    {
        if (motion6.activeSelf == false && !m6)
        {
            DisableAllExcept(6);
            StartCoroutine(EnableMotion(6));
        }
        else if (!m6)
        {
            StartCoroutine(DisableMotion(6));
        }
    }
    public void DisableAll()
    {
        StartCoroutine(DisableMotion(1));
        StartCoroutine(DisableMotion(2));
        StartCoroutine(DisableMotion(3));
        StartCoroutine(DisableMotion(4));
        StartCoroutine(DisableMotion(5));
        StartCoroutine(DisableMotion(6));
    }
    public void DisableAllExcept(int i)
    {
        switch (i)
        {
            case 1:
                StartCoroutine(DisableMotion(2));
                StartCoroutine(DisableMotion(3));
                StartCoroutine(DisableMotion(4));
                StartCoroutine(DisableMotion(5));
                StartCoroutine(DisableMotion(6));
                break;
            case 2:
                StartCoroutine(DisableMotion(1));
                StartCoroutine(DisableMotion(3));
                StartCoroutine(DisableMotion(4));
                StartCoroutine(DisableMotion(5));
                StartCoroutine(DisableMotion(6));
                break;
            case 3:
                StartCoroutine(DisableMotion(1));
                StartCoroutine(DisableMotion(2));
                StartCoroutine(DisableMotion(4));
                StartCoroutine(DisableMotion(5));
                StartCoroutine(DisableMotion(6));
                break;
            case 4:
                StartCoroutine(DisableMotion(1));
                StartCoroutine(DisableMotion(2));
                StartCoroutine(DisableMotion(3));
                StartCoroutine(DisableMotion(5));
                StartCoroutine(DisableMotion(6));
                break;
            case 5:
                StartCoroutine(DisableMotion(1));
                StartCoroutine(DisableMotion(2));
                StartCoroutine(DisableMotion(3));
                StartCoroutine(DisableMotion(4));
                StartCoroutine(DisableMotion(6));
                break;
            case 6:
                StartCoroutine(DisableMotion(1));
                StartCoroutine(DisableMotion(2));
                StartCoroutine(DisableMotion(3));
                StartCoroutine(DisableMotion(4));
                StartCoroutine(DisableMotion(5));
                break;

        }
        }
    private IEnumerator EnableMotion(int i)
    {

        switch (i)
        {
            case 1:
                motion1.GetComponent<Animator>().SetBool("Disable", false);
                motion1.SetActive(true);
                m1 = true;
                break;
            case 2:
                motion2.GetComponent<Animator>().SetBool("Disable", false);
                motion2.SetActive(true);
                m2 = true;
                break;
            case 3:
                motion3.GetComponent<Animator>().SetBool("Disable", false);
                motion3.SetActive(true);
                m3 = true;
                break;
            case 4:
                motion4.GetComponent<Animator>().SetBool("Disable", false);
                motion4.SetActive(true);
                m4 = true;
                break;
            case 5:
                motion5.GetComponent<Animator>().SetBool("Disable", false);
                motion5.SetActive(true);
                m5 = true;
                break;
            case 6:
                motion6.GetComponent<Animator>().SetBool("Disable", false);
                motion6.SetActive(true);
                m6 = true;
                break;
        }
        sounds.Sound5();
        yield return new WaitForSeconds(2f);
        switch (i)
        {
            case 1:
                m1 = false;
                BoxCollider2D[] coliders = motion1.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = true;
                }
                break;
            case 2:
                m2 = false;
                coliders = motion2.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = true;
                }
                break;
            case 3:
                m3 = false;
                coliders = motion3.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = true;
                }
                break;
            case 4:
                m4 = false;
                coliders = motion4.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = true;
                }
                break;
            case 5:
                m5 = false;
                coliders = motion5.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = true;
                }
                break;
            case 6:
                m6 = false;
                coliders = motion6.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = true;
                }
                break;
        }

        }
    private IEnumerator DisableMotion(int i)
    {
        switch (i)
        {
            case 1:
                motion1.GetComponent<Animator>().SetBool("Disable", true);
                audioSrc = motion1.GetComponent<AudioSource>();
                StartCoroutine(AudioFadeOut.FadeOut(audioSrc, .4f));
                m1 = true;
                BoxCollider2D[] coliders = motion1.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = false;
                }
                break;
            case 2:
                motion2.GetComponent<Animator>().SetBool("Disable", true);
                audioSrc = motion2.GetComponent<AudioSource>();
                StartCoroutine(AudioFadeOut.FadeOut(audioSrc, .4f));
                m2 = true;
                coliders = motion2.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = false;
                }
                break;
            case 3:
                motion3.GetComponent<Animator>().SetBool("Disable", true);
                audioSrc = motion3.GetComponent<AudioSource>();
                StartCoroutine(AudioFadeOut.FadeOut(audioSrc, .4f));
                m3 = true;
                coliders = motion3.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = false;
                }
                break;
            case 4:
                motion4.GetComponent<Animator>().SetBool("Disable", true);
                audioSrc = motion4.GetComponent<AudioSource>();
                StartCoroutine(AudioFadeOut.FadeOut(audioSrc, .4f));
                m4 = true;
                coliders = motion4.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = false;
                }
                break;
            case 5:
                motion5.GetComponent<Animator>().SetBool("Disable", true);
                audioSrc = motion5.GetComponent<AudioSource>();
                StartCoroutine(AudioFadeOut.FadeOut(audioSrc, .4f));
                m5 = true;
                coliders = motion5.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = false;
                }
                break;
            case 6:
                motion6.GetComponent<Animator>().SetBool("Disable", true);
                audioSrc = motion6.GetComponent<AudioSource>();
                StartCoroutine(AudioFadeOut.FadeOut(audioSrc, .4f));
                m6 = true;
                coliders = motion6.GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D col in coliders)
                {
                    col.enabled = false;
                }
                break;

        }
        yield return new WaitForSeconds(.5f);
        switch (i)
        {
            case 1:
                motion1.SetActive(false);
                m1 = false;
                break;
            case 2:
                motion2.SetActive(false);
                m2 = false;
                break;
            case 3:
                motion3.SetActive(false);
                m3 = false;
                break;
            case 4:
                motion4.SetActive(false);
                m4 = false;
                break;
            case 5:
                motion5.SetActive(false);
                m5 = false;
                break;
            case 6:
                motion6.SetActive(false);
                m6 = false;
                break;
        }

    }
}
