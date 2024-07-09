using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxingBackground : MonoBehaviour
{

    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform followTarget;

    private Vector2 startingPos;

    private float startingZ;

    private Vector2 camMovementsinceStart => (Vector2)mainCam.transform.position - startingPos;

    private float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    private float clippingPlane => (mainCam.transform.position.z + (zDistanceFromTarget > 0 ? mainCam.farClipPlane : mainCam.nearClipPlane));

    private float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        startingPos = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Newpos = startingPos + camMovementsinceStart * parallaxFactor;

        transform.position = new Vector3(Newpos.x,Newpos.y, startingZ);
    }
}
