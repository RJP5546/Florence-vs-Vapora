using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
