using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Random=UnityEngine.Random;
using UnityEngine.Rendering;
using Unity.VisualScripting;


public class LevelManager : MonoBehaviour
{
    

    [Header("My Card Desk")]
    [SerializeField] private int maxCardDesk = 6;
    private int myCardDesk = 0;
    [Header("MY MAIN CARDS")]
    public List<GameObject> myCards;


    [Header("Hp Up Card")]
    public GameObject HpUpCard;


    [Header("S CARD")]
    public GameObject SCard;
    public GameObject SButton;


    [Header("Solar Panel Cards")]
    public GameObject myPivotCard0;
    public GameObject myPivotCard1;
    public List<GameObject> myPivotCardSet;


    [Header("Plus Shoot Cards")]
    public GameObject frontShootCard;
    public GameObject backShootCard;
    public GameObject verticalShootCard;

    private GameObject card0;
    private GameObject card1;
    private GameObject card2;
    private Button button;

    [Header("Ui Buttons")]
    [SerializeField] private GameObject mineUiButtons;

    void OnEnable(){
        
        Time.timeScale = 0;
        mineUiButtons.SetActive(false);
        
        card0 = Instantiate(myCards[Random.Range(0, myCards.Count)], transform.position, transform.rotation, transform) as GameObject;
        button = card0.GetComponent<Button>();
        addOnclick(card0.name, button);

        card1 = Instantiate(myCards[Random.Range(0, myCards.Count)], transform.position, transform.rotation, transform) as GameObject;
        card1.GetComponent<RectTransform>().localPosition = new Vector3(-250, 0 , 0);
        button = card1.GetComponent<Button>();
        addOnclick(card1.name, button);
        
        card2 = Instantiate(myCards[Random.Range(0, myCards.Count)], transform.position, transform.rotation, transform) as GameObject;
        card2.GetComponent<RectTransform>().localPosition = new Vector3(250, 0 , 0);
        button = card2.GetComponent<Button>();
        addOnclick(card2.name, button);
        
    }

    void addOnclick(string cardName, Button myButton){
        switch(cardName){
            case "ThrustSpeedUp(Clone)":
                myButton.onClick.AddListener(() => thrustSpeed());
                break;
            case "ShootSpeedUp(Clone)":
                myButton.onClick.AddListener(() => shootSpeed());
                break;
            case "RotateSpeedUp(Clone)":
                myButton.onClick.AddListener(() => rotateSpeed());
                break;
            case "SolarPanel(Clone)":
                myButton.onClick.AddListener(() => openPivot0());
                break;
            case "SolarPanel0(Clone)":
                myButton.onClick.AddListener(() => openPivot1());
                break;
            case "SolarDistanceDown(Clone)":
                myButton.onClick.AddListener(() => pivotDistanceDown());
                break;
            case "SolarSpeedUp(Clone)":
                myButton.onClick.AddListener(() => pivotSpeedUp());
                break;
            case "HpUp(Clone)":
                myButton.onClick.AddListener(() => HpUp());
                break;
            case "AddS(Clone)":
                myButton.onClick.AddListener(() => addS());
                break;
            case "AddFrontShoot(Clone)":
                myButton.onClick.AddListener(() => AddFrontShoot());
                break;
            case "AddBackShoot(Clone)":
                myButton.onClick.AddListener(() => AddBackShoot());
                break;
            case "AddVerticalShoot(Clone)":
                myButton.onClick.AddListener(() => AddVerticalShoot());
                break;
            default:
                Debug.LogError(cardName);
                break;

        }
    }

    

    /// <summary>
    /// MAIN CARDS
    /// </summary>
    public void thrustSpeed(){
        FindObjectOfType<Player>().thrustSpeedUp();
        closeManager();
    }

    public void shootSpeed(){
        FindObjectOfType<WeponManager>().shootSpeedUp();
        closeManager();
    }

    public void rotateSpeed(){
        FindObjectOfType<Player>().rotateSpeedUp();
        closeManager();
    }

    public void HpUp(){
        FindObjectOfType<GameManager>().AddHp();
        closeManager();
    }

    /// <summary>
    /// SOLOR PLANE CARDS
    /// </summary>
    public void pivotDistanceDown(){
        FindObjectOfType<pivotbullet>().DistanceDown();
        closeManager();
    }
    public void pivotSpeedUp(){
        FindObjectOfType<pivotbullet>().SpeedUp();
        closeManager();
    }

    public void openPivot0(){
        myCards.Remove(myPivotCard0);
        if(true) myCards.Add(myPivotCard1);
        if(true) myCards.AddRange(myPivotCardSet);
        FindObjectOfType<pivotbullet>().OpenPivot0();

        isMyDeskFull();
        closeManager();
    }

    public void openPivot1(){
        myCards.Remove(myPivotCard1);
        FindObjectOfType<pivotbullet>().OpenPivot1();

        isMyDeskFull();
        closeManager();
    }

    /// <summary>
    /// ADD S CARD
    /// </summary>
    
    public void addS(){
        myCards.Remove(SCard);
        SButton.SetActive(true);
        FindObjectOfType<Player>().addS();

        isMyDeskFull();
        closeManager();
    }

    /// <summary>
    /// Add Shoot Card
    /// </summary>

    public void AddFrontShoot(){
        myCards.Remove(frontShootCard);
        if(true) myCards.Add(backShootCard);
        FindObjectOfType<WeponManager>().AddShoot("Front");

        isMyDeskFull();
        closeManager();
    }

    public void AddBackShoot(){
        myCards.Remove(backShootCard);
        if(true) myCards.Add(verticalShootCard);
        FindObjectOfType<WeponManager>().AddShoot("Back");

        isMyDeskFull();
        closeManager();
    }
    public void AddVerticalShoot(){
        myCards.Remove(verticalShootCard);
        // if(true) myCards.Add(backShootCard);
        FindObjectOfType<WeponManager>().AddShoot("Vertical");

        isMyDeskFull();
        closeManager();
    }

    /// <summary>
    /// Close Cards
    /// </summary>

    private void isMyDeskFull(){
        myCardDesk++;
        if(myCardDesk>=maxCardDesk){
            myCards.Remove(frontShootCard);
            myCards.Remove(backShootCard);
            myCards.Remove(verticalShootCard);
            myCards.Remove(myPivotCard0);
            myCards.Remove(myPivotCard1);
            myCards.Remove(SCard);
        }
    }

    public void Close(){
        Destroy(card0);
        Destroy(card1);
        Destroy(card2);
        mineUiButtons.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void closeManager(){
        FindObjectOfType<LevelManager>().Close();
        Time.timeScale = 1;
    }
}
