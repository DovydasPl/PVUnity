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
       
        
    }
    //
    public void SendMsg(int id)
    {
      //  dc.Fade();
        messageBox.text = dialogMessage[id];
        ///kazkiek laiko
        //dc.Fade();
    }


}
