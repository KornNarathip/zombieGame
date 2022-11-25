using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoremanager : MonoBehaviour
{
    public static int score;
    
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Kill Count :" + score + "/10";

        if (score == 10)
        {
            SceneManager.LoadScene(3);
        }
    }


}
