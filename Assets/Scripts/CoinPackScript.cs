using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinPackScript : MonoBehaviour
{

	public GameObject ControllerObj;
	GameController GC;

	public GameObject StrikerObj;
	private StrikeScript SC;

	public GameObject WhiteCoin;
	public GameObject BlackCoin;

	AudioSource aud;

	public AudioClip CoinPackedClip;

    void Start()
    {
    	GC = ControllerObj.GetComponent<GameController>();
    	SC = StrikerObj.GetComponent<StrikeScript>();
    	aud = gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
    	//Debug.Log("Ontriggerenter");
    	aud.clip = CoinPackedClip;
    	aud.Play();

    	if(obj.gameObject.name == "Black" || obj.gameObject.name == "Black(Clone)" )
    	{
    		
    		if(GC.Score2 == 8 && SC.RedPacked == false)
    		{
    			Instantiate(BlackCoin, new Vector3(0f,0f,-0.4f), Quaternion.identity);
    		}
    		else
    		{
	    		if(SC.Player1 == false)
	    		{
	    			GC.Scored = true;
	    			SC.Chance = true;
	    		}
	    		if(GC.Score2 < 0)
	    		{
	    			GC.Score2 += 1;
	    			Instantiate(BlackCoin, new Vector3(0f,0f,-0.4f), Quaternion.identity);
	    		}
	    		else GC.Score2 += 1;
    		}
    		

    		Destroy(obj.gameObject);
    	}

    	if(obj.gameObject.name == "White" || obj.gameObject.name == "White(Clone)" )
    	{
    		
    		if(GC.Score1 == 8 && SC.RedPacked == false)
    		{
    			Instantiate(WhiteCoin, new Vector3(0f,0f,-0.4f), Quaternion.identity);
    		}
    		else
    		{
	    		if(SC.Player1 == true)
	    		{
	    			GC.Scored = true;
	    			SC.Chance = true;
	    		}
	    		if(GC.Score1 < 0)
	    		{
	    			GC.Score1 += 1;
	    			Instantiate(WhiteCoin, new Vector3(0f,0f,-0.4f), Quaternion.identity);
	    		}
	    		else GC.Score1 += 1;
    		}
    		
    		Destroy(obj.gameObject);
    	}

    	if(obj.gameObject.name == "RedCoin" || obj.gameObject.name == "RedCoin(Clone)" )
    	{
    		SC.Chance = true;
    		
    		if(SC.Player1 == true) GC.Score1 += 3;
    		if(SC.Player1 == false) GC.Score2 += 3;

    		SC.RedMode = true;

    	SC.GuideLine.SetActive(true);
    	SC.Striken = false;
        SC.transform.position = new Vector2(0f,SC.yval);
        //Debug.Log("ResetRed");

    		Destroy(obj.gameObject);
    	}

    	if(obj.gameObject.name == "striker")
    	{
    		//Debug.Log("StrikerPacked");
    		if(SC.Player1 == true)
    		{
    			
    			SC.transform.position = new Vector2(0,0);
    			SC.rb2D.velocity = Vector3.zero;
    			if(SC.PenaltyPaid == false)
    			{
    				if(GC.Score1 >= 1)
    				Instantiate(WhiteCoin, new Vector3(0f,0f,-0.4f), Quaternion.identity);
    				
    				GC.Score1 -= 1;
    				SC.PenaltyPaid = true;
    			}
    			
    		}
    		if(SC.Player1 == false)
    		{
    			
    			SC.transform.position = new Vector2(0,0);
    			SC.rb2D.velocity = Vector3.zero;
    			
    			if(SC.PenaltyPaid == false)
    			{
    				if(GC.Score2 >= 1)
    				Instantiate(BlackCoin, new Vector3(0f,0f,-0.4f), Quaternion.identity);
    				
    				GC.Score2 -= 1;
    				SC.PenaltyPaid = true;
    			}
    			
    		}
    	}
    	

    }
}
