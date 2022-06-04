using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject confirmObject;
    [SerializeField] private GameObject healthObject;
    [SerializeField] private GameObject[] healthIcons;
    [SerializeField] private GameObject gameOverObject;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    private Player player;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            player = GameObject.Find("Nate").GetComponent<Player>();
        }
    }

    private void Update()
    {
        if(player != null)
        {
            for (int i = 0; i < player.health; i++)
            {
                healthIcons[i].SetActive(true);
            }
            for(int i = player.health; i <= 2; i++)
            {
                healthIcons[i].SetActive(false);
            }

            if (player.gameOver)
            {
                healthObject.SetActive(false);
                menuButton.SetActive(false);
                confirmObject.SetActive(false);
                gameOverObject.SetActive(true);
            }

            else
            {
                timeText.SetText("Time Survived : " + Mathf.FloorToInt(player.timeSurvived/60) + ":" + Mathf.FloorToInt(player.timeSurvived%60));
                scoreText.SetText("Roaches Killed : " + player.score);
            }
        }
    }

    public void ClickStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ClickExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ClickMenu()
    {
        Time.timeScale = 0;
        menuButton.SetActive(false);
        healthObject.SetActive(false);
        confirmObject.SetActive(true);
    }

    public void ConfirmYes()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ConfirmNo()
    {
        Time.timeScale = 1;
        confirmObject.SetActive(false);
        menuButton.SetActive(true);
        healthObject.SetActive(true);
    }
}
