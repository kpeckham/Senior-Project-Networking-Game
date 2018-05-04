using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SegmentationTake3 : MonoBehaviour {

    public BoxCollider2D ParcCollider;
    public GameObject ObjParcel1;           // Parcel Game object is created
    public GameObject ObjParcel2;           // Parcel Game object is created
    public GameObject ObjParcel3;           // Parcel Game object is created
    public GameObject ObjParcel4;           // Parcel Game object is created
    public GameObject ObjBox;              // Box Game object is created
    public GameObject ObjTrash;            // Trash Game object is created

    public Text parcTxt1;
    public Text parcTxt2;
    public Text parcTxt3;
    public Text parcTxt4;

    private Vector3 startpos;
    private Vector3 startPosGame;           // parcel gets moved out of the screen where it starts its life
    private Vector3 startpostSpeed;
    private Vector3 endPosSpeed;

    public Transform target;
    private float distance = 149f;        // distance object needs to be send back to
    private float distanceRight = 250f;
    private float speed = 1;

    private List<int> listOfParcels = new List<int>();  // the values of each parcel will be stored in this list
    private List<int> listOfBoxes = new List<int>();    // the values of each box will be stored in this list
    private List<int> listOfParcelforCheck = new List<int>();       // list that will be used for checking conditions( this contains our boxes numbers /10)
    private List<string> listOfStrBox = new List<string>();  // the string representation of each box is stored in this list
    
    public List<GameObject> POBoxes;
    public List<Text> POText;

    void MoveFunc(GameObject ObjParcel)   //GameObject SegmentationTake3
    {
        startpos = ObjParcel.transform.position;
        startPosGame = ObjParcel.transform.position + Vector3.left * distance;
        ObjParcel.transform.position = Vector3.Lerp(startpos, startPosGame, 1f);
        transform.position += transform.forward * Time.deltaTime;       // use speed that you works best  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  
    }

    void MoveSpeed(GameObject ObjParcel)
    {
        startpostSpeed = ObjParcel.transform.position;
        endPosSpeed = ObjParcel.transform.position + Vector3.right * distanceRight;
        float step = speed * Time.deltaTime*2;  
        ObjParcel.transform.position = Vector3.MoveTowards(startpostSpeed, endPosSpeed, step);   
    }

    void Start()
    {
        int boxNum = 0;                     // number of the first digit of the box
        int boxOrdNum = 0;                  // number of the second digit of the box
        int box = 0;                        // number of the whole value of the box this will be used to identify the whole number

        string strLetters = "ABCD";         // string of all the letter we will use
        int numBoxForStr = 0;               // number for each box that we will convert to a string

        string strBox;                 // string that will represent each box it will consist of one number and one letter
        strBox = string.Empty;

        for (int i = 0; i < 16; i++)
        {
            boxNum = boxNum + 10;                   // add 10 to the first digit of the bx
            numBoxForStr = numBoxForStr + 1;        // the number of each box

            foreach (char c in strLetters)              // loop that makes our string for each object
            {
                string BoxForStr = numBoxForStr.ToString();     // make our 1 ,2 ,3, into a string
                strBox = BoxForStr + c;                        // loop through each character in our "ABCD" string and add to new string
                listOfStrBox.Add(strBox);                       // add each number and letter that represents a box to a string
            }

            for (int j = 0; j < 4; j++)
            {
                boxOrdNum = boxOrdNum + 1;  // add one to the second digit of the box
                box = boxNum + boxOrdNum;   // add both values to get the value of the box

                listOfParcels.Add(box);                 // add each parcel to our list as we iterate through the loop
                j++;
            }
            i++;
        }

        int numOfparcel = listOfParcels.Count;      // number of items in list so number of parcels in our list

        Random rand = new Random();
        int randParcel;

        for (int parcelIndex = 0; parcelIndex < numOfparcel; parcelIndex++)
        {
            if (parcTxt1.text == "")
            {
                int ii = listOfParcels[parcelIndex];     // assign your textbox or your gamebject value here for ii jj kk and ll!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                parcTxt1.text = listOfStrBox[parcelIndex];      // assign your string for that box
                parcelIndex++;
                MoveFunc(ObjParcel1);
                MoveSpeed(ObjParcel1);
                // get item position and move certain set of value so it goes to the back again     (could use GameObject.Find("Your_Name_Here").transform.position;)!!!!!!!!!!!!!!!!!!
            }

            if (parcTxt2.text == "")
            {
                int jj = listOfParcels[parcelIndex];
                parcTxt2.text = listOfStrBox[parcelIndex];      // assign your string for that box
                parcelIndex++;
                MoveFunc(ObjParcel2);
                // get item position and move certain set of value so it goes to the back again     (could use GameObject.Find("Your_Name_Here").transform.position;)!!!!!!!!!!!!!
            }

            if (parcTxt3.text == "")
            {
                int randNum = Random.Range(0, 3);
                if (randNum != 3)
                {
                    int kk = listOfParcels[parcelIndex];
                    parcTxt3.text = listOfStrBox[parcelIndex];
                    parcelIndex++;
                    MoveFunc(ObjParcel3);
                }
                else
                {
                    randParcel = listOfParcels.Count;
                    int kk = listOfParcels[Random.Range(0, randParcel)];     // choose a random value of the list to mix it up there is a 25% chance that our value will be random
                    parcTxt3.text = listOfStrBox[parcelIndex];               // assign your string for that box
                    if (randParcel == parcelIndex)                           // if our random value does end up being the parcel that should be next in order we increment our parcelIndex so our order works for the next parcels
                    {
                        parcelIndex++;
                    }
                    MoveFunc(ObjParcel3);
                }
                // get item position and move certain set of value so it goes to the back again     (could use GameObject.Find("Your_Name_Here").transform.position;)!!!!!!!!!!!!!!!!!!!!!!!!!!
            }

            if (parcTxt4.text == "")
            {
                int ll = listOfParcels[parcelIndex];
                parcTxt4.text = listOfStrBox[parcelIndex];      // assign your string for that box
                parcelIndex++;
                MoveFunc(ObjParcel4);
                // get item position and move certain set of value so it goes to the back again     (could use GameObject.Find("Your_Name_Here").transform.position;)!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }
    }

    void checkIfCorrect()
    {
        // do this loop if item is selected or it hits the collider
        // itemselected is the value of the object so (11,12,13,14,21,22,23,24......)!!!!!!!!!!!!!!!!!!!!!!!!!!!
        int ones;
        int itemselected = 0;
        int tens;
        int fullCheckNum;
        int checkParcIndex = 0;
        int numWrong = 0;

        if (listOfBoxes.Contains(itemselected) != true)                // when gameobject is selected check if the item we have selected is not in listOfBoxes
        {
            ones = itemselected % 10;              // get ones digit
            tens = itemselected / 10;           // get tens digit

            if (ones == 1)                                         // if parcel 11,21,31,41 so the first parcel would get put into a certain postal box
            {
                listOfBoxes.Add(itemselected);
                listOfParcelforCheck.Add(itemselected);                 // we use this to check for the parcels that are already delivered to determine if the next one is added in order
                listOfParcelforCheck[checkParcIndex] /= 10;
                checkParcIndex++;
                POText[itemselected-1].text = "A";

                // if parcel is then inserted into box fullCheckNum delete object and add letter A to our certain postal box!!!!!!!!!!!!!!!!!!!!
            }
            else
            {
                if (listOfParcelforCheck.Contains(tens) == true)
                {
                    fullCheckNum = ones + tens;        // add number back together 

                    if (listOfBoxes.Contains(fullCheckNum - 1))
                    {
                        listOfBoxes.Add(itemselected);
                        listOfParcelforCheck.Add(itemselected);
                        listOfParcelforCheck[checkParcIndex] /= 10;
                        if (ones == 2)
                        {
                            POText[itemselected - 1].text = "B";                       
                        }
                        if (ones == 3)
                        {
                            POText[itemselected - 1].text = "C";                          
                        }
                        if (ones == 4)
                        {
                            POText[itemselected - 1].text = "D";                   
                        }

                        checkParcIndex++;

                        // if parcel is then inserted into box fullCheckNum delete object and add letter B to our certain postal box!!!!!!!!!!!!!!!!!!!
                        // else add to numWrong
                    }
                    else
                    {
                        // if item is inserted into trashcan delete object!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        numWrong++;
                    }
                }
            }
            if (numWrong >= 3)
            {
                //    exit scene
            }
        }
        else
        {
            // if item is inserted into trashcan delete object!!!!!!!!!!!!
            numWrong++;
        }
    }
    // exit screen
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("IT is working");
        if (collision.gameObject.name == "Parcel1")
        {
            Debug.Log("HELLLLLLLLo");
        }
    }

    //bool OnTriggerEnter(Collider col)
    //{
    //    if (true)
    //    {
    //        checkIfCorrect();
    //        MoveFunc(ObjParcel1);
    //        return true;
    //    }
    //    return false; 
    //}

    private void Update()
    {
        //bool itemselect = false;
        //bool hit = false;
        
        if  (true)//OnTriggerEnter(ParcCollider)==false
        {
            MoveSpeed(ObjParcel1);                 // move parcels
            MoveSpeed(ObjParcel2);
            MoveSpeed(ObjParcel3);
            MoveSpeed(ObjParcel4);
        } 
    }
}



//foreach (var items in listOfStrBox) {
//    Debug.Log(items);

//}