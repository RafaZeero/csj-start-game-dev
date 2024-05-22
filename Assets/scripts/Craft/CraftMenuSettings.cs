using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Menu", menuName = "New Menu/Menu")]
public class CraftMenuSettings : ScriptableObject
{
    [Header("Menu")]
    public List<string> choices = new List<string>();
    // [SerializeField] private string choice1;
    // [SerializeField] private string choice2;
    [Header("Tools")]
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color notSelectedColor;

    private bool _isShowing;
    public bool IsShowing { get => _isShowing; set => _isShowing = value; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
