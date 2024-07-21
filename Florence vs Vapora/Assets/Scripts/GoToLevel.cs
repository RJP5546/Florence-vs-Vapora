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
