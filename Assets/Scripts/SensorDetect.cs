using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorDetect : MonoBehaviour
{
    private Image player, monster;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Rigidbody2D>().mass==1)   //1.1 is on the wrong floor
            collision.GetComponent<Image>().enabled = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>().mass == 1)
            collision.GetComponent<Image>().enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Image>().enabled = false;
    }
    private void OnDisable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Image>();
        monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Image>();
        player.enabled = false;
        monster.enabled = false;
    }

}
