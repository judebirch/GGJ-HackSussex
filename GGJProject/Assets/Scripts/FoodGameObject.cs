using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGameObject : MonoBehaviour
{
    private void Awake()
    {
        IsFire = false;

        rigidbody = GetComponent<Rigidbody>();

        if (!Item) return;

        Setup(Item);
    }

    public void Setup(FoodItem food)
    {
        if(FoodModel != null)
        {
            Destroy(FoodModel);
        }

        Item = food;
        CookTime = 0;
        FoodModel = Instantiate(food.Model, transform);
        FoodModel.transform.localPosition = Vector3.zero;
    }

    public FoodItem Item;

    public GameObject FoodModel;

    public bool IsFire;

    public float CookTime;

    public Rigidbody rigidbody;

    private void Update()
    {
        if(IsFire)
        {
            CookTime += Time.deltaTime;
            if(CookTime >= Item.CookTime)
            {
                rigidbody.AddForce(Vector3.up*100f, ForceMode.Acceleration);
                Setup(Item.Cooked);
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Heat"))
        {
            IsFire = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Heat"))
        {
            IsFire = false;
        }
    }
}
