using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cargos;

    private int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timertext;
    private float spawnRate = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCargo());
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(true);
        timertext.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCargo()
    {
        while (true)
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
}
