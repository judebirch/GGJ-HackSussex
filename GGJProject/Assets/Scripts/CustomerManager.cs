using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CustomerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject customerBase;
    [SerializeField]
    private List<CustomerController> generatedCustomers;
    [SerializeField]

    private FoodItem[] foodList;
    private FoodItem[] cookedFoodList;

    private void Awake()
    {
        foodList = Resources.LoadAll<FoodItem>("Food");
        List<FoodItem> cooked = new List<FoodItem>();
        foreach (FoodItem item in foodList)
        {
            if (item.isCookFood)
            {
                cooked.Add(item);
            }
        }

        cookedFoodList = cooked.ToArray();
    }

    public CustomerController SpawnCustomer(Vector3 position)
    {
        CustomerController newCustomer = Instantiate(customerBase, position, Quaternion.identity, transform).GetComponent<CustomerController>();
        newCustomer.SetFood(cookedFoodList[Random.Range(0,cookedFoodList.Length)]);
        generatedCustomers.Add(newCustomer);
        return newCustomer;
    }

    [ContextMenu("Test_Spawn")]
    public void Test_Spawn()
    {
        SpawnCustomer(new Vector3(Random.Range(-10,10),0,Random.Range(-10,10)));
    }
}
