using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite crop;

    [Header("Settings")]
    [SerializeField] private float digToHole;
    [SerializeField] private float amountToSprout;
    [SerializeField] private bool detectPlayer;

    private float initialDigAmount;
    private float currentWater;
    private bool canPlant;
    private PlayerItems playerItems;

    void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        initialDigAmount = digToHole;
    }

    void Update()
    {
        if (canPlant)
        {
            OnSprout();
        }
    }

    void OnSprout()
    {
        // Increase water amount to sprout
        if (detectPlayer)
        {
            currentWater += 0.01f;
        }

        // Show sprout
        if (currentWater > amountToSprout)
        {
            spriteRenderer.sprite = crop;
            if (Input.GetKeyDown(KeyCode.E))
            {
                spriteRenderer.sprite = hole;
                playerItems.CurrentCrop++;
                currentWater = 0f;
            }
        }

    }

    void OnDig()
    {
        digToHole--;

        // anim.SetTrigger("IsDigging");
        if (digToHole <= 0)
        {
            spriteRenderer.sprite = hole;
            canPlant = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (digToHole > 0 && collision.CompareTag("Shovel"))
        {
            OnDig();
        }
        if (digToHole == 0 && collision.CompareTag("Watering"))
        {
            detectPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (digToHole == 0 && collision.CompareTag("Watering"))
        {
            detectPlayer = false;
        }
    }
}
