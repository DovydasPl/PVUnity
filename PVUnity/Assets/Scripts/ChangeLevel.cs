using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public int levelID = 0;
    public AudioSource audio;
    float delay = 0f;
    bool doorUnlocked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorUnlocked == true)
        {
            delay += 1 * Time.deltaTime;
        }
     
        if (delay > 1)
        {
            PlayerPrefs.SetInt("lastlevel", levelID);
            Debug.Log(levelID);
            Application.LoadLevel(levelID);
            

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<Inventory>().keyCard)
        {
            audio.Play();
            doorUnlocked = true;
            PlayerPrefs.SetInt("lastlevel", levelID);
        }
    }
}
