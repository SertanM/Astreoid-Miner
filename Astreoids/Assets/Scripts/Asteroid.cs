using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject Exp;
    public int asteroidHearth = -1;
    public Sprite[] sprites;
    public float size = 1f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50f;
    private float maxLifeTime = 30f;
    private SpriteRenderer _mySR;
    private Rigidbody2D _myRG;
    private Color[] colors = { Color.yellow, Color.blue, Color.green, Color.cyan, Color.green, Color.magenta, Color.red, Color.white };

    
    void Awake()
    {
        _myRG = GetComponent<Rigidbody2D>();
        _mySR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _mySR.sprite = sprites[Random.Range(0, sprites.Length)];
        _mySR.color = colors[Random.Range(0, colors.Length)];
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        this.transform.localScale = Vector3.one * size;
        if(asteroidHearth==-1)asteroidHearth=Random.Range(1, 3);
        Debug.Log(asteroidHearth);
        _myRG.mass = size;
    }

    public void SetForce(Vector2 direction)
    {
        _myRG.AddForce(direction * speed);

        Destroy(this.gameObject, maxLifeTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Bullet")
        {
            asteroidHearth--;
            if(asteroidHearth<=0){
                if(coll.gameObject.name != "pivot") Destroy(coll.gameObject);
                if(size * 0.5f > minSize)
                {
                    CreateSplit();
                    CreateSplit();
                }
                else
                {
                    CreateExp();
                }
                FindObjectOfType<GameManager>().AsteroidExplosion(this);
                
            }
            Destroy(this.gameObject);
            
        }
    }

    void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, transform.rotation);
        half.size = size * 0.5f;
        half.asteroidHearth = asteroidHearth/2;
        half.SetForce(Random.insideUnitCircle.normalized);
    }

    void CreateExp()
    {
        for (int i = 0; i < size*10; i++)
        {
            Vector2 position = this.transform.position;
            position += Random.insideUnitCircle * 0.5f;
            Instantiate(Exp,position, Quaternion.identity);
        }
    }
}
