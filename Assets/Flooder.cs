using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flooder : MonoBehaviour
{
    #region SPOILER
    public Text countText;
    public Vector3 centerPoint;
    public float distanceBetweenObjects;
    public int numberOfObjects = 1000;
    public float timeBetweenSpawns;
    public Transform sphere;

    public bool pausedFlooding = false;

    private void Start()
    {
        StartCoroutine(ProgressiveFlood());
        //Flood();
    }

    void Flood()
    {
        int columns, rows;

        columns = Mathf.RoundToInt(Mathf.Sqrt(numberOfObjects));
        rows = columns;

        Vector3 firstPoint = new Vector3(centerPoint.x - ((columns - 1) / 2),
            centerPoint.y,
            centerPoint.z + ((rows - 1) / 2));

        int count = 0;

        for (int x = 0; x < columns && count < numberOfObjects; x++)
        {
            for (int z = 0; z < rows && count < numberOfObjects; z++)
            {
                Instantiate(sphere, firstPoint + (Vector3.right * x) + (Vector3.forward * z), Quaternion.identity);
                count++;
            }
        }
    }

    IEnumerator ProgressiveFlood()
    {
        int columns, rows;

        columns = Mathf.RoundToInt(Mathf.Sqrt(numberOfObjects));
        rows = columns;

        Vector3 firstPoint = new Vector3(centerPoint.x - ((columns - 1) / 2),
            centerPoint.y,
            centerPoint.z + ((rows - 1) / 2));

        int count = 0;

        for (int x = 0; x < columns && count < numberOfObjects; x++)
        {
            for (int z = 0; z < rows && count < numberOfObjects; z++)
            {
                Instantiate(sphere, firstPoint + (Vector3.right * x) + (Vector3.forward * z), Quaternion.identity);
                count++;

                countText.text = count.ToString();

                do
                {
                    yield return new WaitForSeconds(timeBetweenSpawns);
                } while (pausedFlooding);
            }
        }
    }

    public void ToggleFlooding()
    {
        pausedFlooding = !pausedFlooding;
    }
    #endregion

    public void FunctionA()
    {

    }

    public void FunctionA(int x, float y)
    {

    }

    public void FunctionA(float x, int y)
    {

    }
}
