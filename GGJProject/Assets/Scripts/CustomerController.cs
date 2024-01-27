using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    [Serializable]
    enum CustomerStateEnum
    {
        Walking,
        Waiting,
        Annoyed,
        Served,
        Angry
    }
    [SerializeField]
    private CustomerStateEnum CustomerState = CustomerStateEnum.Walking;
    [Header("Food")]
    [SerializeField]
    private FoodItem requestFood;

    [Header("Patients")]
    [SerializeField]
    [Range(0,1f)]
    private float currentPatientValue = 1f;

    [SerializeField]
    private float patientDecay = 0.01f;
    
    
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
        //DEBUG
        CustomerState = CustomerStateEnum.Waiting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (CustomerState)
        {
            case CustomerStateEnum.Walking:
                break;
            case CustomerStateEnum.Waiting:
                if (currentPatientValue > 0f)
                {
                    currentPatientValue -= patientDecay * Time.deltaTime;
                }

                if (currentPatientValue < .3f)
                {
                    ChangeState(CustomerStateEnum.Annoyed);
                }
                break;
            case CustomerStateEnum.Annoyed:
                if (currentPatientValue > 0f)
                {
                    currentPatientValue -= patientDecay * Time.deltaTime;
                }

                else
                {
                    ChangeState(CustomerStateEnum.Angry);
                }
                break;
            case CustomerStateEnum.Served:
                break;
            case CustomerStateEnum.Angry:
                break;
        }
    }

    void ChangeState(CustomerStateEnum newState)
    {
        CustomerState = newState;
        switch (newState)
        {
            case CustomerStateEnum.Walking:
                break;
            case CustomerStateEnum.Waiting:
                break;
            case CustomerStateEnum.Annoyed:
                Debug.Log("Customer is annoyed!!!");
                break;
            case CustomerStateEnum.Served:
                break;
            case CustomerStateEnum.Angry:
                Debug.Log("Customer is ANGRYU!!!");

                break;
        }
    }
}
