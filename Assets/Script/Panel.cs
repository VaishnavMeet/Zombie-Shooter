using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickNext()
    {
        PlayerPrefs.SetInt("level", (PlayerPrefs.GetInt("level") + 1));
        SceneManager.LoadScene((PlayerPrefs.GetInt("level")).ToString());
    }

    public void onClickMenu()
    {
        SceneManager.LoadScene("Level");
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene((PlayerPrefs.GetInt("level")).ToString());
    }
}
