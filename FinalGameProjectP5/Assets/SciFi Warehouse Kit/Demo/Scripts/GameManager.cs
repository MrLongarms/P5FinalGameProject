using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timertext;
    private int score;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(true);
        timertext.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
