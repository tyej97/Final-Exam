using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoadUpScript : MonoBehaviour
{

    public Text speedBox;
    public Text sizeBox;
    void Start()
    {
        if(GameManagerScript.giantMode == true)
        {
            sizeBox.text = "GIANT!";
        }
        else
        {
            sizeBox.text = "Normal";
        }
        speedBox.text = GameManagerScript.speed.ToString();

    }

}
