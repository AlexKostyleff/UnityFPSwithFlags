using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagClass : MonoBehaviour
{
    [SerializeField] GameObject Coath;
    [SerializeReference] Material FlagMat;
    public float FlagScore=0;
    public string name;
    public enum Comand
    {
        Red = 1,
        Blue = 2,
        Neutral = 0
    }
    public Comand nowcontrol = Comand.Neutral;

    void ColorChange()
    {
       // if(nowcontrol == Comand.Blue) FlagMat =  
    }


}
