using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Player")  
        {
            FindObjectOfType<GameManager>().AddExp();
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "Player")
        {
            Rigidbody2D myRG = this.gameObject.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = (col.transform.position - transform.position).normalized;
            myRG.AddForce(forceDirection * 0.02f);
        }
    }
}
