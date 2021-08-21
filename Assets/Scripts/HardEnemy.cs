using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent HardEnemyNav;
    private SphereCollider HardEnemycol;
    public GameObject Player;
    private Animator anim;
    public float DeleteH;
    private GameController gm;
    private Rigidbody HardEnemyRb;


    private void Awake()
    {
        HardEnemyNav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        HardEnemycol = GetComponent<SphereCollider>();
        Player = GameObject.FindGameObjectWithTag("Player");
        HardEnemyRb = GetComponent<Rigidbody>();
        //HardEnemyNav.destination = Player.transform.position;
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (gm.GameStarted)
        {
            anim.SetTrigger("run");
            HardEnemyNav.destination = Player.transform.position;
            if (transform.position.y <= DeleteH)
                Destroy(this.gameObject);
        }
        
        if(gm.GameEnded)
        {
            HardEnemyRb.velocity = (transform.forward);
        }
    }
}
