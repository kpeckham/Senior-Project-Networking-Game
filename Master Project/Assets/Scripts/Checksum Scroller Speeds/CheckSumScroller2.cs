using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CheckSumScroller2 : MonoBehaviour {

	// object we will want to move
	public GameObject Scroller;
	public GameObject textBox;
	public int userpoints;
	public Text userpoints2;

	private Vector3 startpos;
	private Vector3 endpos;

	private float distance = 850f;

	private float time = 5;

	private float currentTime = 0;

	// Use this for initialization
	void Start()
	{
		startpos = Scroller.transform.position;

		endpos = Scroller.transform.position + Vector3.down * distance;
	}

	// Update is called once per frame
	void Update()
	{
		currentTime += Time.deltaTime;

		float perc = currentTime / time;

		if (perc > 1) {
			currentTime = 0;
			perc = 0;
			randomChecksumGenerator2 randomScript = textBox.GetComponent<randomChecksumGenerator2> ();
			randomScript.Init ();

		}
		//UnityEngine.Debug.Log (perc);
		Scroller.transform.position = Vector3.Lerp(startpos, endpos, perc);
	}

	public void usercorrect()
	{
		setTimeOut(true);
	}

	public void userincorrect()
	{
		setTimeOut(false);
	}

	public void setTimeOut(bool userchoice)
	{
		randomChecksumGenerator2 randomScript = textBox.GetComponent<randomChecksumGenerator2> ();
		if (randomScript.ansCorrect == userchoice)
		{ 
			Debug.Log("Correct");
			userpoints +=5;
			//Debug.Log(userpoints);
			string number = userpoints.ToString();
			Debug.Log(number);
			userpoints2.text = (number);
		}
		else {
			Debug.Log("Incorect");
			userpoints -=1;
			//Debug.Log(userpoints);
			string number = userpoints.ToString();
			Debug.Log(number);
			userpoints2.text = (number);
		}
		currentTime = 20;
	}
	public void resetuserpoints()
	{
		userpoints =0;
		userpoints2.text = " ";
	}

}
