using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    private int score;
    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI wonText;
    public Button restarttButton;
    public Button gobackButton;
    private int scoreToAdd = 0;
  
    

    // Start is called before the first frame update
    void Start()
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Updatescore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void finish()
    {
        wonText.gameObject.SetActive(true);
    }
    
    public void gameover()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restarttButton.gameObject.SetActive(true);
        gobackButton.gameObject.SetActive(true);
        
    }
    public void startbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void restartbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goback()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
