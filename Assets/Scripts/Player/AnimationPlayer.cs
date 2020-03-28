using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        IocContainer.Instance.InputSystem.OnClicked += UpdateBehaviourPlayer;
    }

    private void UpdateBehaviourPlayer(EInputState clickState)
    {
        _animator.SetInteger("Run", 0);
    }
}