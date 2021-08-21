using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : MonoBehaviour
{
    public float EasyEnemySpeed;
    private Rigidbody EasyEnemyrb;
    public float DeleteH;
    private Animator anim;
    private GameController gm;

    private void Awake()
    {
        EasyEnemyrb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameController>();
    }
    void Update()
    {
        if (gm.GameStarted)
        {
            anim.SetTrigger("run");
            EasyEnemyrb.velocity = (transform.forward * EasyEnemySpeed);
            if (transform.position.y <= DeleteH)
                Destroy(this.gameObject);
        }
    }
}
