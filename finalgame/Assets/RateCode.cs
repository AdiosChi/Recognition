using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class RateCode : MonoBehaviour

{

    //宣告分數參數

    public static float shot = 0;
    public static float rate = 0;

    //宣告文字UI

    public Text ShowRate;

    void Start()
    {

        DontDestroyOnLoad(this.gameObject);

    }
    void Update()
    {

        //讓UI文字與分數同步
        rate = (ScoreCode.Score / shot) * 100;
        ShowRate.text = rate.ToString("0.");
 


    }

}