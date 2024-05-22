using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private bool detectPlayer;
    [SerializeField] private float waterAmount;

    private PlayerItems player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItems>();

    }

    // Update is called once per frame
    void Update()
    {
        if (detectPlayer && Input.GetKeyDown(KeyCode.E))
        {

            player.CheckWaterLimit(waterAmount);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectPlayer = false;
        }

    }
}
