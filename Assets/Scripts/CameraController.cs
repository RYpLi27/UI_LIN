using System.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class CameraController : MonoBehaviour
{
    private void Update()
    {
        Vector3 inputMoveDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDirection.z += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDirection.z -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDirection.x += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDirection.x -= 1f;
        }
    float controllerMoveSpeed = 5f;
        Vector3 moveVector = transform.forward * inputMoveDirection.z + transform.right * inputMoveDirection.x;
    transform.position += moveVector * controllerMoveSpeed * Time.deltaTime;

    }
    //private void Start()
    //{
    //    controllerMoveSpeed = 2f * Time.deltaTime;
    //}

    //private void Update()
    //{
    //    Vector3 inputMoveDirection = new Vector3(0, 0, 0);
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        inputMoveDirection.z = +controllerMoveSpeed;
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        inputMoveDirection.z = +controllerMoveSpeed;
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        inputMoveDirection.x = controllerMoveSpeed;
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        inputMoveDirection.x = -controllerMoveSpeed; 
    //    }  
    //}
}
