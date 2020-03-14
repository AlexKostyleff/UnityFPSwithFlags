using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    [Header("Flags")]
   public FlagClass[] flags;
    public FlagClass Flag;
    // add Canvas stroke with Flag`s scores aka: A: 99 ;

    // Update is called once per frame
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 300, 25), "Flag " + Flag.name + ": " +Flag.FlagScore);
    }
}
