using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


//System Overview 

//RunGame() will be triggered when you click the lever button
//It will determine if you can spin. 
//... If you can play
//RunGameWait() generate a sequence using the generate script, then 
//spin the rows using the row1 script. Wait 4 seconds for the rows to finish 
//spinning, 
    //If you won, the winscript will be called to play the winning animations then betcaluclation to determine how much you won
//Then the lever is reactivated 









public class generaterow : MonoBehaviour
{
    //Variable


    //Instance Variables, declared outside of every method
    //begin with either public, private 
    //public - Visible Anywhere, I can acess this varible from a different script
    //private - WE can only acess this varible inside of this file aka generaterow

    public bool HandlePulled = false;

    //Global Variable
    public GameObject[] rows;
    public GameObject generate;
    public AudioSource source;
    public AudioClip handlePull;
    public AudioClip winningSound;
    public AudioClip spinners;
    public float timeRemaining = 3.5f;

    public bool badSlot;


    public GameObject winScript;
    public GameObject textinput;
    private int cointotal = 1;
    public InputField inputter;

    public GameObject coinText;
    public int PlayerCoin = 10;

    public bool winTime = false;
   
    private String[] icons = new String[]{"chocolate", "gumdrop", "cotton", "marsh", "candy", "lollipop"};

    public GameObject button; 

    public GameObject inputCoins;  

    public bool noSound = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";
    }

    //Going to generate a sequence: generate.cs
    //spin all the rows: row.cs

    //These two methods control the button and how much the player will bet



    public void buttonDown() {
        if (cointotal != 1) {
            cointotal = cointotal - 1;
        }
        inputCoins.GetComponent<TextMeshProUGUI>().text = cointotal.ToString();
        
    }

    public void buttonUp() {
        if (cointotal != 3) {
            cointotal = cointotal + 1;
        }
        inputCoins.GetComponent<TextMeshProUGUI>().text = cointotal.ToString();
    }




    //This method is run everytime you press the lever
    //It checks your total coins and if you have at least 1 coin you may spin
    //

    public void RunGame() 
    {
        string textcoin = inputter.text; //ignore this line
        button.GetComponent<Button>().interactable = false; //DISABLES BUTTON
        if (PlayerCoin == 0){ //we don't have any coins left
            StartCoroutine(loss());
        }

        

        if (PlayerCoin - cointotal < 0) { //if you don't have enough coins to bet the amount you choose 
                                            //ex you have 2 coins and try to bet 3
            StartCoroutine(notEnough());
            
        }
        else {
            PlayerCoin = PlayerCoin - cointotal; 
            coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";
            StartCoroutine(RunGameWait());
        }
    }

    //Will wait 3 seconds then reload the current scene
    IEnumerator loss(){
        coinText.GetComponent<TextMeshProUGUI>().text = "No Coins, Restarting!";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Will wait 3 seconds then let you pull the lever again
    IEnumerator notEnough(){
        coinText.GetComponent<TextMeshProUGUI>().text = "Not enough";
        yield return new WaitForSeconds(3f);
        button.GetComponent<Button>().interactable = true;
        coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";
    }

    //This is the function that will generate a sequence of icons, and trigger the rows to spin
    //RunGameWait, IEnumerator function which allows us to Wait
    IEnumerator RunGameWait()
    {
        if (noSound == false) {
            source.PlayOneShot(handlePull);
        }
       
        int count = 0;
        bool winner = false;
       
        //We Generate this sequence in another script
        int[] ans = generate.GetComponent<generate>().generateSeq(); 


        if (ans[0] != ans[1])
        {
            print("Mixed");
        }
        else {
            print("Matching");
            winner = true;
        }
        

        foreach (int i in ans){
            print(icons[i]);
        }
     
        if (noSound == false) {
            source.PlayOneShot(spinners);
        }
        
        //after generating a sequence we spin all the rows using the row1 script

        foreach(GameObject i in rows) //go through all our slots and spin them all
        {
            i.GetComponent<row1>().startRotating(ans[count]); //ROTATE() using the sequence we made
            count++; 
        }


        yield return new WaitForSeconds(4f); //will pause the game to wait for the rows to finish spinning. 
                                    //We need to wait for the user to see what sequence they got before showing them winning animations
        
        print("Past Waiting");
        if (winner == true)
        {
            winTime = true;
            if (noSound == false) {
                source.PlayOneShot(winningSound);
            }
            if (cointotal != 0) {
                PlayerCoin = BetCalculation(cointotal, PlayerCoin, icons[ans[0]]);
            }
            if (badSlot == false){
                winScript.GetComponent<win>().flashLights();
                winScript.GetComponent<win>().panText();
            }
            coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";
            
            winner = false;
        
        }
        else {
            for(int i = 0; i < 3; i++) //go through all our slots and spin them all
            {
                rows[i].transform.position = new Vector3(rows[i].transform.position.x, 1.31f, rows[i].transform.position.z);
            }
            button.GetComponent<Button>().interactable = true;  
        }
        
    }

    //Takes in three inputs, the amound of couns the player betted, the amount of coins the player has in total,
    // and the streak the player obtained

     //5% Lolipop if you bet three coins you get triple back, 1 else 
      //10% Candy if you bet three coins you get triple back, 1 else 
      
       //15 Marsh if you bet more then 1 coin you get double back, 1 else  
       //20 Cotton if you bet more then 1 coin you get double back, 1 else 

        //20 Gumdrop 1 back 
          //40 Hearts 1 back
    //Based on the streak AND The amount of coins the player betted will determine their prize
    int BetCalculation(int coins, int player, string streak){
            if (streak == "lollipop")
                {
                    if (coins == 3)
                    {
                        coins = coins * 3;
                    }
                    else {
                        coins = coins + 1;
                    }
                    
                }
                if (streak == "candy")
                {
                    if (coins == 3)
                    {
                        coins = coins * 3;
                    }
                    else {
                        coins = coins + 1;
                    }
                
                }
                if (streak == "marsh")
                {
                    if (coins > 1) {
                        coins = coins * 2;
                    }
                    else {
                        coins = coins + 1;
                    }
                    
                
                }
                if (streak == "cotton")
                {
                    if (coins > 1) {
                        coins = coins * 2;
                    }

                    
                }
                if (streak == "gumdrop")
                {
                    if (coins > 0) {
                        coins = coins + 1 ;
                    }
                }
                if (streak == "chocolate")
                {
                    if (coins > 0) {
                    coins = coins + 1 ;
                    }
                }

            
        return player+coins;
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
            timeRemaining = 3.5f; //How long we want to win
            if (badSlot == false){
                winScript.GetComponent<win>().TimeUp = false;
                winScript.GetComponent<win>().text.transform.position = winScript.GetComponent<win>().textpos;
            }
           
                for(int i = 0; i < 3; i++) //go through all our slots and spin them all
            {
            //[1,2,3] 
            rows[i].transform.position = new Vector3(rows[i].transform.position.x, 1.31f, rows[i].transform.position.z);
            button.GetComponent<Button>().interactable = true;
         }
        }
        }
    }

    }



    