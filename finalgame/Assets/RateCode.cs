using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class RateCode : MonoBehaviour

{

    //だ计把计

    public static float shot = 0;
    public static float rate = 0;

    //ゅUI

    public Text ShowRate;

    void Start()
    {

        DontDestroyOnLoad(this.gameObject);

    }
    void Update()
    {

        //琵UIゅ籔だ计˙
        rate = (ScoreCode.Score / shot) * 100;
        ShowRate.text = rate.ToString("0.");
 


    }

}