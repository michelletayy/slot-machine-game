using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void badSlot() {
        SceneManager.LoadScene("badSlot");
    }
    public void goodSlot() {
        SceneManager.LoadScene("goodSlot");
    }
    public void noSoundSlot() {
        SceneManager.LoadScene("NoSound");
    }
}
