using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private GameController gm;
    private void Start()
    {
        gm = FindObjectOfType<GameController>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            gm.UseSpawner();

    }
}
