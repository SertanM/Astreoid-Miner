using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponManager : MonoBehaviour
{
    public Bullet bulletPrefab;
    public GameObject Player;
    private float shootSpeed = 1f;
    private int bullNum = 1;

    void Start()
    {
        Invoke(nameof(Shoot), shootSpeed);
    }

    public void shootSpeedUp(){
        shootSpeed-=shootSpeed/8;
    }

    public void AddShoot(string shootName){
        switch(shootName){
            case "Front":
                bullNum = 1;
                break;
            case "Back":
                bullNum=2;
                break;
            case "Vertical":
                bullNum=4;
                break;
            default:
                Debug.LogError("WTF BROTHER!!");
                break;
        }
    }

    private void Shoot()
    {
        for(int i = 0; i<bullNum; i++){
            Bullet bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            switch(i){
                case 0:
                    bullet.Project(this.transform.up);
                    break;
                case 1:
                    bullet.Project(-this.transform.up);
                    break;
                case 2:
                    bullet.Project(this.transform.right);
                    break;
                case 3:
                    bullet.Project(-this.transform.right);
                    break;
                default:
                    Debug.LogError("WTF BROTHER");
                    break;
            }
        }
        
        Invoke(nameof(Shoot), shootSpeed);
    }

    
}
