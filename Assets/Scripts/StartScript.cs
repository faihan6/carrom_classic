using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    
	public GameObject Canvas1;
	public GameObject Canvas2;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
    	Time.timeScale = 1;
    	SceneManager.LoadScene("GameScene");
    }

    public void backtomenu()
    {
    	Time.timeScale = 1;
    	Canvas1.SetActive(true);
    	Canvas2.SetActive(false);
    }

    public void instructions()
    {
    	Canvas1.SetActive(false);
    	Canvas2.SetActive(true);

    }

}
