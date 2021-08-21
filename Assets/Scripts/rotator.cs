using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public Vector3 rotateDegree;
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.Rotate(rotateDegree);
    }
}
