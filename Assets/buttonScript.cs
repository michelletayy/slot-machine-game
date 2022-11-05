using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public GameObject cards;
    void OnMouseDown() {
        cards.GetComponent<genrowbad>().RunGame();
    }
}
