//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/movement.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Movement : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Movement()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""movement"",
    ""maps"": [
        {
            ""name"": ""drone"",
            ""id"": ""52882d91-f8e1-46be-8086-1fa211fc218f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""afd0d033-2f73-4237-b983-616c59bcb590"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ascend"",
                    ""type"": ""Value"",
                    ""id"": ""7a0ea788-d000-4d6a-ad06-a7863c47207c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9cf4f094-9d96-45b7-9f14-a10edafad60e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a8cb957-44fb-4336-91a4-e8b8eb58d274"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ascend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // drone
        m_drone = asset.FindActionMap("drone", throwIfNotFound: true);
        m_drone_Move = m_drone.FindAction("Move", throwIfNotFound: true);
        m_drone_ascend = m_drone.FindAction("ascend", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // drone
    private readonly InputActionMap m_drone;
    private IDroneActions m_DroneActionsCallbackInterface;
    private readonly InputAction m_drone_Move;
    private readonly InputAction m_drone_ascend;
    public struct DroneActions
    {
        private @Movement m_Wrapper;
        public DroneActions(@Movement wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_drone_Move;
        public InputAction @ascend => m_Wrapper.m_drone_ascend;
        public InputActionMap Get() { return m_Wrapper.m_drone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DroneActions set) { return set.Get(); }
        public void SetCallbacks(IDroneActions instance)
        {
            if (m_Wrapper.m_DroneActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnMove;
                @ascend.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnAscend;
                @ascend.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnAscend;
                @ascend.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnAscend;
            }
            m_Wrapper.m_DroneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ascend.started += instance.OnAscend;
                @ascend.performed += instance.OnAscend;
                @ascend.canceled += instance.OnAscend;
            }
        }
    }
    public DroneActions @drone => new DroneActions(this);
    public interface IDroneActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAscend(InputAction.CallbackContext context);
    }
}
