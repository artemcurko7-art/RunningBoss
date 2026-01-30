using UnityEngine;

public class SettingPosition 
{
    public Vector3 GetCalculationOnLength(Transform transform) =>
        transform.position + transform.forward * transform.localScale.z;
    
    public Vector3 GetRandom(Transform spawn)
    {
        int index = Random.Range(0, spawn.childCount);
        Vector3 position = spawn.GetChild(index).position;

        return position;
    }
}