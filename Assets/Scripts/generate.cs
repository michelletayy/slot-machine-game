using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate : MonoBehaviour
{

  
    
    // Will determine whether to generate a 
    // mixed sequence or a matching sequence

    //Mixed - 70%
    //Matching - 30%
    public int[] generateSeq()
    {
         int[] ans = new int[3]; //List, array: [0,0,0]
        int x = 5;
        x = (Random.Range(1,10));
        if (x <= 7){
            ans = mixed();
        } else {ans = matching();}
        return ans; 
    }

    //Will output a mixed sequence
    //It ensures all the characters are 
    //different 

    int[] mixed(){
        int x = (Random.Range(0,5));
        //makes sure the first doesn't
        //match the second by constantly 
        //rerolling it
        int y = (Random.Range(0,5));
        while(x==y){
            y = Random.Range(0,5);
        }
        //checks for the third number,
        //rerolls until it doesn't match
        //either of the past two numbers
        int z = (Random.Range(0,5));
        while(y==z && z==x){
            z = Random.Range(0,5);
        }
        int[] g = new int[]{x,y,z};
        return g;

    }

    //Outputs a matching sequence
    //determines the prize ranges
     //5% Lolipop
      //10% Candy
       //15 Marsh
       //20 Cotton
        //20 Gumdrop
          //40 Hearts
    int[] matching(){
        //generates a random number from 
        //0 - 100
        int x = (Random.Range(0,100));
        int[] ans = new int[3];
        //5% Lolipop
        if (x<5){
             ans[0] = 5;
             ans[1] = 5;
             ans[2] = 5;
            return ans;

        }
        //10% Candy
        if (x>=5 && x<15){
             ans[0] = 4;
             ans[1] = 4;
             ans[2] = 4;
            return ans;
        }
        //15 Marsh
        if (x>=15 && x<30){
            print("Marshmallows");
             ans[0] = 3;
             ans[1] = 3;
             ans[2] = 3;
            return ans;
        }
        //20 Cotton
         if (x>=30 && x<50){
            print("Cotton Candy");
             ans[0] = 2;
             ans[1] = 2;
             ans[2] = 2;
            return ans;
        }
        //20 Gumdrop
         if (x>=50 && x<70){
            print("Gumdrops");
             ans[0] = 1;
             ans[1] = 1;
             ans[2] = 1;
            return ans;
        }
        //40 Hearts
         if (x>= 70){
            print("Chocolate Hearts");
             ans[0] = 0;
             ans[1] = 0;
             ans[2] = 0;
            return ans;
        }
    return null;
    }

}
