using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    PlayerControler player;
    Image healthBar;

    GameObject pauseMenu;
    GameObject weaponUI;

    public bool isPaused = false;

    TextMeshProUGUI ammoCounter;
    TextMeshProUGUI clip;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();

            weaponUI = GameObject.FindGameObjectWithTag("weaponUI");
            pauseMenu = GameObject.FindGameObjectWithTag("UI_pause");

            pauseMenu.SetActive(false);

            healthBar = GameObject.FindGameObjectWithTag("UI_health").GetComponent<Image>();
            ammoCounter = GameObject.FindGameObjectWithTag("UI_Ammo").GetComponent<TextMeshProUGUI>();
            clip = GameObject.FindGameObjectWithTag("UI_Clip").GetComponent<TextMeshProUGUI>();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            healthBar.fillAmount = (float)player.health / (float)player.maxhealth;

            if (player.currentWeapon != null)
            {
                weaponUI.SetActive(true);

                ammoCounter.text = "Ammo: " + player.currentWeapon.ammo;
                clip.text = "Clip: " + player.currentWeapon.clip + " / " + player.currentWeapon.clipSize;
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadLevel(int level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
    public void MainMenu()
    {
        LoadLevel(0);
    }
    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            Resume();
    }
    public void Resume()
    {
            if (isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false );
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
