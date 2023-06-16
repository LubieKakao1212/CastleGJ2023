using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class InputManager : MonoBehaviour
{
    public static event Action Shoot;

    public static Vector2 MousePos => Instance.input.Player.MousePointer.ReadValue<Vector2>();
    public static float HorizontalInput => Instance.usingController ? Instance.input.Player.GamepadHorizontal.ReadValue<float>() : Instance.input.Player.KeyboardHorizontal.ReadValue<float>();
    
    public static InputManager Instance { get; private set; }
    
    private PlayerInput input;

    private bool usingController;
    private Vector2 aimInput;

    [SerializeField]
    private float aimDeadzone = 0.25f;

    private void Awake()
    {
        Assert.IsNull(Instance, "Duplicate InputManager");
        Instance = this;

        input = new PlayerInput();
        input.Enable();

        input.Player.EnableController.started += (ctx) => usingController = !usingController;

        input.Player.Aim.performed += (ctx) =>
        {
            var input = ctx.ReadValue<Vector2>();
            aimInput = input.magnitude > aimDeadzone ? input : aimInput;
        };

        input.Player.Fire.started += (ctx) =>
        {
            Shoot?.Invoke();
        };
    }

    public static Vector2 InputDirection(Vector3 targetWorldSpace)
    {
        if (Instance.usingController)
        {
            return Instance.aimInput.normalized;
        }

        return ((Vector2)(Camera.main.ScreenToWorldPoint(MousePos) - targetWorldSpace)).normalized;
    }
}
