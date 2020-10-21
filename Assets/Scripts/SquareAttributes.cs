using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareAttributes : MonoBehaviour
{
    private Sounds sounds;
    void Start()
    {
        GetComponent<Image>().color = Random.ColorHSV(0,1,1,1,1,1,1,1);
        string[] Alphabet = new string[26] { "!", "@", "#", "$", "%", "^", "&", "*", "=", "{}", "-", "+", "()", ";", ":", "''", "|", "/", "?", "<>", ",", "~", "1", "Esc", "x", "0" };
        GetComponentInChildren<Text>().text = Alphabet[Random.Range(0, Alphabet.Length)];
        sounds = GameObject.FindGameObjectWithTag("SoundController").GetComponent<Sounds>();
    }

    public void ClickButton()
    {
        sounds.HackingButtonSounds();
    }

}
