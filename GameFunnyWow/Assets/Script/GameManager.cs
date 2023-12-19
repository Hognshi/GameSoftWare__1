using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] enemys;
    public Transform[] spawnPoint;
    public GameObject gameOverImg;
    public Text gameOverTxt;
    public Text CatchedEnemyTxt;
    public Text timeTXT;
    public Button gameOverBTN;
    public bool isEnd = false;
    public int CatchedEnemy = 0;

    int min = 0;  float sec = 0; float max = 0; float m = Random.Range(1, 2);
    void Start()
    {
        if (instance == null)                 
            instance = this;
        gameOverBTN.onClick.AddListener(BackToMain);
    }

    private void Update()
    {
        if (isEnd)
        {
            return;
        }
        sec += Time.deltaTime;
        max += Time.deltaTime;

        if(sec >= 60)
        {
            min++;
            sec = 0;
        }

        if(max >= m)
        {
            m = Random.Range(1, 2);
            max = 0;
            GameObject enemy = Instantiate(enemys[Random.Range(0, 4)], spawnPoint[Random.Range(0, 8)]);
            enemy.tag = "Enemy";
        }
        timeTXT.text = $"{min} : {(int)sec}";
    }

    public void GameOver()
    {
        CatchedEnemyTxt.text = $"¿‚¿∫ ¿˚ : {CatchedEnemy}";
        gameOverImg.SetActive(true);
        isEnd = true;
    }

    public void BackToMain()
    {

        SceneManager.LoadScene("GameScene");
    }
}
