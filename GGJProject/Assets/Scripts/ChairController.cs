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
        int change = Mathf.RoundToInt( Input.GetAxis("Horizontal") * Time.deltaTime * 90);

        Direction += change;

        ChairTransform.rotation = Quaternion.Euler(new Vector3(0, Direction, 0));

        if(change > 0)
        {
            m_RotoBerhaviour.RotateOnAngle(RotoVR.SDK.Enum.Direction.Left, change, 100);
        }
        else
        {
            m_RotoBerhaviour.RotateOnAngle(RotoVR.SDK.Enum.Direction.Right, change, 100);
        }
    }
}
