using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform GoofyGoober;

    private void Update()
    {
        transform.position = new Vector3 (GoofyGoober.position.x, GoofyGoober.position.y, transform.position.z );
    }
}
