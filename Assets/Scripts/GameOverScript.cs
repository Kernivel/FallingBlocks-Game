using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text score;
    public bool gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        FindObjectOfType<PlayerControl> ().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){
            if(Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(0);
            }
        }
    }
    void OnGameOver(){
        gameOverScreen.SetActive(true);
        score.text = Time.time.ToString();
        gameOver = true;
    }
}
