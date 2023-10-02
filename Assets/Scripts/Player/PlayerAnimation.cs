using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeIdleToAttack()
    {
        _animator.SetTrigger("ReadyToShot");
    }

    public void ChangeIdleToStand()
    {
        _animator.SetTrigger("Idle");
    }
}