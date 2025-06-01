
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{

    public Image[] allStare;
    public Sprite gold;

    private void Start()
    {
        int k = 1;

        for (int i = 0; i < 6; i++)
        {
                //if (PlayerPrefs.HasKey("star"+i))
                //{
                //    for (int j = 0; j < 3; j++)
                //    {
                //        allStare[j].sprite = gold;
                        
                //        if (3 - PlayerPrefs.GetInt("star" + i) > 0)
                //        {
                            
                //        }
                //     }

                
                //}

            if (PlayerPrefs.GetInt("star" + i) == 3)
            {
                
                allStare[k].sprite = gold;
                k++;
                allStare[k].sprite = gold;
                k++;
                allStare[k].sprite = gold;
                k++;
            }

            else if (PlayerPrefs.GetInt("star" + i) == 2)
            {
                allStare[k].sprite = gold;
                k++;
                allStare[k].sprite = gold;
                k++;
                k++;
                
            }
            else if (PlayerPrefs.GetInt("star" + i) == 1)
            {
                allStare[k].sprite = gold;
                k++;
                k++;
                k++;
                
            }
        }
        
    }

    public void onClickLevel(int n)
    {
        PlayerPrefs.SetInt("level", n);
        SceneManager.LoadScene(n.ToString());
    }

   
}
