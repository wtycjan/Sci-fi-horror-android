using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorDetect : MonoBehaviour
{
    public Image player, monster;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Image>().enabled = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Image>().enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Image>().enabled = false;
    }
    private void OnDisable()
    {
        player.enabled = false;
        monster.enabled = false;
    }

}
