using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class generaterow : MonoBehaviour
{
    
    public bool HandlePulled = false;

    //Global Variable
    public GameObject[] rows;
    public GameObject generate;
    public AudioSource source;
    public AudioClip handlePull;
    public AudioClip winningSound;
    public AudioClip spinners;
    public float timeRemaining = 3.5f;


    public GameObject winScript;
    public GameObject textinput;
    private int cointotal;
    public InputField inputter;

    public GameObject coinText;
    public int PlayerCoin = 10;

    public bool winTime = false;
   
    private String[] icons = new String[]{"chocolate", "gumdrop", "cotton", "marsh", "candy", "lollipop"};

    public GameObject button;   

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
      
        string textcoin = inputter.text;
        button.GetComponent<Button>().interactable = false;
        if (PlayerCoin == 0){
            StartCoroutine(loss());
        }

        if (textcoin == "1")
        {
            print("going into 1");
            cointotal = 1;
           
        }
        if (textcoin == "2")
        {
            print("going into 2");
            cointotal = 2;
            
        }
        if (textcoin == "3")
        {
            print("going into 3");
            cointotal=3;
            
        }
        

        if (PlayerCoin - cointotal < 0) {
            StartCoroutine(notEnough());
            
        }
        else {
            PlayerCoin = PlayerCoin - cointotal; 
            coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";
            StartCoroutine(RunGameWait());
        }
     
        
        
   
    }

    IEnumerator loss(){
        coinText.GetComponent<TextMeshProUGUI>().text = "No Coins, Restarting!";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator notEnough(){
        coinText.GetComponent<TextMeshProUGUI>().text = "Not enough";
        yield return new WaitForSeconds(3f);
        button.GetComponent<Button>().interactable = true;
        coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";
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
            print("Matching");
            winner = true;
        }
        

        foreach (int i in ans){
            print(icons[i]);
        }
     

        source.PlayOneShot(spinners);
        foreach(GameObject i in rows) //go through all our slots and spin them all
        {
            i.GetComponent<row1>().startRotating(ans[count]); //ROTATE() using the sequence we made
            count++; 
        }


        yield return new WaitForSeconds(4f);
        
        print("Past Waiting");
        if (winner == true)
        {
            winTime = true;
            source.PlayOneShot(winningSound);
            PlayerCoin = BetCalculation(cointotal, PlayerCoin, icons[ans[0]]);
            coinText.GetComponent<TextMeshProUGUI>().text = PlayerCoin.ToString() + " Coins";
            winScript.GetComponent<win>().flashLights();
            winScript.GetComponent<win>().panText();
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
                else {
                    coins = coins + 1;
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
            winScript.GetComponent<win>().TimeUp = false;
            winScript.GetComponent<win>().text.transform.position = winScript.GetComponent<win>().textpos;
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



    