using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(PlaneObject))]
public class PlaneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PlaneObject plane = target as PlaneObject;
        plane.Initializer();
    }
}
