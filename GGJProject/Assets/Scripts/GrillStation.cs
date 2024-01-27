using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillStation : Station
{
    private float _timer;

    public override void OnFoodAdded(FoodItem food)
    {
        base.OnFoodAdded(food);

        _timer = 0;

    }



}
