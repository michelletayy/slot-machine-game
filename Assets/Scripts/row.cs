using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class row : MonoBehaviour
{
    float x = 0.00025f;
    // Start is called before the first frame update
    // public int stop = 0;
    void Start()
    {
    }

    public void startRotating(int stop)
    {
        StartCoroutine(rotate(10));
        StartCoroutine(rotate(stop));

    }

    IEnumerator rotate(int stop)
    {
        for (int i = 0 ; i < 350 ; i++ ){
            //  if (transform.position.y >= -0.08f && transform.position.y <= -0.48f ){
            //     print("hello");
            //     break; //cotton candy break
            //  }
            float current = Mathf.Round(transform.position.y * 100f) / 100f;
            if (current == -0.99f && stop == 3 ){
                print("marsh");
                transform.position = new Vector3(transform.position.x, -0.99f, transform.position.z);

                break; //marsh  break
            }
            if (current == 0.56f && stop == 1){
                print("gumdrop");
                transform.position = new Vector3(transform.position.x, 0.56f, transform.position.z);
                break; //gumdrop  break
            }
            
            
            if (current == -0.19f && stop == 2){
                print("cotton candy");
                transform.position = new Vector3(transform.position.x, -0.19f, transform.position.z);
                break; //cotton candy  break
            }

             
            if (current == 1.31f && stop == 0){
                print("chocolate");
                transform.position = new Vector3(transform.position.x, 1.31f, transform.position.z);
                break; //choclate break
            }

             
            if (current == -1.74f && stop == 4){
                print("candy");
                transform.position = new Vector3(transform.position.x, -1.74f, transform.position.z);
                break; //candy  break
            }

             
            if (current == -2.54f && stop == 5){
                print("lollipop");
                transform.position = new Vector3(transform.position.x, -2.54f, transform.position.z);
                break; //lollipop  break
            }

            //print(current);
            if(transform.position.y <= -2.80){
            transform.position = new Vector2(transform.position.x, 1.31f);
   
            }
            
            transform.position = new Vector2(transform.position.x,transform.position.y - .05f);
            yield return new WaitForSeconds(x);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
