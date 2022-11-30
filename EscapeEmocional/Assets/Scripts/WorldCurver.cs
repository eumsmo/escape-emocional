using UnityEngine;

public class WorldCurver : MonoBehaviour
{
    [Range(-0.1f, 0.1f)]
    public float curveStrength = -0.1f;

    int m_CurveStrengthID;

    void OnEnable()
    {
        m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
    }

    void Update()
    {
        Shader.SetGlobalFloat(m_CurveStrengthID, curveStrength);
    }
}
