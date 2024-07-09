using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] private GameObject[] Backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        switch (gm.GasLeaksPatched)
        {
            case <= 2:
                Instantiate(Backgrounds[0], this.transform);
                break;

            case <= 4 and > 2:
                Instantiate(Backgrounds[0], this.transform);
                break;

            case <= 6 and > 4:
                Instantiate(Backgrounds[0], this.transform);
                break;
        }
    }

}
