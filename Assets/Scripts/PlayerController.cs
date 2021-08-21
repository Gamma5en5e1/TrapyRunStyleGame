using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector3 LookAtOffset;
    private Vector3 copyX;
    private Vector3 LookAtPosition;
    private Rigidbody rb;
    private Animator anim;
    private GameController gm;

    private void Awake()
    {
        LookAtPosition = LookAtOffset + transform.position;
        rb = GetComponent<Rigidbody>();
        transform.LookAt(transform.forward);
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (gm.GameStarted && !gm.GameEnded)
        {
            anim.SetTrigger("run");
            rb.AddForce(transform.forward * speed * Time.deltaTime);
            LookAtPosition = LookAtOffset + transform.position;
            if (Input.touchCount > 0)
            {
                Touch first = Input.GetTouch(0);
                if (first.phase == TouchPhase.Moved)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(first.position);
                    if (Physics.Raycast(ray, out hit))
                        copyX.x = hit.point.x;
                }
            }
            LookAtPosition.x = copyX.x;
            transform.LookAt(LookAtPosition);
            if (transform.position.y <= -2)
                gm.Lose = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !gm.GameEnded)
        {
            gm.Lose = true;
        }
    }
}
