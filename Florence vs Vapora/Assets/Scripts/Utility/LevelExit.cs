using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private string LevelToLoad;
    private bool canExit;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canExit)
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }

    public void CompleteObjective()
    {
        if (!canExit)
        {
            canExit = true;
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }
        gm.GasLeaksPatched += 1;
    }

}
