using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorsText : MonoBehaviour
{
    private Text doorsText;
    public GameObject prefabDoppler;
    public bool open = false;
    int i = 0;
    void Start()
    {
        doorsText = GetComponent<Text>();
    }

    public void OpenClose()
    {
        if (!open)
            StartCoroutine(OpenAnim());
        else
            StartCoroutine(CloseAnim());
    }
    IEnumerator OpenAnim()
    {
        while (i < 16)
        {
            doorsText.text = doorsText.text.Insert(2, " ");
            i++;
            yield return new WaitForSeconds(0.05f);
        }
        i = 0;
        open = true;
    }
    IEnumerator CloseAnim()
    {
        while (i < 16)
        {
            doorsText.text = doorsText.text.Remove(2,1);
            i++;
            yield return new WaitForSeconds(0.05f);
        }
        i = 0;
        open = false;
    }
    public void SoundDoppler()
    {
        GameObject btn = Instantiate(prefabDoppler, transform.position, Quaternion.identity);
        btn.transform.SetParent(transform);
        btn.SendMessage("State", 3);
        Destroy(btn, 1.5f);
    }
}
