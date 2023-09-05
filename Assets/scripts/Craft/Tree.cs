using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;


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
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation);
            }
            anim.SetTrigger("IsChopped");
        }

    }
}
