using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public float Timer;
    public TextMeshProUGUI timeText;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        Timer = PlayerPrefs.GetFloat("timer");
        InvokeRepeating("SaveNumber", 1f, 5.0f);
        timerIsRunning = true;
       
    }

    void SaveNumber()
    {
        PlayerPrefs.SetFloat("timer", Timer);
    }

    

    void Update()
    {
        if (timerIsRunning)
        {
            Timer += Time.deltaTime;
            float timeToDisplay = Timer;
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            
        }
    }
    public void DisplayTime()
    {
        
        timeText.gameObject.SetActive(flag);
        flag = !flag;
        
    }
}