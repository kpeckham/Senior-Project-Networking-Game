//using System.Collections;
//using System;
//using System.Collections.Generic;
//using UnityEngine;


//public class SegmentationOwn : MonoBehaviour {
    
//	// Use this for initialization
//	void Start () {
//        int boxLevel = 20;
//        int numOfBoxes = 0;
//        int nthNum = 0;
//        int letterCounter = 0;
//        int nthLetter = 0;
//        string letters = "abcd";
//        List<List<int>> boxes = new List<List<int>>();
//        List<int> deliBoxes = new List<int>();
//        bool corBox = false;
//        List<int> sublist = new List<int>();

//        while (numOfBoxes < boxLevel)
//        {
//            int pkgsect;
//            System.Random RNG = new System.Random();
//            pkgsect = RNG.Next(1, 4);
//            int pkgnum;
//            pkgnum = RNG.Next(1, 25);       // package section (A-D)
//            pkgnum = pkgnum * 10;           // package number (1-25) multiple of 10

//            int totpkg;
//            totpkg = pkgsect + pkgnum;

//            deliBoxes.Add(totpkg);

//            numOfBoxes = numOfBoxes + 1;
//        }

//        int boxSect;
//        //int boxNum;
//        for (int i = 0; i < 26; i++)
//        {
//            for (int j = 0; j < 4; j++)               // creates three 0 sublists
//            {
//                boxSect = 0;
//                sublist.Add(boxSect);
//                boxes.Add(sublist);             // add to sublist 
//            }
//            //boxNum = 0;
//            //boxes.Add(boNum)
           

//            numOfBoxes = numOfBoxes + 1;
//        }


//        for (int k = 0; k<26; k++)
//        {
//            if (deliBoxes[k] == boxes.sublist[k] * 10 + 1)
//            {
//                corBox = true;
//            }

//            else
//            {
//                corBox = false;
//            }

//            if (corBox == true)
//            {
//                sublist.Add(deliBoxes[k]);
//                boxes.Add(sublist);                // add box into sublist if the previous box is found in boxes
//            }

//            else
//            {
//                deliBoxes.RemoveAt(k);              // remove box if it the previous box is not a previous box
//            }
//        }
         
        
//        //List<int> boxesList = new List<int>();
//        //boxesList.Add(int1);
//        //boxesList.Add(int2);


//        //List<string> boxesList = new List<string>(new string[] { "%s", "%s", "%s" });
//    }
	
//	// Update is called once per frame
//	void Update () {
		
//	}
//}



//letterCounter = 0;

//            if (nthLetter == 7)
//            {
//                nthLetter = 0;
//                nthNum = nthNum + 1;   // integer of the box
//            }
//            while (letterCounter == 0)
//            {
//                char curLetter = letters[nthLetter]; // letter of the box
//letterCounter = 1;
//            }
//            string boxNumString = nthNum.ToString();   // convert the number of the first box to integer

//string nthBox = boxNumString + "{curLetter}";
//Console.WriteLine(nthBox);
//            nthLetter = nthLetter + 1;

//            boxes.Add(nthBox);      // add box just made to string to make a list of boxes 

