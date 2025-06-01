using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CharAnim : MonoBehaviour
{
    int[] zombie = { 1 ,4, 5, 5, 6, 7 };
    static int killed = 0;
    float speed = 0.01f;
    bool rightSide = true;
    Animator animator;
    public GameObject pannel;
    
   
    void Start()
    {
        PlayerPrefs.SetInt("win",0);
        PlayerPrefs.SetInt("score",0);
        animator=GetComponent<Animator>();
    }

     void Update()
    {
        StartCoroutine(move());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="RightBox")
        {
            
            transform.localScale=new Vector2(transform.localScale.x-2, transform.localScale.y);
            rightSide = false;
        }
        if (collision.collider.tag == "LeftBox")
        {
            transform.localScale = new Vector2(transform.localScale.x + 2, transform.localScale.y);
            rightSide=true;
        }

        if (collision.collider.tag == "Bullet")
        {
            if (gameObject.tag == "Zombie")
            {
                killed++;
                PlayerPrefs.SetInt("killed", killed);
                PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+1000);
            }
            gameObject.tag = "d";
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdel", false);
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 0.20f);
            animator.SetBool("isDead", true);
            StartCoroutine(WaitFor(gameObject));
           
        }
        
    }

    IEnumerator move()
    { 
            if (rightSide && !animator.GetBool("isDead"))
            {
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);
                animator.SetBool("isWalking", true);
                animator.SetBool("isIdel", false);
                if(transform.position.x>=6.0)
                {
                    animator.SetBool("isWalking", false);
                    yield return new WaitForSeconds(2f);
                    animator.SetBool("isIdel", true);

                }
            }
            else if(!rightSide && !animator.GetBool("isDead"))
            {
                transform.position = new Vector2(transform.position.x - speed, transform.position.y);
                animator.SetBool("isWalking", true);
                animator.SetBool("isIdel", false);
                if (transform.position.x == 0)
                {
                    animator.SetBool("isWalking", false);
                    yield return new WaitForSeconds(2f);
                    animator.SetBool("isIdel", true);
                }
            }
        
    }

    IEnumerator WaitFor(GameObject g)
    {
        yield return new WaitForSeconds(1f);
        
        Destroy(g);
        if(!GameObject.FindWithTag("Zombie"))
        {
            PlayerPrefs.SetInt("win",1);
            pannel.SetActive(true);
        }
    }

}