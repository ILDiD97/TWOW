using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CharacterController controller;
    void Update()
    {
        float hur = Input.GetAxis("Horizontal");
        float ger = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(hur, 0, ger);
        move = transform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * speed);
    }
}
