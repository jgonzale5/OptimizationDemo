using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public GameObject player;

    public Transform laserPrefab;
    public LayerMask raycastMask;
    Transform laserDot;
    Vector3 currentPoint;

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

        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, raycastMask);

        currentPoint = hit.point;

        laserDot.position = Vector3.Lerp(laserDot.position, currentPoint, 0.5f);
        //laserDot.position = mousePoint;
    }
}
