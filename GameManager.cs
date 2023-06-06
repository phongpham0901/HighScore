using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;

    int point = 0;
    int pointHigh = 0;
    public Text pointText;
    public Text highPoint;
    public int live = 1;
    public GameObject Panel;
    public GameObject Pause;
    [SerializeField] private AudioSource DeathAudio;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pointHigh = PlayerPrefs.GetInt("hightPoint");
    }

    // Update is called once per frame
    void Update()
    {
        highPoint.text = pointHigh.ToString();

        if (point > pointHigh)
        {
            PlayerPrefs.SetInt("hightPoint", point);
        }
    }

    public void increasePoint()
    {
        point++;
        pointText.text = point.ToString();
        print(point);
    }

    public void Dead()
    {
        live--;
        if(live <= 0)
        {
            DeathAudio.Play();
            Lose();
        }
    }

    public void Lose()
    {
        Pause.SetActive(false);
        Panel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MenuGame");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
