using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
     void Start()
    {
        Cursor.visible = true;
    }
    public void StartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}