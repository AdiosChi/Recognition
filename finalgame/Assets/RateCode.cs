using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class RateCode : MonoBehaviour

{

    //�ŧi���ưѼ�

    public static float shot = 0;
    public static float rate = 0;

    //�ŧi��rUI

    public Text ShowRate;

    void Start()
    {

        DontDestroyOnLoad(this.gameObject);

    }
    void Update()
    {

        //��UI��r�P���ƦP�B
        rate = (ScoreCode.Score / shot) * 100;
        ShowRate.text = rate.ToString("0.");
 


    }

}