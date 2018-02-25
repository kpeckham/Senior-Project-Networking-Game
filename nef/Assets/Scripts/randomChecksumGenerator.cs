using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class randomChecksumGenerator : MonoBehaviour {
	public Text binarynums;
	public Text sum;
	public bool ansCorrect;
	public int 	currentlevel;
	// Use this for initialization
	void Start () {

		Init ();
	}

	public void Init() {
		int width = 3;
		int percentageCorrect = 50;
		//		if (width != 3 || width != 4 || width != 5) {
		//			throw new System.ArgumentException("Width must be 3, 4, or 5");
		//		}
		List<string> displayValues = generateSum (width, percentageCorrect);
		string checkText = displayValues [0] + '\n' + displayValues [1];
		binarynums.text = checkText;
		sum.text = displayValues [2];
	}

	public void currentlevel;
	{
		
	}

	List<string> generateSum(int width, int percentageCorrect) {
		System.Random rand = new System.Random ();
		int percentage = rand.Next (1, 101);
		int num1 = 0;
		int num2 = 0;
		int sum = 0;
		ansCorrect = true;

		if (width == 3) {
			num1 = rand.Next (0, 8);
			num2 = rand.Next (0, 8);

			sum = (num1 + num2) % 8;
		}

		else if (width == 4) {
			num1 = rand.Next (0, 16);
			num2 = rand.Next (0, 16);

			sum = (num1 + num2) % 16;
		}

		else if (width == 5) {
			num1 = rand.Next (0, 32);
			num2 = rand.Next (0, 32);

			sum = (num1 + num2) % 32;
		}
			

		if (percentage > percentageCorrect) {
			ansCorrect = false; 

			if (width == 3) {
				int notEqual = rand.Next (0, 8);
				sum = (sum + notEqual) % 8;
			} 

			else if (width == 4) {
				int notEqual = rand.Next (0, 16);
				sum = (sum + notEqual) % 16;
			} 

			else if (width == 5) {
				int notEqual = rand.Next (0, 32);
				sum = (sum + notEqual) % 32;
			}

		}

		string binarynum1 = Convert.ToString (num1, 2).PadLeft(3, '0');
		string binarynum2 = Convert.ToString (num2, 2).PadLeft(3, '0');
		string binarysum = Convert.ToString (sum, 2).PadLeft(3, '0');
		return new List<string> (3){ binarynum1, binarynum2, binarysum };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
