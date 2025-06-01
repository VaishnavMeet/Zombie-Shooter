using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    int[] bulletCount = { 7, 5, 5, 4, 4, 4, 4 };
    public GameObject bulletPrefab,endPoint,gameoverPanel;
    float angle;
    int currentBulttet,shootBullet=0;
    public Text remainBullet;
    public Image[] star; 
    public Sprite Yellow,Silver;
    int getstar = 0;
    private void Start()
    {
       
        currentBulttet = bulletCount[PlayerPrefs.GetInt("level")];
        remainBullet.text=currentBulttet.ToString();
    }

    void Update()
    {
        Vector3 gunPos = transform.position;
        Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 offset=new Vector2(mousePos.x-gunPos.x, mousePos.y-gunPos.y);
        
        angle=Mathf.Atan2(offset.y,offset.x)*Mathf.Rad2Deg;

        transform.rotation=Quaternion.Euler(0,0,angle);
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }

    }

    void shoot()
    {
        if (currentBulttet > 0)
        {
            shootBullet++;
            Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            GameObject g = Instantiate(bulletPrefab, endPoint.transform.position, Quaternion.identity);
            g.transform.rotation = Quaternion.Euler(0, 0, angle - 92);
            g.GetComponent<Rigidbody2D>().AddForce(dir * 550);
            currentBulttet--;
            remainBullet.text = currentBulttet.ToString();

            
            if (currentBulttet >= 3  && PlayerPrefs.GetInt("win")!=1)
            {
                star[0].sprite = Yellow;
                star[1].sprite = Yellow;
                star[2].sprite = Yellow;
                getstar = 3;
            }
            else if (currentBulttet == 2 && PlayerPrefs.GetInt("win") != 1)
            {
                star[0].sprite = Yellow;
                star[1].sprite = Yellow;
                star[2].sprite = Silver;
                getstar = 2;

            }
            else if (currentBulttet == 1 && PlayerPrefs.GetInt("win") != 1)
            {
                star[0].sprite = Yellow;
                star[1].sprite = Silver;
                star[2].sprite = Silver;
                getstar = 1;
            }
            else if(currentBulttet < 1 && PlayerPrefs.GetInt("win") != 1)
            {
                star[0].sprite = Yellow;
                star[1].sprite = Silver;
                star[2].sprite = Silver;
                getstar = 0;
            }
            print(PlayerPrefs.GetInt("win"));
            PlayerPrefs.SetInt("star"+PlayerPrefs.GetInt("level"), getstar);
            print(PlayerPrefs.GetInt("star"+PlayerPrefs.GetInt("level")));
        }

        if (currentBulttet == 0 && PlayerPrefs.GetInt("win") != 1)
        { 
            gameoverPanel.SetActive(true);
        }
        
    }
}

