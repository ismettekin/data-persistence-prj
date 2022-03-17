using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public string playerMenuName;

    private InputField nameField;
    public Text highScoreText;
    
    private void Start() 
    {
       nameField = GameObject.Find("NameField").GetComponent<InputField>();
       
       if(DataManager.Instance != null)
       {
            DataManager.Instance.LoadHighScore();
            highScoreText.text = $"Best Score: {DataManager.Instance.highScorePlayerName} - {DataManager.Instance.highScore}";
       }

       
    }

    public void GetName()
    {
        playerMenuName = nameField.text;
        Debug.Log(playerMenuName);

        if(DataManager.Instance != null)
        {
            DataManager.Instance.c_playerName = playerMenuName;
        }
        
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
