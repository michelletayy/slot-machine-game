using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class generaterow : MonoBehaviour
{
    
    public bool HandlePulled = false;

    //Global Variable
    public GameObject[] rows;
    public GameObject generate;
    private AudioSource source;
    public AudioClip handlePull;
    public AudioClip winningSound;
    public float timeRemaining = 3.5f;


    public GameObject winScript;
    public GameObject textinput;
    private int cointotal;
    public InputField inputter;

    public GameObject coinText;
    public int PlayerCoin = 10;

    public bool winTime = false;
   
    private String[] icons = new String[]{"chocolate", "gumdrop", "cotton", "marsh", "candy", "lollipop"};

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";
    }

    //Going to generate a sequence: generate.cs
    //spin all the rows: row.cs
    //to that sequence
    public void RunGame() //when you clikc the button it will run this method
    {
        // source.PlayOneShot(handlePull);
        // source.PlayOneShot(handlePull);
        // int count = 0;
        // int[] ans = generate.GetComponent<generate>().generateSeq(); //call generate return list of 
        // //mixing or matching numbers
        // foreach(GameObject i in rows) //go through all our slots and spin them all
        // {
        //     //[1,2,3] 
        //     i.GetComponent<row>().startRotating(ans[count]); //ROTATE() using the sequence we made
        //     count++;
        // }
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
     
        coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";
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
        source.PlayOneShot(handlePull);
        int count = 0;
        bool winner = false;
       
        int[] ans = generate.GetComponent<generate>().generateSeq(); //call generate return list of
        if (ans[0] != ans[1])
        {
            print("Mixed");
        }
        else {
            winner = true;
        }
        //chocolate 0
        //gumdrop 1 
        //mixing or matching numbers
        foreach (int i in ans){
            print(i);
            print(icons[i]);
            }

        foreach(GameObject i in rows) //go through all our slots and spin them all
        {
            //[1,2,3] 
            i.GetComponent<row1>().startRotating(ans[count]); //ROTATE() using the sequence we made
            count++;
            // 
        }
        yield return new WaitForSeconds(1f);
        if (winner == true)
        {
            winTime = true;
            source.PlayOneShot(winningSound);
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

                    coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";

            print("I am a winner");
            winScript.GetComponent<win>().flashLights();
            winScript.GetComponent<win>().panText();
            winner = false;
        
        }
        else {
                     for(int i = 0; i < 3; i++) //go through all our slots and spin them all
            {
            //[1,2,3] 
            rows[i].transform.position = new Vector3(rows[i].transform.position.x, 1.31f, rows[i].transform.position.z);
           
         }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winTime == true) {
        if (timeRemaining > -3)
        {
            timeRemaining -= Time.deltaTime;
        }
        else {
            winTime = false;
            timeRemaining = 3.5f;
            winScript.GetComponent<win>().TimeUp = false;
            winScript.GetComponent<win>().text.transform.position = winScript.GetComponent<win>().textpos;
                for(int i = 0; i < 3; i++) //go through all our slots and spin them all
            {
            //[1,2,3] 
            rows[i].transform.position = new Vector3(rows[i].transform.position.x, 1.31f, rows[i].transform.position.z);
           
         }

        }
    }

    }
}


    