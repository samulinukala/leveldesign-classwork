using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{
    public bool win;
    public bool lose;
    public Canvas winCanvas;
    public Canvas loseCanvas;
    public int score;
    public TMP_Text TMP_Text;
    public TMP_Text winScore;
    private void Update()
    {
        TMP_Text.text ="score: "+ score.ToString();
        if (win)
        {
            incaseOfWin();
        }
        else if ( lose)
        {
            incaseOfLose();
        }
    }
    public void Start()
    {
        Time.timeScale = 1;
        winCanvas.enabled = false;
        loseCanvas.enabled = false;
    }
   
    public void incaseOfWin()
    {

        FindObjectOfType<FirstPersonController>().lockCursor = false;
        FindObjectOfType<FirstPersonController>().cameraCanMove = false;
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        winCanvas.enabled = true;
        winScore.text = "score: " + score.ToString();
        Time.timeScale = 0;
    }
    public void incaseOfLose()
    {
        FindObjectOfType<FirstPersonController>().lockCursor = false;
        FindObjectOfType<FirstPersonController>().cameraCanMove = false;
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        loseCanvas.enabled = true;
        Time.timeScale = 0;
    }
    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
    public void exit()
    {
        Application.Quit();
    }
}
