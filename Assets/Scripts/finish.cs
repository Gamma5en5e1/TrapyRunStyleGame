using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    private GameObject Player;
    private Camera MainCamera;
    public Vector3 finishPoint;
    private GameController gm;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        gm = FindObjectOfType<GameController>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.GameEnded = true;
        }

    }

    private void Update()
    {
        if(gm.GameEnded)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, finishPoint, Time.deltaTime);
        }
    }
}
