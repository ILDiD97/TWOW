using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Transform[] _characterCameras;
    [SerializeField] private CharacterHandler _characterHandler;

    void Update()
    {
        transform.position = _characterCameras[_characterHandler.ActiveCharacter].position;
    }
}
