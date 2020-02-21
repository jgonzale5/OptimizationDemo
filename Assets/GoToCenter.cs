using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCenter : MonoBehaviour
{
    Vector3 OriginalPosition;
    Vector3 Destination = Vector3.zero;
    public float coveragePerSecond = 0.1f;
    float progress = 0;

    private void Start()
    {
        OriginalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        progress += coveragePerSecond * Time.deltaTime;
        transform.position = Vector3.Lerp(OriginalPosition, Destination, progress);
    }
}
