using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy2D : MonoBehaviour
{
    public bool hit=false;
   
    void OnTriggerEnter2D(Collider2D coll)
    {
        

            if (coll.CompareTag("PJ"))
            {
                Debug.Log("daño");
            hit = true;
                // transform.parent.GetComponent<Enemy2D>().atacando= false;
            }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PJ"))
            {
            Debug.Log("salio");
            hit = false; 
        }
       
    }
}
