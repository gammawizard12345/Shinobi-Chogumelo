using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager
    
    
    
    
    
    
    
    
    
    
    : MonoBehaviour
{

    SceneManager sceneManager;
  
   
        
    public GameObject MenuScreen;
    public GameObject MainMenu;
    public GameObject Sphere;

    // Start is called before the first frame update
    void StartMergeLater()
    {
        Scene Scene0 = SceneManager.GetSceneByName("MainMenu");
        MenuScreen.SetActive(false);
        Scene Scene1 = SceneManager.GetSceneByName("Gameplay");
    }

    // Update is called once per frame
   
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            

            for (int i = 0; i < 101; i++)
            {
                instantiateEnemy ();
            }
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        MenuScreen.SetActive(false );
        MainMenu.SetActive(true);
    }

    public void Menu()
    {
        MenuScreen.SetActive(true);
    }
    public  void VoltarJogar()
    {
        MenuScreen.SetActive(false);
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Gameplay");
        

        
    }

     void instantiateEnemy()
    {
        





    }

    

}
