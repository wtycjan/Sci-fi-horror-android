using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareAttributes : MonoBehaviour
{
    void Start()
    {
        GetComponent<Image>().color = Random.ColorHSV(0,1,1,1,1,1,1,1);
        string[] Alphabet = new string[26] { "!", "@", "#", "$", "%", "^", "&", "*", "=", "{}", "-", "+", "()", ";", ":", "''", "|", "/", "?", "<>", ",", "~", "1", "Esc", "x", "0" };
        GetComponentInChildren<Text>().text = Alphabet[Random.Range(0, Alphabet.Length)];
    }


}
