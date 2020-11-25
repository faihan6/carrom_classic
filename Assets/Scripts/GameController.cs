using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public static GameController instance;
	
	public bool striken;
	public bool Scored = false;

	public int Score1 = 0;
	public int Score2 = 0;

	public Text ScoreText1;
	public Text ScoreText2;
	public Text Wintext;

	public GameObject GOpanel;
	public GameObject PausePanel;
	public GameObject Canvas1;
	public GameObject Canvas2;

	public Scene MainMenuScene;
	public Scene GameScene;


    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText1.text = "Score: " + Score1 ;
        ScoreText2.text = "Score: " + Score2 ;

        if(Score1 == 12)
        {

        	GOpanel.SetActive(true);
        	Canvas1.SetActive(false);
        	Canvas2.SetActive(false);
        	Wintext.text = "Player 1 Wins";
        	Time.timeScale = 0;

        }
        if(Score2 == 12)
        {

        	GOpanel.SetActive(true);
        	Canvas1.SetActive(false);
        	Canvas2.SetActive(false);
        	Wintext.text = "Player 2 Wins";
        	Time.timeScale = 0;
        }
    }

    public void Reload()
    {
    	Time.timeScale = 1;
    	SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
    	Time.timeScale = 1;
    	SceneManager.LoadScene("StartScene");
    }

    public void PauseMenu()
    {
    	PausePanel.SetActive(true);
    	Time.timeScale = 0;
    }

    public void Back()
    {
 		PausePanel.SetActive(false);
    	Time.timeScale = 1;
    }


}
