using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
	
	public int score = 0;
	public GameStatus gamestatus;
	public bool GameOver;
    public Text scoreText;
    public Text TextGameOver;

    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gamestatus = GameStatus.Wait;
        score = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        switch (gamestatus) {
		case GameStatus.Play:
                scoreText.text = score.ToString();
			    break;
		case GameStatus.GameOver:
                scoreText.gameObject.SetActive(false);
                gameOverPanel.SetActive(true);
				GameOver = true;
                TextGameOver.text = "Score : " + score;
			    break;
		}
    }
    public void addScore(){
		score++;
		scoreText.text= "0"+ score;
	}	
		
	public enum GameStatus
	{
		Wait,
		Play,
		GameOver		
	}
}
