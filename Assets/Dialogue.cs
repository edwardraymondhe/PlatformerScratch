using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    // Basically has all the information we need, as down below: NAME, DETAIL MESSAGES FOR THE DIALOGUE

    public string name;

    [TextArea(3,10)]
    public string[] sentences;

    
}
