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
    bool hacking = false;
    void Start()
    {
        //ddisable after testing
        //StartHack();
    }

    private void Update()
    {
        if(hacking)
        {
            gameObjects = GameObject.FindGameObjectsWithTag("Button");
            if (gameObjects.Length == 0)
                FinishHack();
        }
        if (Input.GetKeyDown(KeyCode.E))
            DestroyBlocks(15);
    }

    public void ClickButton() //useless for now
    {
        Destroy(GetComponentInChildren<Button>().gameObject) ;
    }

    public void StartHack()
    {
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
            for (int i = 0; i < 15; i++)
            {
                GameObject btn = Instantiate(prefabBtn, new Vector3(transform.position.x + i * 1.442F, transform.position.y - j * 1.42F, 0), Quaternion.identity);
                btn.transform.SetParent(transform);
                btn.transform.localScale = new Vector3(0.014f, 0.0187f, 0.01737791f);
            }
        }
        hacking = true;

    }
    void FinishHack()
    {
        StartCoroutine("Tooltip2");
        var parent = GetComponentInParent<Hacking>();
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
        tooltip.text = "Destroy all blocks!";
        tooltip.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartHack2();
        tooltip.gameObject.SetActive(false);
    }
    private IEnumerator Tooltip2()
    {
        tooltip.text = "Password saved!";
        tooltip.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        tooltip.gameObject.SetActive(false);
    }
}
