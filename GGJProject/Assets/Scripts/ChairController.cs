using RotoVR.SDK.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChairController : MonoBehaviour
{
    [SerializeField] RotoBehaviour m_RotoBerhaviour;
    [SerializeField] Transform ChairTransform;

    public float Direction;

    private void Update()
    {
        Direction += Input.GetAxis("Horizontal") * Time.deltaTime * 90;

        ChairTransform.rotation = Quaternion.Euler(new Vector3(0, Direction, 0));

        m_RotoBerhaviour.RotateToAngleByCloserDirection((int)Direction, 100);
    }
}
