using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public bool canExit = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canExit)
        {
            SceneManager.LoadScene(1);
        }
    }

}
