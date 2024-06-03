using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public List<GameObject> gameObjects;

    void Start(){
        scoreText.text += FindObjectOfType<GameManager>().totalScore.ToString();
        foreach(GameObject gameObject in gameObjects){
            gameObject.SetActive(false);
        }
    }

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
