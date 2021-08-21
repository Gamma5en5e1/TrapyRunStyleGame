using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class CubeFall : MonoBehaviour
{
    public float fallSpeed;
    bool readytofallfall;
    public float heightToDelete;
    private GameController gm;


    private void Awake()
    {
        gm = FindObjectOfType<GameController>();
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gm.CreateObstacle(transform.position);
            readytofallfall = true;
        }
    }

    private void Update()
    {
        if(readytofallfall)
            this.transform.Translate(-transform.up * fallSpeed * Time.deltaTime);

        if (transform.position.y < heightToDelete)
            Destroy(this.gameObject);
    }
}
