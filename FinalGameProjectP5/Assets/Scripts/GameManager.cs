using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cargos;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;

    private float spawnRate = 2.0f;
    private float startTime;
    private int score;

    float minutes = 0;
    float seconds = 10;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        startTime = Time.time;


        StartCoroutine(SpawnCargo());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        Clock();
    }

    void Clock()
    {
        if (minutes > 0 && Mathf.Approximately(seconds, 0))
         {
             minutes--;
             seconds = 59;
             timerText.text = minutes.ToString() + ":" + seconds.ToString("f0");
             Debug.Log(minutes + " " + seconds);
         }
         else if (seconds > 0)
         {
             seconds -= Time.deltaTime;
             timerText.text = minutes.ToString() + ":" + seconds.ToString("f0");
             Debug.Log(minutes + " " + seconds);
         }
         else if (Mathf.Approximately(minutes, 0) && seconds <= 0)
         {
            Debug.Log("Go");
             restartButton.gameObject.SetActive(true);
             gameOverText.gameObject.SetActive(true);
             isGameActive = false;
         }
     }

    IEnumerator SpawnCargo()
    {
        while (isGameActive == true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, cargos.Count);
            Instantiate(cargos[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
            score += scoreToAdd;
            scoreText.text = "score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
