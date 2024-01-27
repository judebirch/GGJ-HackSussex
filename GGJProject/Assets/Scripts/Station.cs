using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Station : MonoBehaviour, IFoodContainer
{
    public FoodItem CurrentFood;

    public void AddFood(FoodItem food)
    {
        if(CurrentFood == null)
        {
            food = CurrentFood;
            OnFoodAdded(food);
        }
    }

    public FoodItem RemoveFood()
    {
        var temp = CurrentFood;
        CurrentFood = null;
        return temp;
    }

    public virtual void OnFoodAdded(FoodItem food)
    {

    }
}


public interface IFoodContainer
{
    public void AddFood(FoodItem food);

    public FoodItem RemoveFood();
}