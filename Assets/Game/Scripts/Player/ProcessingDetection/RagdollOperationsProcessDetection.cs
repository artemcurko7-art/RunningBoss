using UnityEngine;

public class RagdollOperationsProcessDetection : ProcessingDetectionSubscriber
{
    private const int FactorForwardForce = 5;
    private const int UpForce = 20;
    private readonly ISpeed _speed;
    
    public RagdollOperationsProcessDetection(IProcessingDetected detected, ISpeed speed) 
        : base(detected)
    {
        _speed = speed;
    }

    protected override void OnDetected(Unit unit)
    {
        unit.Animator.enabled = false;
        unit.Collider.enabled = false;
        unit.Root.SetActive(false);
        unit.Death.gameObject.SetActive(true);
        
        var rigidbodies = unit.transform.GetComponentsInChildren<Rigidbody>();
        
        float forwardForce = _speed.Value * FactorForwardForce;

        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.AddForce(-unit.transform.forward * forwardForce, ForceMode.Impulse);
            rigidbody.AddForce(unit.transform.up * UpForce, ForceMode.Impulse);
        }
    }
}