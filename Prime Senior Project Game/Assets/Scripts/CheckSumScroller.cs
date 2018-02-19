using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckSumScroller : MonoBehaviour {

    // object we will want to move
    public GameObject Scroller;
	public GameObject textBox;

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
		UnityEngine.Debug.Log (perc);
        Scroller.transform.position = Vector3.Lerp(startpos, endpos, perc);
    }

}
