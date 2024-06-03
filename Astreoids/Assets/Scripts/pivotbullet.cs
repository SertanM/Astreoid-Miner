using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivotbullet : MonoBehaviour
{
    public float speed = 100f;
    [SerializeField] private Transform target;

    [SerializeField] private Transform myBullet;
    [SerializeField] private Transform myBullet2;

    void Update()
    {
        this.gameObject.transform.position = target.position;
        this.gameObject.transform.Rotate(0, 0, speed * Time.deltaTime);
    }


    public void DistanceDown(){
        float discount = myBullet.position.x / 4f;
        if( discount>0){
            discount*=-1;
        }
        myBullet.position = new Vector3(myBullet.position.x- discount,myBullet.position.y,myBullet.position.z);
        myBullet2.position = new Vector3(myBullet2.position.x- discount,myBullet2.position.y,myBullet2.position.z);
    }

    public void SpeedUp(){
        speed += speed / 4f;
    }

    public void OpenPivot0(){
        myBullet.gameObject.SetActive(true);
    }
    public void OpenPivot1(){
        myBullet2.gameObject.SetActive(true);
    }
    
}
