using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Flooder : MonoBehaviour
{
    #region SPOILER
    public TextMeshProUGUI countText;
    public Vector3 centerPoint;
    public float distanceBetweenObjects;
    public int numberOfObjects = 1000;
    public float timeBetweenSpawns;
    public Transform sphere;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { };
    public BoolEvent onSphereSpawn;
    public BoolEvent onPauseResume;
    //public UnityEvent OnSpawn;

    public AudioSource soundSource;
    public AudioClip[] spawnSFX;


    public bool pausedFlooding = false;

    private void Start()
    {
        StartCoroutine(ProgressiveFlood());
        //Flood();
        //StartCoroutine(startDelay(2f));
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

        for (int x = 0; x < columns && count <= numberOfObjects; x++)
        {
            for (int z = 0; z < rows && count <= numberOfObjects; z++)
            {
                Instantiate(sphere, firstPoint + (Vector3.right * x) + (Vector3.forward * z), Quaternion.identity);
                count++;
            }
        }
    }

    IEnumerator startDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Flood();
    }

    IEnumerator ProgressiveFlood()
    {
        int columns, rows;

        columns = Mathf.CeilToInt(Mathf.Sqrt(numberOfObjects));
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

                bool isEven = (count % 2 == 0);

                onSphereSpawn.Invoke(isEven);

                int randomIndex = Random.Range(0, spawnSFX.Length);
                soundSource.PlayOneShot(spawnSFX[randomIndex]);

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
        onPauseResume.Invoke(pausedFlooding);
    }

    public void SetRate(float newRate)
    {
        timeBetweenSpawns = newRate;
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
