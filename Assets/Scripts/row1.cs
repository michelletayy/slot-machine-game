using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class row1 : MonoBehaviour
{
    float x = 0.00025f;
    public int counter;
    public bool start = false;
    private int ans = 10;
    public int rowNum;
    private int numRotations;
    private AudioSource source;
    public AudioClip bling;
    
    // Start is called before the first frame update
    // public int stop = 0;
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>() as AudioSource;
    }

    public void startRotating(int num)
    {
        //go will be True when we start Rotating
        start = true;
        numRotations = 0;
        //num will be the number we need to stop at
        ans = num;
    }

    public void rotate(){
        Vector3 desiredPosition = transform.position + new Vector3(0, -0.20f, 0);
        transform.position = Vector3.Lerp(transform.position,desiredPosition,25*Time.deltaTime);
        if(transform.position.y <= -2.80){
            numRotations++;
            transform.position = new Vector2(transform.position.x, 1.31f);

        }
    }

    void checkLast(){
        if (rowNum == 3) {
            //GameObject.Find("generaterow").GetComponent<generaterow>().source.Stop();
        }
    }

    public void rotate(int stop)
    {
        // for (int i = 0 ; i < (350 * counter) ; i++ ){
            //  if (transform.position.y >= -0.08f && transform.position.y <= -0.48f ){
            //     print("hello");
            //     break; //cotton candy break
            //  }
            
            float current = Mathf.Round(transform.position.y * 100f) / 100f;

                      //current == 1.31f
             
            if (current <= -1.27f && current >= -1.41f && stop == 0){
                
                transform.position = new Vector3(transform.position.x, 1.31f, transform.position.z);
                // break; //choclate break
                start = false;
                //source.PlayOneShot(bling);
                checkLast();
            }
            // current == 0.56f
            
            if (current >= 0.40f && current <= 0.70f && stop == 1){
                transform.position = new Vector3(transform.position.x, 0.56f, transform.position.z);
                start = false;
                //source.PlayOneShot(bling);
                checkLast();
                // break; //gumdrop  break
            }
            
            // current == -0.19f
            if (current <= -0.14f && current >= -0.29f && stop == 2){
                
                transform.position = new Vector3(transform.position.x, -0.19f, transform.position.z);
                // break; //cotton candy  break
                start = false;
                //source.PlayOneShot(bling);
                checkLast();

            }

            // current == -0.99f
            
            if (current <= -0.93f && current >= -1.03 && stop == 3 ){
                
                transform.position = new Vector3(transform.position.x, -0.99f, transform.position.z);
                start = false;
                //source.PlayOneShot(bling);
                checkLast();

                // break; //marsh  break
            }

            //current == -1.74f
            if (current <= -1.70f && current >= -1.85f && stop == 4){
                
                transform.position = new Vector3(transform.position.x, -1.74f, transform.position.z);
                start = false;
                //source.PlayOneShot(bling);
                checkLast();

                // break; //candy  break
            }

            //current == -2.54f
            if (current <= -2.50f && current >= -2.69f && stop == 5){
                
                transform.position = new Vector3(transform.position.x, -2.54f, transform.position.z);
                start = false;
                //source.PlayOneShot(bling);
                checkLast();

                // break; //lollipop  break
            }

            //print(current);
            // print(transform.position.y);
            if(transform.position.y <= -2.80){
                
                
                transform.position = new Vector2(transform.position.x, 1.31f);
   
            }
            
            // transform.position = new Vector2(transform.position.x,transform.position.y - .05f) * Time.deltaTime;
            Vector3 desiredPosition = transform.position + new Vector3(0, -0.20f, 0);
            transform.position = Vector3.Lerp(transform.position,desiredPosition,25*Time.deltaTime);
            // transform.Translate(Vector3.down * 1 * Time.deltaTime, Space.Self);
        // }
    }


    // Update is called once per frame
    void Update()
    {
        
        // transform.position = new Vector2(transform.position.x,transform.position.y - .05f) * Time.deltaTime;
        if (start == true){
            // print(start);
            if (numRotations < rowNum) {
                rotate();
            }
            else {
                rotate(ans);
            }
            
        }
        
    }
}
