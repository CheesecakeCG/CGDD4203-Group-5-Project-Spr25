using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas optionsMenu;
    public Canvas playerHUD;
    public Canvas winScreen;
    public Canvas loseScreen;

    public Button ARModeButton;

    public bool ARMode;
    public Camera nonARCam;
    public Camera ARCam;

    public AudioMixer audioMixer;

    public int menuIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ARMode = true;
        nonARCam.enabled = false;
        ARCam.enabled = true;
        Time.timeScale = 0f;
        mainMenu.enabled = true;
        optionsMenu.enabled = false;
        playerHUD.enabled = false;
        winScreen.enabled = false;
        loseScreen.enabled = false;
    }

    public void GoToGame()
    {
        Time.timeScale = 1f;
        mainMenu.enabled = false;
        optionsMenu.enabled = false;
        playerHUD.enabled = true;
    }

    public void GoBack()
    {
        switch (menuIndex)
        {
            case 0:
                GoToMainMenu();
                break;

            case 1:
                GoToGame();
                break;
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 0f;
        mainMenu.enabled = true;
        optionsMenu.enabled = false;
        playerHUD.enabled = false;
    }

    public void GoToOptionsMenu(int menuIndex)
    {
        this.menuIndex = menuIndex;
        Time.timeScale = 0f;
        mainMenu.enabled = false;
        optionsMenu.enabled = true;
        playerHUD.enabled = false;
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        playerHUD.enabled = false;
        winScreen.enabled = true;
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        playerHUD.enabled = false;
        loseScreen.enabled = true;
    }

    public void SwitchARMode()
    {
        ARMode = !ARMode;

        if (ARMode)
        {
            ARModeButton.GetComponent<Image>().color = new Color(0f, 255f, 0f, 255f);
        } 
        else
        {
            ARModeButton.GetComponent<Image>().color = new Color(255f, 0f, 0f, 255f);
        }

        ARCam.enabled = !ARCam.enabled;
        nonARCam.enabled = !nonARCam.enabled;
    }

    public void ChangeMusicVolume(float volume)
    {

    }

    public void ChangeSFXVolume(float volume)
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
