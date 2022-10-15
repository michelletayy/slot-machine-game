using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class win : MonoBehaviour
{
    private AudioSource source;

    public GameObject[] lights;
    public GameObject text;
    public float waitTillNext = 0.5f;
    public GameObject congrats;
    public GameObject rowSpinnerScript;
    public bool TimeUp = false;
    public  Vector3 textpos; 
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        textpos =  text.transform.position;

    }

    public void flashLights() {
        print("I am in flashing lights");
                // source.PlayOneShot(win1);
        StartCoroutine(waitanddFlash());
    }

    IEnumerator waitanddFlash() {
        foreach(GameObject light in lights) {
            print(rowSpinnerScript.GetComponent<generaterow>().timeRemaining);
            if (rowSpinnerScript.GetComponent<generaterow>().timeRemaining <= 0)
            {
                print("HELLOOOOO");
                print(rowSpinnerScript.GetComponent<generaterow>().timeRemaining);
                TimeUp = true;
                break;
            }
            light.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(waitTillNext);
            light.GetComponent<SpriteRenderer>().color = Color.gray;
            yield return new WaitForSeconds(waitTillNext);
        }
        if(TimeUp == false){
            Array.Reverse(lights);
        StartCoroutine(waitanddFlash());
        } 
        
    }

    public void panText() {
        StartCoroutine(waitandPan());
    }

    IEnumerator waitandPan() {
        for (int i = 0; i < 350; i++) {
            if (rowSpinnerScript.GetComponent<generaterow>().timeRemaining <= 0)
            {
                yield break;
            }
            if(text.transform.position.x <= 1.80){
                text.transform.position = new Vector2(11.53f, text.transform.position.y);
   
            }
            
            text.transform.position = new Vector2(text.transform.position.x - 0.5f, text.transform.position.y);
            yield return new WaitForSeconds(0.1f);
        }
        text.transform.position = textpos;
        yield return new WaitForSeconds(1);
    }

    public void flashCongrats() {
        StartCoroutine(flashCongratsWait());
    }
    IEnumerator flashCongratsWait() {

        for (int i = 0; i < 350; i++) {
            print("hello");
            congrats.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            congrats.SetActive(false);
             print("feafea");
        }
        yield return new WaitForSeconds(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
