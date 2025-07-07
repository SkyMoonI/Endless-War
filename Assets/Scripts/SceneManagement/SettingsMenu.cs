using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI;

    public TMP_Text TIME_TXT;
    private void Start()
    {
        TIME_TXT.text = "Time : ";
    }
    private void Update()
    {
        if(TIME_TXT != null)
            TIME_TXT.text = "Time : " + ((int)Time.timeSinceLevelLoad).ToString();
    }
    public void PressAttack()
    {
        if (animationStateController.attackPressed == false)
            animationStateController.attackPressed = true;
        else
            animationStateController.attackPressed = false;
    }
    public void PressRoll()
    {
        animationStateController.rollPressed = true;
    }
    public void OpenSettings()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void BackToGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
