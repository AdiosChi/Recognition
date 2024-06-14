using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KBend : MonoBehaviour
{
    public GameObject Space;
    
    private Button spaceButton;
    void Start()
    {
        spaceButton = Space.GetComponent<Button>();
    }
    public void BTEndspace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceButton.onClick.Invoke();
            ScoreCode.Score = 0;
        }

    }
    public void PlayAgain()
    {

        SceneManager.LoadScene(1);

    }
    // Update is called once per frame
    void Update()
    {
        BTEndspace();
    }
}
