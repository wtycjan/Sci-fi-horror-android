using System.Collections;
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
    public GameObject cam;
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
        //Vector2 viewPos = new Vector2(cam.pixelWidth, cam)

        for (float j = 0; j < 7; j++)
        {
            for (float i = 0; i < 14; i++)
            {
                GameObject btn = Instantiate(prefabBtn, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                btn.transform.SetParent(transform);
                btn.transform.localScale = new Vector2(0.014f, 0.018f);
                btn.transform.localPosition = new Vector2(btn.transform.localPosition.x + 0.7f * i, btn.transform.localPosition.y - 0.9f* j);
            }
        }
        hacking = true;

    }
    void FinishHack()
    {
        network.ServerSendMessage("StopHackTimer");
        var parent = GameObject.FindGameObjectWithTag("Canvas").GetComponent<NetworkCommands>();
        parent.AddPassword(GameData.password);
        StartCoroutine("Tooltip2");
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
