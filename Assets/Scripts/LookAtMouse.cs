using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public GameObject player;

    public Transform laserPrefab;
    public LayerMask raycastMask;
    Transform laserDot;

    private void Awake()
    {
        laserDot = Instantiate(laserPrefab, Vector3.zero, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        LaserPointer();
        TurningPlayer();

    }

    void TurningPlayer()
    {
        Vector3 lookVector = laserDot.position - player.transform.position;

        lookVector.y = 0;

        player.transform.rotation = Quaternion.LookRotation(lookVector);
    }

    void LaserPointer()
    {   
        Vector3 mousePoint;

        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, raycastMask);

        mousePoint = hit.point;

        laserDot.position = mousePoint;
    }
}
