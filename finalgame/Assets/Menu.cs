using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour
{
    public GameObject Space;
    private Button spaceButton;
    public void BTspace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceButton.onClick.Invoke();
        }

    }
    void Start()
    {
        spaceButton = Space.GetComponent<Button>();
    }
    public void PlayGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    private void Update()
    {
        BTspace();
    }
}
