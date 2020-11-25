using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StrikeScript : MonoBehaviour
{
    public Rigidbody2D rb2D;

    public float thrust;
    
    public bool Striken = false;
    public bool Player1 = true;
    public bool Chance = true;
    public bool RedMode = false;
    public bool PenaltyPaid = false;
    public bool RedPacked = false;
    
    public Material linematerial;

    public Slider strikeAngle1;
    public Slider strikePower1;
    public Slider strikePosition1;

    public Slider strikeAngle2;
    public Slider strikePower2;
    public Slider strikePosition2;

   public float strikerPositionValue;
   public float strikerPowerValue;
   public float strikerAngleValue;

   public float yval;

    public GameObject RedCoin;
    public GameObject GuideLine;
    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject Reset1;
    public GameObject Reset2;
    public GameObject Launch1;
    public GameObject Launch2;

    //public GameObject GameController;

    public GameObject ControllerObj;
	GameController GC;

	public AudioSource aud;

	public AudioClip StrikeClip;
	public AudioClip EdgeHitClip;



    void Awake()
    {
    	Screen.orientation = ScreenOrientation.Landscape;

    }
    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        GC = ControllerObj.GetComponent<GameController>();
        aud = gameObject.GetComponent<AudioSource>();

        //transform.position = new Vector3(0.0f, -2.0f, 0.0f);
        //DrawLine(transform.position,new Vector2(0f,4.3f), Color.black);

        Canvas1.SetActive(true);
    	Canvas2.SetActive(false);

    	yval =  -2.45f;
    	transform.rotation = Quaternion.Euler(0f,0f,0f);
    	strikerPositionValue = strikePosition1.value;
    	strikerAngleValue = strikeAngle1.value;
    	strikerPowerValue = strikePower1.value;
    }

    void Update()
    {

    	//Debug.Log(Math.Sqrt(Math.Pow(rb2D.velocity.x,2) + Math.Pow(rb2D.velocity.y,2)));
    	if(Striken == false && Player1 == true)
    	{
    		Reset1.SetActive(false);
    	}
    	if(Striken == true && Player1 == true)
    	{
    		Reset1.SetActive(true);
    	}

    	if(Striken == false && Player1 == false)
    	{
    		Reset2.SetActive(false);
    	}
    	if(Striken == true && Player1 == false)
    	{
    		Reset2.SetActive(true);
    	}

    	
    	SetPrefs(Player1);

    	if(Striken == false)
    	{
    		//Debug.Log(strikerPositionValue);

    		if(strikerPositionValue > -1.87f && strikerPositionValue < 1.87f) 
    		transform.position = new Vector2(strikerPositionValue,yval);

    		if(strikerPositionValue > 1.87f)
    		transform.position = new Vector2(2.12f,yval);

    		if(strikerPositionValue < -1.87f)
    		transform.position = new Vector2(-2.12f,yval);


    	//DrawLine(transform.position,transform.up * 50f , Color.black);
    	}

    	//Debug.Log(transform.position + new Vector3(transform.position.x,1f,transform.position.z));
    	
    	Screen.orientation = ScreenOrientation.Landscape;
    	//Debug.Log(transform.rotation.Euler());
    	transform.rotation = Quaternion.Euler(0,0,strikerAngleValue);
    	thrust = strikerPowerValue;
        


        if (Input.GetKeyDown(KeyCode.Space) && Striken == false)
        {
        	Launch();	
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
        	ResetPosition();
        }

        
    }

    // void DrawLine(Vector3 start, Vector3 end, Color color)/*, float duration = 0.2f)*/
    // {
    //            	float duration = 0.03f;
    //              GameObject myLine = new GameObject();
    //              myLine.transform.position = start;
    //              myLine.AddComponent<LineRenderer>();
    //              LineRenderer lr = myLine.GetComponent<LineRenderer>();
    //              lr.material = linematerial;
    //              //lr.SetColors(color, color);
    //              lr.SetWidth(0.04f, 0.04f);
    //              lr.SetPosition(0, start);
    //              lr.SetPosition(1, end);
    //              GameObject.Destroy(myLine, duration);
    // }

    public void ResetPosition()
    {

    	//Debug.Log(Chance);
    	if(RedMode == true && GC.Scored == false)
    	{
    		if(Player1 == true)
    		{
    			GC.Score1 -= 3;
    			Instantiate(RedCoin, new Vector3(0f,0f,-0.4f), Quaternion.identity);
    		}
    		if(Player1 == false)
    		{
    			Instantiate(RedCoin, new Vector3(0f,0f,-0.4f), Quaternion.identity);
    			GC.Score2 -= 3;
    		}
    		
    	}
    	if(RedMode == true && GC.Scored == true)
    	{
    		RedPacked = true;
    	}

		if(Chance == false)  ChangePlayer();
		
		PenaltyPaid = false;
		GC.Scored = false;
		RedMode = false;
    	GuideLine.SetActive(true);
    	Striken = false;
        transform.position = new Vector2(0f,yval);
        //Debug.Log("Reset");
    }

    public void Launch()
    {
    	aud.clip = StrikeClip;
    	
    	Chance = false;
    	GuideLine.SetActive(false);
    	if(Striken == false)
    	{
    		Striken = true;
        	rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        	aud.Play();
        	//Debug.Log("Launched");
    	}
    	//Invoke("ResetPosition",3f);
    }


    public void ChangePlayer()
    {
    	Player1 = !Player1;
    	//ResetPosition();

    }

    public void SetPrefs(bool p)
    {
    	if(p == true)
    	{
    		Canvas1.SetActive(true);
    		Canvas2.SetActive(false);

    		yval =  -2.45f;
    		//transform.rotation = Quaternion.Euler(0f,0f,0f);
    		strikerPositionValue = strikePosition1.value;
    		strikerAngleValue = strikeAngle1.value;
    		strikerPowerValue = strikePower1.value;

    	}
    	if(p == false) 
    	{
    		Canvas2.SetActive(true);
    		Canvas1.SetActive(false);

    		yval = 2.45f;
    		//transform.rotation = Quaternion.Euler(0f,0f,-180f);
    		strikerPositionValue = strikePosition2.value;
    		strikerAngleValue = strikeAngle2.value;
    		strikerPowerValue = strikePower2.value;
    	}
    }

    void OnCollisionStay2D(Collision2D obj)
    {
    	if(Striken == false)
    	{
    		//Debug.Log("InsideCoins");

    		if(Player1 == true)  Launch1.SetActive(false);

    		if(Player1 == false)  Launch2.SetActive(false);
    	}
    	
    }
    void OnCollisionExit2D(Collision2D obj)
    {
    	if(Striken == false)
    	{
    		//Debug.Log("OutsideCoins");

    		if(Player1 == true)  Launch1.SetActive(true);

    		if(Player1 == false)  Launch2.SetActive(true);
    	}
    	
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
    	if(obj.gameObject.name == "Edges")
    	{
    		aud.clip = EdgeHitClip;

    		double magnitude = Math.Sqrt(Math.Pow(rb2D.velocity.x,2) + Math.Pow(rb2D.velocity.y,2));
			aud.volume = 1f * (float)(magnitude/25);
    		// if(Math.Abs(rb2D.velocity.y) < 0.5f)  aud.volume = 0.05f;
    		// else aud.volume = 1f;

    		Debug.Log("MAGNITUDE : " + magnitude);
    		Debug.Log("Volume: " + aud.volume);
    		aud.Play();
    	}

    }





}