using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IFoodContainer
{
    public static GameManager Instance;

    public int AngleId;

    public TMP_Text angleIdText;
    public TMP_Text HeldFoodItemText;

    public FoodItem HeldFoodItem;

    public List<Station> Stations;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractButton();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ServeButton();
        }
    }

    public void InteractButton()
    {
        Stations[AngleId].OnInteract();
    }

    public void ServeButton()
    {

    }

    public void MoveLeft()
    {
        AngleId -= 1;
        if(AngleId < 0)
        {
            AngleId += 8;
        }

        angleIdText.SetText(AngleId.ToString());
    }

    public void MoveRight()
    {
        AngleId += 1;
        if (AngleId > 7)
        {
            AngleId -= 8;
        }
        angleIdText.SetText(AngleId.ToString());
    }

    // Food
    public void AddFood(FoodItem food)
    {
        HeldFoodItemText.SetText("Player Held Item: " + food.name);

        HeldFoodItem = food;
    }

    public FoodItem RemoveFood()
    {
        HeldFoodItemText.SetText("Player Held Item: Nothing");

        var temp = HeldFoodItem;
        HeldFoodItem = null;
        return temp;
    }
}
