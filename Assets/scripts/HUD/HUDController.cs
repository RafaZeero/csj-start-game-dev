using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image cropUIBar;
    [Header("Tools")]
    // [SerializeField] private Image axeIcon;
    // [SerializeField] private Image shovelIcon;
    // [SerializeField] private Image bucketIcon;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color notSelectedColor;

    private PlayerItems playerItems;
    private Player player;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }

    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        cropUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Update fill bar
        waterUIBar.fillAmount = playerItems.CurrentWater / playerItems.WaterLimit;
        woodUIBar.fillAmount = playerItems.CurrentWood / playerItems.WoodLimit;
        cropUIBar.fillAmount = playerItems.CurrentCrop / playerItems.CropLimit;


        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == player.handlingObj)
            {
                toolsUI[i].color = selectedColor;

            }
            else
            {
                toolsUI[i].color = notSelectedColor;
            }
        }
    }
}
