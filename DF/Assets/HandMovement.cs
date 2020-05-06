using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Left;
    public GameObject Right;
    public float Speed = 10;
    public  float YRotationSpeed;
    public float ZRotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            YRotationSpeed += Time.deltaTime;
            //Rotation = Mathf.Clamp(Rotation, -90f, 90f);
            Left.transform.RotateAround(transform.position,transform.up, YRotationSpeed);
            Right.transform.RotateAround(transform.position, transform.up, -YRotationSpeed);
        }
        //else
        //{
        //    if (YRotationSpeed > 0)
        //    {
        //        YRotationSpeed = 0;
        //    }
        //}
        else if (Input.GetKey(KeyCode.E))
        {
            YRotationSpeed += Time.deltaTime;
            //Rotation = Mathf.Clamp(Rotation, -90f, 90f);
            Left.transform.RotateAround(transform.position, transform.up, -YRotationSpeed);
            Right.transform.RotateAround(transform.position, transform.up, YRotationSpeed);
        }
        else
        {
            YRotationSpeed = 0;
        }

    }
}
