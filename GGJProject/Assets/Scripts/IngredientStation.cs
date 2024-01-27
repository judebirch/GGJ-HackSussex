using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientStation : Station
{
    public FoodItem Ingredient;

    public TMPro.TMP_Text Text;

    private void Awake()
    {
        Text.SetText(Ingredient.name);
    }

    public override void OnInteract()
    {
        if (GameManager.Instance.HeldFoodItem == null)
        {
            GameManager.Instance.AddFood(Ingredient);
        }
    }
}
