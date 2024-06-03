using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500f;
    private float maxLifeTime = 3f;
    private Rigidbody2D _myRG;
    [SerializeField] Transform player; 

    private void Awake()
    {
        _myRG = this.transform.GetComponent<Rigidbody2D>();
        
    }

    
    /*
    //Bu �zellik olarak eklenebilir
    void Update()
    {
        float newposx = 0f;
        float newposy = 0f;
        if (gameObject.transform.position.x >= 8.5) newposx = -8.4f;
        else if (gameObject.transform.position.x <= -8.5) newposx = 8.4f;
        if (gameObject.transform.position.y >= 5.5) newposy = -5.4f;
        else if (gameObject.transform.position.y <= -5.5) newposy = 5.4f;
        this.gameObject.transform.position = new Vector3(newposx != 0f ? newposx : this.gameObject.transform.position.x, newposy != 0f ? newposy : this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
    */
    public void Project(Vector2 direction)
    {
        _myRG.AddForce(direction.normalized * speed);
        Destroy(this.gameObject, maxLifeTime);
    }
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.gameObject);
    }
}
