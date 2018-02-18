﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class randomChecksumGenerator : MonoBehaviour {

	// Use this for initialization
	void Start (int width, int percentageCorrect) {
		if (width != 3 || width != 4 || width != 5) {
			throw new System.ArgumentException("Width must be 3, 4, or 5");
		}
		List<string> displayValues = generateSum (width, percentageCorrect);
	}

	List<string> generateSum(int width, int percentageCorrect) {
		System.Random rand = new System.Random ();
		int percentage = rand.Next (1, 101);
		int num1 = 0;
		int num2 = 0;
		int sum = 0;

		if (width == 3) {
			num1 = rand.Next (1, 9);
			num2 = rand.Next (1, 9);

			sum = (num1 + num2) % 8;
		}

		else if (width == 4) {
			num1 = rand.Next (1, 17);
			num2 = rand.Next (1, 17);

			sum = (num1 + num2) % 16;
		}

		else if (width == 5) {
			num1 = rand.Next (1, 33);
			num2 = rand.Next (1, 33);

			sum = (num1 + num2) % 32;
		}
			

		if (percentage > percentageCorrect) {

			if (width == 3) {
				int notEqual = rand.Next (1, 9);
				sum = (sum + notEqual) % 8;
			} 

			else if (width == 4) {
				int notEqual = rand.Next (1, 17);
				sum = (sum + notEqual) % 16;
			} 

			else if (width == 5) {
				int notEqual = rand.Next (1, 33);
				sum = (sum + notEqual) % 32;
			}

		}

		string binarynum1 = Convert.ToString (num1, 2);
		string binarynum2 = Convert.ToString (num2, 2);
		string binarysum = Convert.ToString (sum, 2);
		return new List<string> (3){ binarynum1, binarynum2, binarysum };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
