using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    float speed = 0.1f;
    Animator animator;
    void Start()
    {
        animator=gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = new Vector2(transform.position.x + speed, transform.position.y);
            animator.SetFloat("speed",speed);
        }
        else
        { 
            animator.SetFloat("speed",0);
        }

    }
}
