using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject
{
    [SerializeField] Vector3 initialValue;

    public Vector3 GetInitialValue() => initialValue;

    public void SetInitialValue(Vector3 initialValue)
    {
        this.initialValue = initialValue;
    }
}
