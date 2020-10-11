using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    float yCenter;
    float height = 3f;
    // Start is called before the first frame update
    void Start()
    {
        yCenter = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, yCenter + Mathf.Sin(Time.time) / height, transform.position.z);//move on y axis only
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("gay");

        if (col.gameObject.tag == "Player")
        {
          col.GetComponent<Inventory>().keyCard = true;
            Destroy(this.gameObject);
        }
    }
}
