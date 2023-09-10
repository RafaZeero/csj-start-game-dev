using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int _currentWood;
    [SerializeField] private float _currentWater;
    private float waterLimit = 50;

    public int CurrentWood { get => _currentWood; set => _currentWood = value; }
    public float CurrentWater { get => _currentWater; set => _currentWater = value; }

    public void CheckWaterLimit(float water)
    {
        if (CurrentWater < waterLimit)
            CurrentWater += water;
    }
}
