using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMessage : MonoBehaviour
{
    public string[] dialogMessage;
    public Text messageBox;
    public DialogBoxController dc;

     bool wait = true;
     float pause = 0;
     float pauseTime = 3;
    void Awake()
    {
        
    }
    //just for testing=
    void Update()
    {
        if (wait == true && pause < pauseTime)
        {
            pause += 1 * Time.deltaTime;
            SendMsg(0);
        }
        else
        {
            dc.Fade();
            wait = true;
            pause = 0;
        }
        
    }
    //
    public void SendMsg(int id)
    {
        messageBox.text = dialogMessage[id];
    }


}
