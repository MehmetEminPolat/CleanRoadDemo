using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public Button againButton;
    public Transform menu;
    void Start()
    {
        againButton.onClick.AddListener(AgainGame);
    }
    private void Update()
    {
        if (Time.timeScale==0f)
        {
            menu.gameObject.SetActive(true);
        }
    }

    private void AgainGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        menu.gameObject.SetActive(false);

    }
}
