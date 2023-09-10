using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour
{

    [SerializeField] private float digToHole;
    [SerializeField] private Animator anim;
    [SerializeField] private Sprite crop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (digToHole > 0 && collision.CompareTag("Shovel"))
        {
            OnDig();
        }
    }

    void OnDig()
    {
        digToHole--;

        // anim.SetTrigger("IsDigging");
        if (digToHole <= 0)
        {
            anim.SetTrigger("IsHole");
        }
    }
}
