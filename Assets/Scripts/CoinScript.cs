using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    
		Vector2 pos;
		bool striken;

		AudioSource aud;

		public AudioClip CoinCollision;


    void Start()
    {
    	pos = transform.position;
    	aud = gameObject.AddComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
    	striken = GameObject.Find("striker").GetComponent<StrikeScript>().Striken;
    	if(striken == true)
        {
        	pos = transform.position;
        }

        if(striken == false)
        {
        	transform.position = pos;
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
    	if(striken == true)
    	{
	    	if(obj.gameObject.name == "RedCoin" || 
	    		obj.gameObject.name == "Black" || 
	    		obj.gameObject.name == "White" || 
	    		obj.gameObject.name == "White(Clone)" || 
	    		obj.gameObject.name == "Black(Clone" ||
	    		obj.gameObject.name == "striker"||
	    		obj.gameObject.name == "Edges")
		    {
		    		aud.clip = CoinCollision;
		    		aud.Play();
		    }
    	}
    }
}
