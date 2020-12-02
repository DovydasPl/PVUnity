using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
 public void onPlayClick()
    {
        Application.LoadLevel(1);
    }
    public void onContinueClick()
    {
        int level = PlayerPrefs.GetInt("lastLevel",0);
        Application.LoadLevel(level);
    }
    public void onOptionsClick()
    {
        
    }
    public void onExitClick()
    {
        Application.Quit();
    }
}
