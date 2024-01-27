using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    [SerializeField]
    private FoodItem requestFood;
    // Start is called before the first frame update

    private void Awake()
    {
        // var[] loadedFood
        // requestFood = ;
    }

    public void SetFood(FoodItem foodItem)
    {
        requestFood = foodItem;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
