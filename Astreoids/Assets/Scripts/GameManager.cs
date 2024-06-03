using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject levelUpScreen;
    public Player player;
    public ParticleSystem explosion;
    public Text myText;
    public GameObject gameOverScreen;
    public Image levelBar;
    public Text levelText;
    [HideInInspector] public int maxLive = 3;
    [HideInInspector] public int lives = 3;
    public int totalScore;
    private bool damaged;
    private bool second;
    private float exp = 0;
    private float nextLevelExp = 50;
    private int myLevel = 1;

    public void AsteroidExplosion(Asteroid asteroid)
    {
        explosion.transform.position = asteroid.transform.position;
        explosion.Play();
    }
    public void PlayerDied()
    {
        explosion.transform.position = player.transform.position;
        explosion.Play();
        lives--;
        myText.text = lives.ToString();
        player.isDeath = true;
        if (lives <= 0) GameOver();
        else Respawn();
    }

    private void Respawn()
    {
        player.isDeath = false;
        player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        damaged = true;
        InvokeRepeating(nameof(Damage), 0.1f, 0.1f);
        Invoke(nameof(TurnOnCollisions), 3f);
    }

    private void TurnOnCollisions()
    {
        damaged = false;
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    private void Damage()
    {
        if(damaged)
        {
            if (second) player.mySR.color = Color.black;
            else player.mySR.color = Color.white;

            second = !second;
        }
        else
        {
            player.mySR.color = Color.white;
            CancelInvoke(nameof(Damage));
        }
        
    }

    private void GameOver()
    {
        player.gameObject.SetActive(false);
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void AddExp()
    {
        totalScore+=100;
        exp++;
        levelBar.fillAmount = exp/nextLevelExp;
        if (exp >= nextLevelExp)
        {
            LevelUp();
        }
    } 
    private void LevelUp()
    {
        totalScore+=500;
        exp = 0;
        myLevel++;
        levelText.text = "LVL " + myLevel; 
        nextLevelExp += nextLevelExp*0.25f;
        levelUpScreen.SetActive(true);
        levelBar.fillAmount = exp/nextLevelExp;
    }

    public void AddHp(){
        lives++;
        myText.text = lives.ToString();
    }

}
