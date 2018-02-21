using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckSumScroller : MonoBehaviour {

    // object we will want to move
    public GameObject Scroller;
	public GameObject textBox;
    public int userpoints;
    public int userchoice2;
    public Text scoreText;

    private Vector3 startpos;
    private Vector3 endpos;

    private float distance = 450f;

    private float time = 20;

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
			randomChecksumGenerator randomScript = textBox.GetComponent<randomChecksumGenerator> ();
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
        randomChecksumGenerator randomScript = textBox.GetComponent<randomChecksumGenerator> ();
        if (randomScript.ansCorrect == userchoice)
        { 
            Debug.Log("Correct");
            userpoints +=5;
            Debug.Log(userpoints);
        }
        else {
            Debug.Log("Incorect");
            userpoints -=1;
            Debug.Log(userpoints);
        }
        currentTime = 20;
    }

}
