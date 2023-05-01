using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer LineRenderer;

    List<Vector2> points; 

    public void UpdateLine(Vector2 position) 
    {
        if (points == null) 
        {
            points = new List<Vector2>();
            SetPoint(position); 
            return;
        }

        if (Vector2.Distance(points.Last(), position) > .1f) 
        {
            SetPoint(position); 
        }
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        LineRenderer.positionCount = points.Count;
        LineRenderer.SetPosition(points.Count - 1, point);
    }
}
