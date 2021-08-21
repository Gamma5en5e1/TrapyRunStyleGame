using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidEnemy : MonoBehaviour
{
    public float MidEnemySpeed;
    private Rigidbody MidEnemyrb;
    private Animator anim;
    private bool grounded = true;
    public float distToGround;
    public float jumpSpeed;
    public float DeleteH;
    private GameController gm;
    bool used = false;
    private void Awake()
    {
        MidEnemyrb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameController>();
    }
    void Update()
    {
        if (gm.GameStarted)
        {
            if(!used)
                anim.SetTrigger("run");

            MidEnemyrb.velocity = transform.forward * MidEnemySpeed;
            if (Physics.Raycast(transform.position, Vector3.down, distToGround))
            {
                if (!grounded)
                {
                    anim.SetTrigger("jumpEnd");
                    MidEnemyrb.AddForce(-transform.up * (jumpSpeed * 0.5f));
                }
                grounded = true;
            }
            else
            {
                if (grounded)
                {
                    anim.SetTrigger("jump");
                    MidEnemyrb.AddForce((transform.up) * jumpSpeed);
                }
                grounded = false;
            }

            if (transform.position.y <= DeleteH)
                Destroy(this.gameObject);
        }
    }

}
