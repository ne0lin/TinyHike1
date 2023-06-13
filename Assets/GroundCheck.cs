using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform rayCastOrgin;
    [SerializeField] private Transform gooberfeet;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit2D Hit2D;

    private void GroundCheckMethod()
    {
        Hit2D = Physics2D.Raycast(rayCastOrgin.position, -Vector2.up, 100f, layerMask);
        if (Hit2D != false)
        {
            Vector2 temp = gooberfeet.position;
            temp.y = Hit2D.point.y;
            gooberfeet.position = temp;
        }
    }

    void Update()
    {
        GroundCheckMethod();
    }
}
