using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationWait : CustomYieldInstruction
{
    private Animation a;

    public AnimationWait(Animation a)
    {
        this.a = a;

        if (a.clip.isLooping) throw new System.Exception();

        a.Play();
    }

    public override bool keepWaiting => a.isPlaying;
}

public static class AnimationExtension
{
    public static AnimationWait PlayAndWaitCompletion(this Animation @this)
        => new AnimationWait(@this);
}



public class PlayerBrain : MonoBehaviour
{
    [SerializeField, BoxGroup("Dependencies")] EntityMovement _movement;

    [SerializeField, BoxGroup("Input")] InputActionProperty _moveInput;
    [SerializeField, BoxGroup("Input")] InputActionProperty _attackInput;

    private void Start()
    {
        // Move
        _moveInput.action.started += UpdateMove;
        _moveInput.action.performed += UpdateMove;
        _moveInput.action.canceled += StopMove;
        // Attack
        //_attackInput.action.started += Attack;
    }




    void run()
    {
        var speedbase = 10;
        var armurespeed = 1.3;
        var coffeefactor = 1.2f;


        var s = speedbase * armurespeed * coffeefactor;
    }





    Coroutine _maCoroutine;
    public void RunCoucou()
    {
        if (_maCoroutine != null) return;

        int i = 10;
        _maCoroutine = StartCoroutine(coucouRoutine());
        IEnumerator coucouRoutine()
        {
            Animation a = GetComponent<Animation>();
            yield return new AnimationWait(a);
            yield return a.PlayAndWaitCompletion();

            var wait = new WaitForSeconds(10f);
            i++;
            yield return wait;
            i++;
            yield return wait;
            i++;
            yield return wait;

            _maCoroutine = null;
            yield break;
        }
    }

    private void OnDestroy()
    {
        // Move
        _moveInput.action.started -= UpdateMove;
        _moveInput.action.performed -= UpdateMove;
        _moveInput.action.canceled -= StopMove;
    }


    private void UpdateMove(InputAction.CallbackContext obj)
    {
        _movement.Move(obj.ReadValue<Vector2>().normalized);
    }
    private void StopMove(InputAction.CallbackContext obj)
    {
        _movement.Move(Vector2.zero);
    }
}
