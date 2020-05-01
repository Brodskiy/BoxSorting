using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class TransitionAttenuation : SceneTransitionSystem
{
    [SerializeField] private Image _attenuationImage;
    [SerializeField] private float _speedAttenuation = 0.5f;

    private string _sceneName;
    private Color _finalColor = Color.white;
    private bool _isStartTransition;
    private bool _isAttenuationComplet;

    private void Update()
    {
        if (_isStartTransition)
        {
            AttenuationImage();

            if (_isAttenuationComplet)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(_sceneName);
            }
        }
    }

    private void AttenuationImage()
    {
        _attenuationImage.enabled = true;
        if(_attenuationImage.color.a <= 0.85f)
        {
            _attenuationImage.color = Color.Lerp(_attenuationImage.color, _finalColor, _speedAttenuation * Time.deltaTime);
        }

        else
        {
            _isAttenuationComplet = true;
        }
    }

    public override void TransitionToScene(string sceneName)
    {
        _sceneName = sceneName;
        _isStartTransition = true;
    }
}