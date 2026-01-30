using UnityEngine;
using Zenject;

public class ServicePlayer : MonoBehaviour
{
    [SerializeField] private PlayerMoverHorizontal _moverHorizontal;
    [SerializeField] private Player _player;
    
    [Inject]
    public void Construct(MoverForward moverForward, MoverHorizontal moverHorizontal, IHealthPresenter health, PlayerStats playerStats, Animator animator)
    {
        _player.Initialize(moverForward, health, animator, playerStats.MovementForwardSpeed);
        _moverHorizontal.Initialize(moverHorizontal, _player.transform, playerStats.MovementHorizontalSpeed);
    }
}