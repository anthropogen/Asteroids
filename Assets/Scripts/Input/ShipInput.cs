//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/ShipInput.inputactions
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

public partial class @ShipInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShipInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShipInput"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""aaf86635-503f-4335-8c49-a8d1265023d9"",
            ""actions"": [
                {
                    ""name"": ""ForwardMovement"",
                    ""type"": ""Button"",
                    ""id"": ""3e58b5fa-b0bd-41de-99a8-c225cc173b75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""aebf4c0d-a923-499e-a727-2169a798bb15"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Invert"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FireLaser"",
                    ""type"": ""Button"",
                    ""id"": ""81210788-3ac6-4223-ba15-31240042aede"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FireBullet"",
                    ""type"": ""Button"",
                    ""id"": ""542dc65d-b91d-4e1f-ad0d-75004dadb4c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""55f1aebb-8dbb-4121-a3c2-77922899f743"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": ""Hold(duration=0.001,pressPoint=0.001)"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ForwardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1527db8d-27f8-47a9-8b6a-533fc6b3f754"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ForwardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a62d816-8818-416c-9aca-2d635c647c44"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""FireLaser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76480efd-a8f8-4313-a358-c65dbc6225d1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""FireBullet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4017db4b-2b47-4a5d-a5d9-3ede733b634e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3566f2ad-ce95-48ef-81dd-5ad63099aabc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7b1c5a22-4742-4e9d-9b32-2dd0f23131b9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2069e3aa-2cfc-4d15-8c19-6732147d6fea"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c52ee62f-5e51-43d5-ae7f-ca4748d84598"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_ForwardMovement = m_Ship.FindAction("ForwardMovement", throwIfNotFound: true);
        m_Ship_Rotation = m_Ship.FindAction("Rotation", throwIfNotFound: true);
        m_Ship_FireLaser = m_Ship.FindAction("FireLaser", throwIfNotFound: true);
        m_Ship_FireBullet = m_Ship.FindAction("FireBullet", throwIfNotFound: true);
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

    // Ship
    private readonly InputActionMap m_Ship;
    private IShipActions m_ShipActionsCallbackInterface;
    private readonly InputAction m_Ship_ForwardMovement;
    private readonly InputAction m_Ship_Rotation;
    private readonly InputAction m_Ship_FireLaser;
    private readonly InputAction m_Ship_FireBullet;
    public struct ShipActions
    {
        private @ShipInput m_Wrapper;
        public ShipActions(@ShipInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ForwardMovement => m_Wrapper.m_Ship_ForwardMovement;
        public InputAction @Rotation => m_Wrapper.m_Ship_Rotation;
        public InputAction @FireLaser => m_Wrapper.m_Ship_FireLaser;
        public InputAction @FireBullet => m_Wrapper.m_Ship_FireBullet;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void SetCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterface != null)
            {
                @ForwardMovement.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnForwardMovement;
                @ForwardMovement.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnForwardMovement;
                @ForwardMovement.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnForwardMovement;
                @Rotation.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotation;
                @FireLaser.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireLaser;
                @FireLaser.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireLaser;
                @FireLaser.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireLaser;
                @FireBullet.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireBullet;
                @FireBullet.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireBullet;
                @FireBullet.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireBullet;
            }
            m_Wrapper.m_ShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ForwardMovement.started += instance.OnForwardMovement;
                @ForwardMovement.performed += instance.OnForwardMovement;
                @ForwardMovement.canceled += instance.OnForwardMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @FireLaser.started += instance.OnFireLaser;
                @FireLaser.performed += instance.OnFireLaser;
                @FireLaser.canceled += instance.OnFireLaser;
                @FireBullet.started += instance.OnFireBullet;
                @FireBullet.performed += instance.OnFireBullet;
                @FireBullet.canceled += instance.OnFireBullet;
            }
        }
    }
    public ShipActions @Ship => new ShipActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IShipActions
    {
        void OnForwardMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnFireLaser(InputAction.CallbackContext context);
        void OnFireBullet(InputAction.CallbackContext context);
    }
}
