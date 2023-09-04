using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Axe"))
        {
            OnHit();
        }
    }

    void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("IsHit");

        if (treeHealth <= 0)
        {
            // Destroy tree, create drops and instantiate wooden stump
            Instantiate(woodPrefab, transform.position, transform.rotation);
            anim.SetTrigger("IsChopped");
        }

    }
}
