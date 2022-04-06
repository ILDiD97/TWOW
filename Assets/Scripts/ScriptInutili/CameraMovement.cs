using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform player;
    private void Update()
    {
        transform.position = player.position;
        float rot = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rot, 0));
        player.rotation = transform.rotation;
    }
    private void OnValidate()
    {
        transform.position = player.position;
    }
}
