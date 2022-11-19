using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class genrowbad : MonoBehaviour
{

    //Global Variable
    public GameObject[] rows;
    public GameObject generate;
    public float timeRemaining = 3.5f;

    public GameObject textinput;
    private int cointotal;
    public InputField inputter;

    public GameObject coinText;
    public int PlayerCoin = 10;
   

    // Start is called before the first frame update
    void Start()
    {
        coinText.GetComponent<TextMeshPro>().text = PlayerCoin.ToString() + " Coins";
    }

    //Going to generate a sequence: generate.cs
    //spin all the rows: row.cs
    //to that sequence
    public void RunGame() //when you clikc the button it will run this method
    {
        string textcoin = inputter.text;
        print(textcoin);
        //3 if statements 
        if (textcoin == "1")
        {
            print("going into 1");
            cointotal = 1;
            PlayerCoin = PlayerCoin - 1;
        }
        if (textcoin == "2")
        {
            print("going into 2");
            cointotal = 2;
            PlayerCoin = PlayerCoin - 2 ;
        }
        if (textcoin == "3")
        {
            print("going into 3");
            cointotal=3;
            PlayerCoin = PlayerCoin -3;
        }
     
coinText.GetComponent<TextMeshPro>().text = PlayerCoin.ToString() + " Coins";
        //The first if statement should check if the user inputed 1 coint
        // print("user Inputed 1 coint")
        //the second if statment should check if the user inputed 2  coins
        // print("user Inputed 2 coint")
        //the second if statment should check if the user inputed 3 coins
        // print("user Inputed 3 coin")
        
        StartCoroutine(RunGameWait());
   
    }

    IEnumerator RunGameWait()
    {
        int count = 0;
        bool winner = false;
       
        int[] ans = generate.GetComponent<generate>().generateSeq(); //call generate return list of
        if (ans[0] != ans[1])
        {
            print("Mixed");
        }
        else {
            print("winner");
            winner = true;
        }
        //mixing or matching numbers
        float[] rowpos = new float[3];
        foreach(GameObject i in rows) //go through all our slots and spin them all
        {
            //[1,2,3] 
            i.GetComponent<BADrow>().startRotating(ans[count]); //ROTATE() using the sequence we made
            rowpos[count] = i.GetComponent<BADrow>().y;
            count++;
            yield return new WaitForSeconds(4.25f);
        }

        if (winner == true)
        {
          
            if (ans[0] == 5)
            {
                print("you get trriple money");
                if (cointotal == 3)
                {
                    cointotal = cointotal * 3;
                    PlayerCoin = PlayerCoin+cointotal;
                }
                
            }
            if (ans[0] == 4)
            {
                print("you get trriple money");
                cointotal = cointotal * 3;
                PlayerCoin = PlayerCoin+cointotal;
            }
            if (ans[0] == 3)
            {
                print("you get double money");
                cointotal = cointotal * 2;
                PlayerCoin = PlayerCoin+cointotal;
            }
            if (ans[0] == 2)
            {
                print("you get double money");
                cointotal = cointotal * 2;
                PlayerCoin = PlayerCoin+cointotal;
            }
            if (ans[0] == 1)
            {
                print("you get one money");
                cointotal = cointotal + 1;
                PlayerCoin = PlayerCoin+cointotal;
            }
            if (ans[0] == 0)
            {
                print("you get one money");
                cointotal = cointotal + 1 ;
                PlayerCoin = PlayerCoin+cointotal;
            }

                    coinText.GetComponent<TextMeshPro>().text = PlayerCoin.ToString() + " Coins";

            print("I am a winner");
            
            
            
           
            winner = false;
            
        }
       
      
        yield return new WaitForSeconds(4.0f);
        rows[0].transform.position = new Vector3(rows[0].transform.position.x, 1f, rows[0].transform.position.z);
        rows[1].transform.position = new Vector3(rows[1].transform.position.x, 1f, rows[1].transform.position.z);
        rows[2].transform.position = new Vector3(rows[2].transform.position.x, 1f, rows[2].transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


    