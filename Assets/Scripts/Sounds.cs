using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public AudioClip audio4;
    public AudioClip audio5;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Sound1()
    {
        source.PlayOneShot(audio1);
    }
    public void Sound2()
    {
        source.PlayOneShot(audio2);
    }
    public void Sound3()
    {
        source.PlayOneShot(audio3);
    }
    public void Sound4()
    {
        source.PlayOneShot(audio4);
    }
    public void Sound5()
    {
        source.PlayOneShot(audio5);
    }

    public void HackingButtonSounds()
    {
        int x = Random.Range(0,3);
        switch (x)
        {
            case 0:
                Sound2();
                break;
            case 1:
                Sound3();
                break;
            case 2:
                Sound4();
                break;
        }
    }
}
