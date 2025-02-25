//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Scripts/PlayerScripts/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""BikeGroundControls"",
            ""id"": ""642e7846-f5c2-4bb6-853e-cce3ccdfbb23"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""40f2ceef-5693-4ad2-9c4d-f38f56224445"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3917dce2-04f4-456e-9f50-f05bad4ed1f3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Trick1"",
                    ""type"": ""Button"",
                    ""id"": ""c0e5958d-710c-4761-9282-a62dc66cff5d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Trick2"",
                    ""type"": ""Button"",
                    ""id"": ""d61ac77a-e421-4ad1-a226-249a62e6ae83"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""bf6d3864-a0d7-4a86-90b2-1bb27ab28d06"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""50cc8dc4-429d-4f73-b2f7-04cfad3b19ce"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a253dfa1-db1d-46eb-95fe-787ddd5fe9ad"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6f223a60-8e7e-495c-b6b0-e6a15bfa8492"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d7d2c0f6-4238-4eda-bd4d-4ed7c9651397"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ControllerMove"",
                    ""id"": ""1a64d343-5e13-400d-8659-c386f788469a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b4b813e4-1da9-400a-9aa9-d7b1eaa22122"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8b9310b9-345c-4102-b025-523e08a2174f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3a0ead57-27a2-4b61-9efe-ad17a041e9d7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f9630ba6-21a7-493c-8000-4924cb11d59c"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""443e6408-4c44-4805-aaa4-36ef6bf62909"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d27e816e-be78-469a-afb4-b2489161c352"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6463bf1-5dae-4908-b64f-e49883a7515f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trick1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe0d7754-8178-4b8e-a59f-a9cd235adca0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trick1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faf26642-558e-4baa-948e-5518373f9554"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trick2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7c92db4-6ab0-4ae1-b268-e0bc137c769a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trick2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CameraControls"",
            ""id"": ""64ac01b8-8679-4f69-af2f-482b63e514c9"",
            ""actions"": [
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""197645f9-fa4c-4398-bb72-39211282b388"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3696822c-7092-4126-8ecd-bc8eff7ad27f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""039b3000-6b8b-4de1-afb2-c6d030e15d4c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0566dcd-056c-44be-9671-7477ca07867b"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f0e928d-8948-4e2c-a859-52062b393a5e"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""877da144-5cef-4892-8df3-78bc67e83cde"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f82ec25b-cded-4e1f-a048-83061261207c"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""228508df-a14c-4c94-871b-eec61fe00691"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5fe3757-f0b2-434c-a60f-998aea280aa8"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerControls"",
            ""id"": ""d48f9895-f649-4b5a-9e65-0ae25e73fa50"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b39fc6f7-1718-47f0-b97c-fe961374dcda"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""696c3257-9940-4140-9bee-ed18caf0c5a5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e0ef639-7f47-4428-bbd9-83899f0d0d78"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BikeGroundControls
        m_BikeGroundControls = asset.FindActionMap("BikeGroundControls", throwIfNotFound: true);
        m_BikeGroundControls_Movement = m_BikeGroundControls.FindAction("Movement", throwIfNotFound: true);
        m_BikeGroundControls_Jump = m_BikeGroundControls.FindAction("Jump", throwIfNotFound: true);
        m_BikeGroundControls_Trick1 = m_BikeGroundControls.FindAction("Trick1", throwIfNotFound: true);
        m_BikeGroundControls_Trick2 = m_BikeGroundControls.FindAction("Trick2", throwIfNotFound: true);
        // CameraControls
        m_CameraControls = asset.FindActionMap("CameraControls", throwIfNotFound: true);
        m_CameraControls_MouseX = m_CameraControls.FindAction("MouseX", throwIfNotFound: true);
        m_CameraControls_MouseY = m_CameraControls.FindAction("MouseY", throwIfNotFound: true);
        m_CameraControls_Aim = m_CameraControls.FindAction("Aim", throwIfNotFound: true);
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Pause = m_PlayerControls.FindAction("Pause", throwIfNotFound: true);
    }

    ~@PlayerInputActions()
    {
        UnityEngine.Debug.Assert(!m_BikeGroundControls.enabled, "This will cause a leak and performance issues, PlayerInputActions.BikeGroundControls.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_CameraControls.enabled, "This will cause a leak and performance issues, PlayerInputActions.CameraControls.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_PlayerControls.enabled, "This will cause a leak and performance issues, PlayerInputActions.PlayerControls.Disable() has not been called.");
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

    // BikeGroundControls
    private readonly InputActionMap m_BikeGroundControls;
    private List<IBikeGroundControlsActions> m_BikeGroundControlsActionsCallbackInterfaces = new List<IBikeGroundControlsActions>();
    private readonly InputAction m_BikeGroundControls_Movement;
    private readonly InputAction m_BikeGroundControls_Jump;
    private readonly InputAction m_BikeGroundControls_Trick1;
    private readonly InputAction m_BikeGroundControls_Trick2;
    public struct BikeGroundControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public BikeGroundControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_BikeGroundControls_Movement;
        public InputAction @Jump => m_Wrapper.m_BikeGroundControls_Jump;
        public InputAction @Trick1 => m_Wrapper.m_BikeGroundControls_Trick1;
        public InputAction @Trick2 => m_Wrapper.m_BikeGroundControls_Trick2;
        public InputActionMap Get() { return m_Wrapper.m_BikeGroundControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BikeGroundControlsActions set) { return set.Get(); }
        public void AddCallbacks(IBikeGroundControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_BikeGroundControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BikeGroundControlsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Trick1.started += instance.OnTrick1;
            @Trick1.performed += instance.OnTrick1;
            @Trick1.canceled += instance.OnTrick1;
            @Trick2.started += instance.OnTrick2;
            @Trick2.performed += instance.OnTrick2;
            @Trick2.canceled += instance.OnTrick2;
        }

        private void UnregisterCallbacks(IBikeGroundControlsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Trick1.started -= instance.OnTrick1;
            @Trick1.performed -= instance.OnTrick1;
            @Trick1.canceled -= instance.OnTrick1;
            @Trick2.started -= instance.OnTrick2;
            @Trick2.performed -= instance.OnTrick2;
            @Trick2.canceled -= instance.OnTrick2;
        }

        public void RemoveCallbacks(IBikeGroundControlsActions instance)
        {
            if (m_Wrapper.m_BikeGroundControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBikeGroundControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_BikeGroundControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BikeGroundControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BikeGroundControlsActions @BikeGroundControls => new BikeGroundControlsActions(this);

    // CameraControls
    private readonly InputActionMap m_CameraControls;
    private List<ICameraControlsActions> m_CameraControlsActionsCallbackInterfaces = new List<ICameraControlsActions>();
    private readonly InputAction m_CameraControls_MouseX;
    private readonly InputAction m_CameraControls_MouseY;
    private readonly InputAction m_CameraControls_Aim;
    public struct CameraControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public CameraControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseX => m_Wrapper.m_CameraControls_MouseX;
        public InputAction @MouseY => m_Wrapper.m_CameraControls_MouseY;
        public InputAction @Aim => m_Wrapper.m_CameraControls_Aim;
        public InputActionMap Get() { return m_Wrapper.m_CameraControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraControlsActions set) { return set.Get(); }
        public void AddCallbacks(ICameraControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Add(instance);
            @MouseX.started += instance.OnMouseX;
            @MouseX.performed += instance.OnMouseX;
            @MouseX.canceled += instance.OnMouseX;
            @MouseY.started += instance.OnMouseY;
            @MouseY.performed += instance.OnMouseY;
            @MouseY.canceled += instance.OnMouseY;
            @Aim.started += instance.OnAim;
            @Aim.performed += instance.OnAim;
            @Aim.canceled += instance.OnAim;
        }

        private void UnregisterCallbacks(ICameraControlsActions instance)
        {
            @MouseX.started -= instance.OnMouseX;
            @MouseX.performed -= instance.OnMouseX;
            @MouseX.canceled -= instance.OnMouseX;
            @MouseY.started -= instance.OnMouseY;
            @MouseY.performed -= instance.OnMouseY;
            @MouseY.canceled -= instance.OnMouseY;
            @Aim.started -= instance.OnAim;
            @Aim.performed -= instance.OnAim;
            @Aim.canceled -= instance.OnAim;
        }

        public void RemoveCallbacks(ICameraControlsActions instance)
        {
            if (m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraControlsActions @CameraControls => new CameraControlsActions(this);

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private List<IPlayerControlsActions> m_PlayerControlsActionsCallbackInterfaces = new List<IPlayerControlsActions>();
    private readonly InputAction m_PlayerControls_Pause;
    public struct PlayerControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_PlayerControls_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IPlayerControlsActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IBikeGroundControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTrick1(InputAction.CallbackContext context);
        void OnTrick2(InputAction.CallbackContext context);
    }
    public interface ICameraControlsActions
    {
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IPlayerControlsActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
