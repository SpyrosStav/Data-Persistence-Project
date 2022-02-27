using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField usernameInputField;
    public static string username;
    // Start is called before the first frame update
    void Start()
    {   
        if(username != null)
            usernameInputField.text = username;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        {
    #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
    #else
            Application.Quit(); // original code to quit Unity player
    #endif
        }
    }

    public void SaveUsername(string newName)
    {
        MenuManager.Instance.Username = newName;
    }
}
