using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

[System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int gameStartScene;
    public TMPro.TextMeshProUGUI scoreText;

   
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval = 1;
    public float obstacleSpeed = 10;
    public float obstacleOffsetX = 0;
    public Vector2 obstacleOffsetY = new Vector2(0, 0);
    public AudioSource audioSourceGameOver;
    

   
    [HideInInspector]
    public int score;

    private bool isGameOver = false;

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void EndGame()
    {
        // Set flag
        isGameOver = true;

        // Print message
        Debug.Log("Game over... Your score was: " + score);

        audioSourceGameOver.Play();

        // Reload scene
        StartCoroutine(ReloadScene(5));
    }

    private IEnumerator ReloadScene(float delay)
    {
        // Wait
        yield return new WaitForSeconds(delay);

        // Reload scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
