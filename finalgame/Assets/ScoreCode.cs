using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class ScoreCode : MonoBehaviour

{

    //だ计把计

    public static float Score = 0;
    

    //ゅUI

    public Text ShowScore;
    
    void Start()
    {

        DontDestroyOnLoad(this.gameObject);
       
    }
    void Update()
    {

        //琵UIゅ籔だ计˙

        ShowScore.text = Score.ToString();
        

    }

}