using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemy : MonoBehaviour
{
  public bool visto=false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("PJ"))
        {
            Debug.Log("visto");
            visto = true;
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }

     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PJ"))
        {
            Debug.Log("dejo se ser visto");
            visto = false;
        }
    }


}
