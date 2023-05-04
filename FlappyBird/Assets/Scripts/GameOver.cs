using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int gameStartScene;


    public void StartGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(gameStartScene);

    }
   /* public void Restart()
    {
        Debug.Log("Restart");
        gameObject.SetActive(false);

        GameManager.Instance.Enable();
    }
   */

    public void Quit()
    {
        // This will test if the quit button works. 
       // UnityEditor.EditorApplication.isPlaying= false;
        Application.Quit();
        Debug.Log("Quit!");
    }

    
    public AudioSource audio;

    public void playButton()
    {
        audio.Play();
    }

}
