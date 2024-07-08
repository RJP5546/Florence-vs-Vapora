using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private int objectivesToComplete;
    private int objectivesCompleted = 0;
    private bool canExit;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canExit)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void CompleteObjective()
    {
        objectivesCompleted += 1;
        if(objectivesCompleted >= objectivesToComplete) 
        {
            canExit = true;
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }

    }

}
