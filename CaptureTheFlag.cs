using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureTheFlag : MonoBehaviour
{
    // [SerializeField]  FlagClass thisFlag;
    public float ScoreSpeed =0 ;
    public float ScoreAccel = 20;
    public bool Decrease = false;
    [SerializeField] int BlueCount = 0, RedCount = 0;
    void Capture(FlagClass.Comand cmd)
    {
       
            if (cmd == FlagClass.Comand.Red)
            {
                ScoreSpeed = ScoreAccel;
                Decrease = false;
            }
            if (cmd == FlagClass.Comand.Blue)
            {
                ScoreSpeed = -ScoreAccel;
                Decrease = false;
            }
            if (cmd == FlagClass.Comand.Neutral )
            {
                Decrease = true;
                ScoreSpeed = 0;
            }
        
     }
    private void OnTriggerEnter(Collider other)
   {

        if(other.tag == "Blue")
        {
            BlueCount += 1;
           
        }
        if (other.tag == "Red")
        {
            RedCount += 1; 
           
        }
       if(BlueCount>RedCount) Capture(FlagClass.Comand.Blue);
       if(RedCount>BlueCount) Capture(FlagClass.Comand.Red);
       // if (RedCount == BlueCount) Capture(FlagClass.Comand.Neutral);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Red")
        {
            RedCount -= 1;
        }

        if (other.tag == "Blue")
        {
            BlueCount -= 1;
        }
        if (gameObject.GetComponent<FlagClass>().FlagScore < 100 && gameObject.GetComponent<FlagClass>().FlagScore > -100) Capture(FlagClass.Comand.Neutral);
    }
    void Update()
    {
        if (gameObject.GetComponent<FlagClass>().FlagScore >= 100)
        {
            gameObject.GetComponent<FlagClass>().FlagScore = 100;
            gameObject.GetComponent<FlagClass>().nowcontrol = FlagClass.Comand.Red;
        }
        if (gameObject.GetComponent<FlagClass>().FlagScore <= -100)
        {
            gameObject.GetComponent<FlagClass>().FlagScore = -100;
            gameObject.GetComponent<FlagClass>().nowcontrol = FlagClass.Comand.Blue;
        }

        if (ScoreSpeed == 0) gameObject.GetComponent<FlagClass>().nowcontrol = FlagClass.Comand.Neutral;

        if (ScoreSpeed >0 && gameObject.GetComponent<FlagClass>().FlagScore <100)
        {
            gameObject.GetComponent<FlagClass>().FlagScore += ScoreSpeed * Time.deltaTime;
        }
        if (ScoreSpeed <0 && gameObject.GetComponent<FlagClass>().FlagScore > -100)
        {
            gameObject.GetComponent<FlagClass>().FlagScore += ScoreSpeed * Time.deltaTime;
        }
        if (Decrease == true && gameObject.GetComponent<FlagClass>().FlagScore !=0)
        {
           if (gameObject.GetComponent<FlagClass>().FlagScore>0) gameObject.GetComponent<FlagClass>().FlagScore -= ScoreAccel * Time.deltaTime;
            if (gameObject.GetComponent<FlagClass>().FlagScore < 0) gameObject.GetComponent<FlagClass>().FlagScore += ScoreAccel * Time.deltaTime;
            if(gameObject.GetComponent<FlagClass>().FlagScore >0 && gameObject.GetComponent<FlagClass>().FlagScore<=1)
            {
                gameObject.GetComponent<FlagClass>().FlagScore = 0;
                gameObject.GetComponent<FlagClass>().nowcontrol = FlagClass.Comand.Neutral;
                Decrease = false;
            }
        }

    }

}
