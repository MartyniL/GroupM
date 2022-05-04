using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject firstMenu, optionsMenu;
    public static bool isOptions = false;

    public Slider masterVol, musicVol, sfxVol;
    public AudioSource bgMusic;

    public void GoToOptions()
    {
        firstMenu.gameObject.SetActive(false);
        optionsMenu.SetActive(true);
        isOptions = true;
    }

    public void GoBack()
    {
        firstMenu.gameObject.SetActive(true);
        optionsMenu.SetActive(false);
        isOptions = false;
    }

    public void StartGame()
    {
        SavePlayerPrefs();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Awake()
    {
        masterVol.value = PlayerPrefs.GetFloat("master");
        musicVol.value = PlayerPrefs.GetFloat("music");
        sfxVol.value = PlayerPrefs.GetFloat("sfx");
    }

    void SavePlayerPrefs()
    {
        PlayerPrefs.SetFloat("master", masterVol.value);
        PlayerPrefs.SetFloat("music", musicVol.value);
        PlayerPrefs.SetFloat("sfx", sfxVol.value);
    }

    public void Quit()
    {
        SavePlayerPrefs();
        Application.Quit();
    }

    private void Update()
    {
        bgMusic.volume = (masterVol.value * musicVol.value) / 2;
    }
}
