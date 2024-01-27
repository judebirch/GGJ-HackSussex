using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField]
    private CharacterController m_CharacterController;

    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private float pulseFrequency = 1f;

    private float pulseTime = -10f;
    
    [Header("Stats")]
    [SerializeField]
    private float moveSpeed = 2;
    
    [SerializeField]
    Vector3 moveDirection;
    // [SerializeField]
    

    private void Awake()
    {
        if (!m_CharacterController)
        {
            m_CharacterController = GetComponent<CharacterController>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Update_Move();
    }

    private void FixedUpdate()
    {

        if (Time.time - pulseTime > pulseFrequency)
        {
            pulseTime = Time.time;
            Pulse();
        }
    }

    void Pulse()
    {
        Pulse_Move();
    }

    void Pulse_Move()
    {
        moveDirection = targetTransform.position - m_CharacterController.transform.position;
        moveDirection = moveDirection.normalized;
    }

    void Update_Move()
    {
        m_CharacterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
    
}
