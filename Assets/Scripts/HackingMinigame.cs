﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HackingMinigame : MonoBehaviour
{
    public GameObject prefabBtn;
    public Text password;
    public Text tooltip;
    GameObject[] gameObjects;
    public NetworkClientUI network;
    bool hacking = false;

    private void Update()
    {
        if(hacking)
        {
            gameObjects = GameObject.FindGameObjectsWithTag("Button");
            if (gameObjects.Length == 0)
                FinishHack();
        }
    }

    public void ClickButton() //useless for now
    {
        Destroy(GetComponentInChildren<Button>().gameObject) ;
    }

    public void StartHack()
    {
        hacking = false;
        password.text = "";
        //destroy previously made buttons
        gameObjects = GameObject.FindGameObjectsWithTag("Button");
        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);

        StartCoroutine("Tooltip1");

    }
    public void StartHack2()
    {
        password.text = GameData.password;
        //create new buttons
        for (int j = 0; j < 7; j++)
        {
            for (int i = 0; i < 14; i++)
            {
                GameObject btn = Instantiate(prefabBtn, new Vector3(transform.position.x + i * 1.4F, transform.position.y - j * 1.4F, 0), Quaternion.identity);
                btn.transform.SetParent(transform);
                btn.transform.localScale = new Vector3(0.014f, 0.0187f, 0.01737791f);
            }
        }
        hacking = true;

    }
    void FinishHack()
    {
        StartCoroutine("Tooltip2");
        network.ServerSendMessage("StopHackTimer");
        var parent = GameObject.FindGameObjectWithTag("Canvas").GetComponent<NetworkCommands>();
        parent.AddPassword(GameData.password);
        hacking = false;
    }
    public void DestroyBlocks(int x)
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < x; i++)
        {
            Destroy(gameObjects[Random.Range(0,gameObjects.Length)]);
        }
    }
    private IEnumerator Tooltip1()
    {
        tooltip.text = "Click all blocks!";
        tooltip.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        StartHack2();
        tooltip.gameObject.SetActive(false);
    }
    private IEnumerator Tooltip2()
    {
        tooltip.text = "Password saved!";
        tooltip.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        tooltip.gameObject.SetActive(false);
        network.ServerSendMessage("StopHacking");
    }
}