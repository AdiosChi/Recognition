using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KB : MonoBehaviour
{
    public GameObject Back;
    private Button backButton;
    public GameObject Next;
    private Button nextButton;
    public GameObject Space;
    private Button spaceButton;
    
    void Start()
    {
        backButton = Back.GetComponent<Button>();
        nextButton = Next.GetComponent<Button>();
        spaceButton = Space.GetComponent<Button>();
    }
    
    public void BTspace()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            spaceButton.onClick.Invoke();
           
        }
       
    }
    public void LT()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           backButton.onClick.Invoke();
           
        }
    }
    public void RT()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            nextButton.onClick.Invoke();
            
        }
    }
    private void Update()
    {
        BTspace();
        LT();
        RT();
    }
}
