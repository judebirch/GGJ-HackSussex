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
            CurrentFood = food;
            OnFoodAdded(CurrentFood);
        }
    }

    public FoodItem RemoveFood()
    {
        OnFoodRemoved();

        var temp = CurrentFood;
        CurrentFood = null;
        return temp;
    }

    public virtual void OnFoodAdded(FoodItem food)
    {

    }

    public virtual void OnFoodRemoved()
    {

    }

    public virtual void OnInteract()
    {

    }
}


public interface IFoodContainer
{
    public void AddFood(FoodItem food);

    public FoodItem RemoveFood();
}