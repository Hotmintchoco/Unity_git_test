using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        mainMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
    }

    public void MainMenu()
    {
        mainMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }

    public void SetScreenResolution(int i)
    {
        
    }

    public void SetFullscreen(bool isFullscreen)
    {
        
    }

    public void SetMasterVolume(float value)
    {
        
    }

    public void SetMusicVolume(float value)
    {
        
    }

    public void SetSfxVolume(float value)
    {
        
    }
}
