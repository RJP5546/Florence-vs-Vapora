using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] private GameObject[] BackgroundSpawnLocations;
    [SerializeField] private GameObject[] Backgrounds;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        switch (gm.GasLeaksPatched)
        {
            case <= 2:
                Instantiate(Backgrounds[0], BackgroundSpawnLocations[0].transform);
                break;

            case > 2 and <= 4:
                Instantiate(Backgrounds[0], BackgroundSpawnLocations[1].transform);
                break;

            case > 4 and <= 6:
                Instantiate(Backgrounds[0], BackgroundSpawnLocations[2].transform);
                break;
        }
    }

}
