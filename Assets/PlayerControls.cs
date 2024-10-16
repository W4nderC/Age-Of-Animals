//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.0
//     from Assets/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PLayer"",
            ""id"": ""3f488194-0f9a-47b9-baf9-0c48f8c4a832"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""69dc3914-1dc4-46ae-8a12-1e74c9abd5d6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Paused"",
                    ""type"": ""Button"",
                    ""id"": ""3b25fc65-6936-46fe-8cea-7baf5bcfeb29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD_2D Vector"",
                    ""id"": ""b84c8da5-ceff-49ba-99e9-009a33a41b62"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29c0cac1-d41a-4d7b-b594-cfbc14a25f1e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""725c8ebe-14f0-405e-926b-92d3f50536e4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a4af1a05-cc21-404a-af2a-971fdcae0113"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""671f52e0-d1d8-4cd5-873b-4f8dfaa27262"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick_2D Vector"",
                    ""id"": ""039e4d2d-7386-4646-a9dd-70f83ffdef67"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""76ac1090-f591-4d37-bb5b-f113931c2c4f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4e315222-bd8f-4e20-b011-942743ee23d2"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""60f6c649-d114-4812-94f4-fb4c97204d60"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""879e6ad1-f90a-4b13-827b-3dec4de3c077"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c4175375-f475-43e8-ad64-a9d7e6acd453"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Paused"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PLayer
        m_PLayer = asset.FindActionMap("PLayer", throwIfNotFound: true);
        m_PLayer_Move = m_PLayer.FindAction("Move", throwIfNotFound: true);
        m_PLayer_Paused = m_PLayer.FindAction("Paused", throwIfNotFound: true);
    }

    ~@PlayerControls()
    {
        UnityEngine.Debug.Assert(!m_PLayer.enabled, "This will cause a leak and performance issues, PlayerControls.PLayer.Disable() has not been called.");
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

    // PLayer
    private readonly InputActionMap m_PLayer;
    private List<IPLayerActions> m_PLayerActionsCallbackInterfaces = new List<IPLayerActions>();
    private readonly InputAction m_PLayer_Move;
    private readonly InputAction m_PLayer_Paused;
    public struct PLayerActions
    {
        private @PlayerControls m_Wrapper;
        public PLayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PLayer_Move;
        public InputAction @Paused => m_Wrapper.m_PLayer_Paused;
        public InputActionMap Get() { return m_Wrapper.m_PLayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PLayerActions set) { return set.Get(); }
        public void AddCallbacks(IPLayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PLayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PLayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Paused.started += instance.OnPaused;
            @Paused.performed += instance.OnPaused;
            @Paused.canceled += instance.OnPaused;
        }

        private void UnregisterCallbacks(IPLayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Paused.started -= instance.OnPaused;
            @Paused.performed -= instance.OnPaused;
            @Paused.canceled -= instance.OnPaused;
        }

        public void RemoveCallbacks(IPLayerActions instance)
        {
            if (m_Wrapper.m_PLayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPLayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PLayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PLayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PLayerActions @PLayer => new PLayerActions(this);
    public interface IPLayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPaused(InputAction.CallbackContext context);
    }
}
