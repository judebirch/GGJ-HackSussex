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

    public override void OnInteract()
    {
        if(CurrentFood == null)
        {
            if(GameManager.Instance.HeldFoodItem != null)
            {
                _timer = 0;
                AddFood(GameManager.Instance.RemoveFood());
            }
        }
        else
        {
            if (GameManager.Instance.HeldFoodItem == null)
            {
                if (CurrentFood != null)
                {
                    GameManager.Instance.AddFood(RemoveFood());

                    _timer = 0;
                }
            }
        }
    }

    private void Update()
    {
        if (CurrentFood != null)
        {
            _timer += Time.deltaTime;

            if(_timer >= CurrentFood.CookTime)
            {
                var cookedFood = CurrentFood.Cooked;
                RemoveFood();
                AddFood(cookedFood);
                _timer = 0;
            }
        }
    }
}
