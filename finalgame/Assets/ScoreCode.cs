using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class ScoreCode : MonoBehaviour

{

    //�ŧi���ưѼ�

    public static float Score = 0;
    

    //�ŧi��rUI

    public Text ShowScore;
    
    void Start()
    {

        DontDestroyOnLoad(this.gameObject);
       
    }
    void Update()
    {

        //��UI��r�P���ƦP�B

        ShowScore.text = Score.ToString();
        

    }

}