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
    private float spawnRate = 2.0f;
    //public float currCountdownValue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCargo());
        score = 0;
        UpdateScore(0);
        //StartCoroutine(StartCountdown());
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

   // public IEnumerator StartCountdown(float countdownValue = 30.0f)
    //{
        //currCountdownValue = countdownValue;

        //while (currCountdownValue > 0)
        //{
            //Debug.Log(timertext.text = "Time: " + currCountdownValue);
            //yield return new WaitForSeconds(1.0f);
            //currCountdownValue--;

            //if (currCountdownValue > 0.0)
            //{

            //}
        //}
    //}
}
