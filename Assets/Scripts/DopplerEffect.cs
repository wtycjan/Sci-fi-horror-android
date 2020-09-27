using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopplerEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        Destroy(gameObject, 1.5f);
    }
    void State(int x)
    {
        anim.SetInteger("State", x);
    }
}
