using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFlickering : MonoBehaviour
{
    public Material[] colors;
    MeshRenderer localRenderer;
    int currentInd = 0;

    private void Awake()
    {
        localRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        localRenderer.material = colors[Mathf.FloorToInt(currentInd / 1) % colors.Length];

        currentInd++;
    }


    #region SPOILER
    //public MeshRenderer rend;
    //public Material[] mats;
    //int currentMat = 0;

    //// Update is called once per frame
    //void Update()
    //{
    //    rend.material = mats[currentMat % 6];
    //    currentMat++;
    //}
    #endregion
}
