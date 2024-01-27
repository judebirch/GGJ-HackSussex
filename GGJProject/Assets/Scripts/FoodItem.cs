using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Food", order = 1)]
public class FoodItem : ScriptableObject
{
    public GameObject Model;

    public FoodItem Cooked;

    public float CookTime;
}