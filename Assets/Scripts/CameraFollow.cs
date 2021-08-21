using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private GameController gm;


    private void Awake()
    {
        gm = FindObjectOfType<GameController>();
    }


    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        if(!gm.GameEnded)
            transform.position = smoothPosition;

        transform.LookAt(target);
    }
}
