using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CatchBox _catchBox;

    private void Start()
    {
        IocContainer.Instance.InputButtonSystem.OnClicked += ButtonClick;
        IocContainer.Instance.InputButtonSystem.OnClickedOff += ButonClickoff;

        IocContainer.Instance.InputSystem.OnClicked += ButtonClick;
        IocContainer.Instance.InputSystem.OnClickedOff += ButonClickoff;

        _catchBox.CaughtBox += BoxCaught;
    }

    private void BoxCaught(MoveBox obj)
    {
        if (_animator.GetInteger("Stay") == 0)
        {
            _animator.SetInteger("Stay", 3);
        }
    }

    private void ButonClickoff()
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

    private void ButtonClick(EInputState clickState)
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