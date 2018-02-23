using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour {

	public void clickyes()
	{
		//check if yes is correct(done)
		//add points
		//set scroll possition value to 1(done)
		//call init()(done)
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
		Debug.Log("you cliked yes");
	}

}
