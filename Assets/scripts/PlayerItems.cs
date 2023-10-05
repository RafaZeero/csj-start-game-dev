using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Current values")]
    [SerializeField] private int _currentWood;
    [SerializeField] private float _currentWater;
    [SerializeField] private int _currentCrop;
    [Header("Limits")]
    private float _waterLimit = 50;
    private float _woodLimit = 5;
    private float _cropLimit = 5;

    public float WaterLimit { get => _waterLimit; set => _waterLimit = value; }
    public float WoodLimit { get => _woodLimit; set => _woodLimit = value; }
    public float CropLimit { get => _cropLimit; set => _cropLimit = value; }
    // --
    public int CurrentWood { get => _currentWood; set => _currentWood = value; }
    public float CurrentWater { get => _currentWater; set => _currentWater = value; }
    public int CurrentCrop { get => _currentCrop; set => _currentCrop = value; }

    public void CheckWaterLimit(float water)
    {
        if (CurrentWater < WaterLimit)
            CurrentWater += water;
    }
}
