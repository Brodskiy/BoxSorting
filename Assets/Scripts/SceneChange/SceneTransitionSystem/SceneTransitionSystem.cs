using UnityEngine;

public abstract class SceneTransitionSystem:MonoBehaviour
{
    public abstract void TransitionToScene(string sceneName);
}