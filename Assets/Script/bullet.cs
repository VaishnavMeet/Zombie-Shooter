using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
   
    int touchBorder = 7;
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Border")
        {
            touchBorder -= 1;

            if (touchBorder == 0)
            {
                Destroy(gameObject);
                touchBorder = 7;
            }

        }

        

    }


}
