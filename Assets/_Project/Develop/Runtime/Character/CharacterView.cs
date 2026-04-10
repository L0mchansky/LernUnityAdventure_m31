using UnityEngine;

public class CharacterView : MonoBehaviour, IInitializable
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;

    private bool _isInit;

    public void Initialize()
    {
        _isInit = true;
    }

    private void Update()
    {
        if (_isInit == false)
            return;

        if (_character.CurrentVelocity.magnitude > 0.05f)
            StartRunning();
        else
            StopRunning();
    }

    private void StopRunning()
    {
        _animator.SetBool(IsRunningKey, false);
    }

    private void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true);
    }
}
