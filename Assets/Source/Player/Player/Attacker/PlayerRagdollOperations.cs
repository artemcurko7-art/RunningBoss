using UnityEngine;

public class PlayerRagdollOperations
{
    private readonly PlayerStats _playerStats;
    private readonly IProcessingDetection _detection;
    
    public PlayerRagdollOperations(PlayerStats playerStats, IProcessingDetection detection)
    {
        _playerStats = playerStats;
        _detection = detection;
    }

    public void OnEnable() =>
        _detection.Detected += Operate;

    public void OnDisable() =>
        _detection.Detected -= Operate;

    private void Operate(Transform transform)
    {
        transform.GetComponent<Collider>().enabled = false;
        transform.transform.GetChild(0).gameObject.SetActive(false);
        transform.transform.GetChild(1).gameObject.SetActive(true);

        var rigidbodies = transform.transform.GetComponentsInChildren<Rigidbody>();
            
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.AddForce(-transform.forward * _playerStats.ForwardPowerThrow, ForceMode.Impulse);
            rigidbody.AddForce(-transform.up * _playerStats.UpPowerThrow, ForceMode.Impulse);
        }
    }
}