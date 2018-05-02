using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class CheckSumScroller : MonoBehaviour {

	// object we will want to move
	public GameObject Scroller;
	public GameObject textBox;
	public int userpoints;
	public Text userPointsText;

	private Vector3 startpos;
	private Vector3 endpos;

	private float distance = 1150f;

	private float time = 20;

	private float currentTime = 0;

	public int CheckGameOverNum = 0;

	// Use this for initialization
	void Start()
	{
		startpos = Scroller.transform.position;

		endpos = Scroller.transform.position + Vector3.down * distance;
		Debug.Log (startpos);
		Debug.Log (endpos);
	}

	// Update is called once per frame
	void Update()
	{
		currentTime += Time.deltaTime;

		float perc = currentTime / time;

		if (perc > 1) {
			currentTime = 0;
			perc = 0;
			randomChecksumGenerator randomScript = textBox.GetComponent<randomChecksumGenerator> ();
			randomScript.Init ();

		}
		//UnityEngine.Debug.Log (perc);
		Scroller.transform.position = Vector3.Lerp(startpos, endpos, perc);
	}

	public void changeMenuScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
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
		randomChecksumGenerator randomScript = textBox.GetComponent<randomChecksumGenerator> ();
		if (randomScript.ansCorrect == userchoice)
		{ 
			Debug.Log("Correct");
			userpoints +=5;
			Debug.Log(userpoints);
			string number = userpoints.ToString();
			Debug.Log(number);
			userPointsText.text = (number);
		}
		else {
			Debug.Log("Incorect");
			userpoints -=1;
			CheckGameOverNum +=1;
			if (userpoints < 0) {
				userpoints = 0;
			}
			Debug.Log(userpoints);
			string number = userpoints.ToString();
			Debug.Log(number);
			userPointsText.text = (number);
			if (CheckGameOverNum == 3) 
			{
				changeMenuScene ("ChecksumGameOver1-2");
			}
		}
		currentTime = 20;
	}
	public void resetuserpoints()
	{
		userpoints =0;
		userPointsText.text = "0";
	}

}
