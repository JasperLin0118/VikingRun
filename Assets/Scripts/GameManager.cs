using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score;
    public Text gameoverText;
    public static GameManager inst;
    public Text scoreText;
    public Canvas gameover;
    public Canvas pause;
    public Button resume;
    bool isGameover = false;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameover.enabled = false;
        pause.enabled = false;
        resume.onClick.AddListener(delegate { OnClick(); });
        inst = this;
    }

    void OnClick()
    {
        Time.timeScale = 1;
        pause.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover)
            return;
        score += Time.deltaTime;
        scoreText.text = "Score: " + ((int)score).ToString();
    }
    public void Gameover()
    {
        isGameover = true;
        gameover.enabled = true;
        gameoverText.text = scoreText.text;
        scoreText.enabled = false;
    }
}
