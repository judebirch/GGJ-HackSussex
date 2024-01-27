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

    public UnityEngine.UI.Image ProgressImage;

    private void Update()
    {
        if(IsFire)
        {
            CookTime += Time.deltaTime;

            ProgressImage.fillAmount = CookTime / Item.CookTime;

            if (CookTime >= Item.CookTime)
            {
                rigidbody.AddForce(Vector3.up*100f, ForceMode.Acceleration);
                Setup(Item.Cooked);
            }
        }
    }

    private void LateUpdate()
    {
        // Position progress
        Camera camera = Camera.main;
        ProgressImage.transform.position = transform.position + Vector3.up * 1;
        ProgressImage.transform.LookAt(ProgressImage.transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Heat"))
        {
            ProgressImage.gameObject.SetActive(true);

            IsFire = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Heat"))
        {
            ProgressImage.gameObject.SetActive(false);

            IsFire = false;
        }
    }
}
