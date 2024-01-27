using RotoVR.SDK.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using RotoVR.SDK.Enum;
using System.IO;
using UnityEngine.UI;

public class ChairController : MonoBehaviour
{
    [SerializeField] RotoBehaviour m_RotoBerhaviour;
    [SerializeField] Transform ChairTransform;

    [SerializeField] TMP_Text debugText;

    [SerializeField] Slider slider;

    public float Angle;

    public Direction Direction = Direction.Right;

    public bool Controller = true;

    public bool debug = false;

    float timer = 0f;

    private void Start()
    {
        m_RotoBerhaviour.Connect();
    }

    private void Update()
    {
        if (Controller)
        {

            int change = Mathf.RoundToInt(Input.GetAxis("Horizontal") * Time.deltaTime * 90);

            Angle += change;

            //ChairTransform.rotation = Quaternion.Euler(new Vector3(0, Angle, 0));

            /*if (change > 0)
            {
                m_RotoBerhaviour.RotateOnAngle(RotoVR.SDK.Enum.Direction.Left, change, 100);
            }
            else
            {
                m_RotoBerhaviour.RotateOnAngle(RotoVR.SDK.Enum.Direction.Right, change, 100);
            }*/

            m_RotoBerhaviour.RotateToAngleByCloserDirection(Mathf.RoundToInt(Angle), 100);

            debugText.text = "direction: " + ChairTransform.rotation.eulerAngles.y;
            debugText.text += "\nsdk: " + m_RotoBerhaviour.readAngle;


        }


        if (debug)
        {


            timer += Time.deltaTime;

            if (timer > .025f)
            {
                timer = 0f;

               

                if(Direction == Direction.Right)
                {
                    Angle += 1f*slider.value;
                }
                else
                {
                    Angle -= 1f*slider.value;
                }



                if (Angle > 360)
                {
                    Angle = Angle % 360f;
                }
                if (Angle < 0)
                {
                    Angle += 360f;
                    Angle = Angle % 360f;
                }
                debugText.text = "direction: " + Mathf.RoundToInt(Angle);


                //   m_RotoBerhaviour.RotateToAngle(RotoVR.SDK.Enum.Direction.Right, Mathf.RoundToInt(Direction), 100);

                m_RotoBerhaviour.RotateToAngleByCloserDirection(Mathf.RoundToInt(Angle), 100);
                ChairTransform.rotation = Quaternion.Euler(new Vector3(0, Angle, 0));
                debugText.text += "\nsdk: " + m_RotoBerhaviour.readAngle;
            }



        }

    }

    public void ToggleDebug() //debug mode
    {
        debug = !debug;
        Controller = !Controller;
    }

    public void ToggleDirection() //debug mode
    {
        if (Direction == Direction.Right)
        {
            Direction = Direction.Left;
        }
        else
        {
            Direction = Direction.Right;
        }

    }

    public void SliderUpdate()
    {
        
    }
}
