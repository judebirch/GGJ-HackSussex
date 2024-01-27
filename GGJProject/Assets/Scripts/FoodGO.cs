using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGO : MonoBehaviour
{
    [SerializeField]
    FoodItem food;

    public FoodItem GetFood => food;
}
