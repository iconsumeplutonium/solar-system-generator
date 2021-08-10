// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""User"",
            ""id"": ""e4ca3486-5f76-4d41-8355-57b77ad5d779"",
            ""actions"": [
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""5dde31c5-05da-459e-954c-ddb57fc4f991"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseX"",
                    ""type"": ""Value"",
                    ""id"": ""14757abd-67e4-46aa-bb42-dfc87273a96e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""Value"",
                    ""id"": ""00514fdf-6dfa-4aaa-9d54-f70c17704df9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5c5245de-7616-4d63-813f-8688fad20b6e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1f5bee7-dfd9-4cc3-89d3-33da91613bc2"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Schema"",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eda4332f-292c-4401-8c55-4af229a885ec"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Schema"",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Schema"",
            ""bindingGroup"": ""Schema"",
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
        // User
        m_User = asset.FindActionMap("User", throwIfNotFound: true);
        m_User_LeftClick = m_User.FindAction("LeftClick", throwIfNotFound: true);
        m_User_MouseX = m_User.FindAction("MouseX", throwIfNotFound: true);
        m_User_MouseY = m_User.FindAction("MouseY", throwIfNotFound: true);
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

    // User
    private readonly InputActionMap m_User;
    private IUserActions m_UserActionsCallbackInterface;
    private readonly InputAction m_User_LeftClick;
    private readonly InputAction m_User_MouseX;
    private readonly InputAction m_User_MouseY;
    public struct UserActions
    {
        private @Controls m_Wrapper;
        public UserActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_User_LeftClick;
        public InputAction @MouseX => m_Wrapper.m_User_MouseX;
        public InputAction @MouseY => m_Wrapper.m_User_MouseY;
        public InputActionMap Get() { return m_Wrapper.m_User; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UserActions set) { return set.Get(); }
        public void SetCallbacks(IUserActions instance)
        {
            if (m_Wrapper.m_UserActionsCallbackInterface != null)
            {
                @LeftClick.started -= m_Wrapper.m_UserActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnLeftClick;
                @MouseX.started -= m_Wrapper.m_UserActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_UserActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnMouseY;
            }
            m_Wrapper.m_UserActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
            }
        }
    }
    public UserActions @User => new UserActions(this);
    private int m_SchemaSchemeIndex = -1;
    public InputControlScheme SchemaScheme
    {
        get
        {
            if (m_SchemaSchemeIndex == -1) m_SchemaSchemeIndex = asset.FindControlSchemeIndex("Schema");
            return asset.controlSchemes[m_SchemaSchemeIndex];
        }
    }
    public interface IUserActions
    {
        void OnLeftClick(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
    }
}
