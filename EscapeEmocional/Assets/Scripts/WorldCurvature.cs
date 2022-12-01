using UnityEngine;

public class WorldCurvature : MonoBehaviour
{
    [Range(-1, 1f)]
    public float curveX = 0;

    [Range(-1, 1f)]
    public float curveY = 0;

    public Material[] materials;

    void OnValidate()
    {
        foreach (Material mat in materials)
        {
            mat.SetFloat("X_Axis", curveX);
            mat.SetFloat("Y_Axis", curveY);
        }
    }
}
