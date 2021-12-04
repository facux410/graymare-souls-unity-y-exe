using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{


    public BezierPoint[] allBeziersPoints;
    public GameObject finalTest;

    float time;

    int currentPoint = 1;


    private void Awake()
    {
        StartCoroutine(Move());
    }

    private void Update()
    {
        if (currentPoint > allBeziersPoints.Length - 1)
            return;


        var distance = Vector3.Distance(finalTest.transform.position, allBeziersPoints[currentPoint].transform.position);
        if (distance <= 0)
            StartCoroutine(NextStep());

        if (currentPoint <= allBeziersPoints.Length - 1)
            finalTest.transform.position = GetPointOnBezierCurve(allBeziersPoints[currentPoint - 1], allBeziersPoints[currentPoint]);
    }
    Vector3 GetPointOnBezierCurve(BezierPoint ini, BezierPoint final)
    {
        Vector3 a = Vector3.Lerp(ini.transform.position, ini.son.transform.position, time);
        Vector3 b = Vector3.Lerp(ini.son.transform.position, final.son.transform.position, time);
        Vector3 c = Vector3.Lerp(final.son.transform.position, final.transform.position, time);

        Vector3 d = Vector3.Lerp(a, b, time);
        Vector3 e = Vector3.Lerp(b, c, time);
        Vector3 pointOnCurve = Vector3.Lerp(d, e, time);

        return pointOnCurve;
    }


    IEnumerator Move()
    {
        while (true)
        {
            time += 0.05f;
            yield return new WaitForSeconds(0.05f);
            if (time >= 1)
                time = 0;
        }
    }

    IEnumerator NextStep()
    {
        currentPoint++;
        time = 0;
        yield return new WaitForSeconds(0.1f);
        if (currentPoint > allBeziersPoints.Length - 1)
        {
            currentPoint = 1;
            finalTest.transform.position = allBeziersPoints[0].gameObject.transform.position;
        }
    }
}
