using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CatchBox _catchBox;

    private void Start()
    {
        IocContainer.Instance.InputSystem.OnClicked += UpdateBehaviourPlayer;
        IocContainer.Instance.InputSystem.OnClickedOff += InputSystem_OnClickedOff;
        _catchBox.CaughtBox += _catchBox_CaughtBox;
    }

    private void _catchBox_CaughtBox(BoxContainerSystem obj)
    {
        _animator.SetInteger("Stay", 3);
    }

    private void InputSystem_OnClickedOff()
    {
        if (_catchBox._isHandsFree)
        {
            _animator.SetInteger("Stay", 0);
        }
        else
        {
            _animator.SetInteger("Stay", 3);
        }
    }

    private void UpdateBehaviourPlayer(EInputState clickState)
    {
        switch (clickState)
        {
            case EInputState.Left:
                _animator.SetInteger("Stay", 1);
                break;
            case EInputState.Right:
                _animator.SetInteger("Stay", 1);
                break;
            case EInputState.Down:
                _animator.SetInteger("Stay", 2);
                break;
        }
    }
}