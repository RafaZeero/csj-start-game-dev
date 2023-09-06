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
    [SerializeField] private ParticleSystem leafs;


    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (treeHealth > 0 && collison.CompareTag("Axe"))
        {
            OnHit();
        }
    }

    void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("IsHit");
        leafs.Play();

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
