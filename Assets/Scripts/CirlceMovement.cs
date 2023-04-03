using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirlceMovement : MonoBehaviour
{
    public float angle = 1;
    public float angularSpeed = 1;
    public float radius = 1;
    public Vector3 center;
    public bool isActive;
    void Update()
    {
        if (isActive)
        {
            angle += Time.deltaTime * angularSpeed; // update angle
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up; // calculate direction from center - rotate the up vector Angle degrees clockwise
            transform.position = center + direction * radius; // update position based on center, the direction, and the radius (which is a constant)
        }
    }
}
