//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Actions/PlayerActions.inputactions
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

public partial class @PlayerActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""30a91a4d-6800-4969-8bc6-eba740056442"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""34425c73-c58d-408a-841e-4dc258a79d68"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""949377f7-2134-4c43-af36-1959547534a1"",
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
                    ""id"": ""c535b93b-4d52-4dbd-aece-156425e5aa82"",
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
                    ""id"": ""02c0e205-d792-4b99-bcaf-9158595418ec"",
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
                    ""id"": ""8f16a44f-2d7b-433e-84d5-6bd8e7b1daab"",
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
                    ""id"": ""75219b75-bf5c-42b2-9b5e-1cee3caa54d5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Attack"",
            ""id"": ""4a68647c-474b-4941-8609-d25c338d7533"",
            ""actions"": [
                {
                    ""name"": ""ClickAttack"",
                    ""type"": ""Button"",
                    ""id"": ""52d4f352-9fe8-49a5-8d2e-ffd059b9eda3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""57cf979b-5d4a-4f97-828a-96f436e5b7f1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""3ac070a9-7c8b-45fc-a5e8-5c1fad2e9d09"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""756eef17-d6ec-403b-a50c-eb1b15323b0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a0c28613-83ea-4426-ba2c-a53647ac5328"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Farming"",
            ""id"": ""c58f10bf-2c89-4a8d-acfa-df895489ffec"",
            ""actions"": [
                {
                    ""name"": ""Plant"",
                    ""type"": ""Button"",
                    ""id"": ""a5130c0a-a55a-4049-a9fb-9fffa7bf45c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Harvest"",
                    ""type"": ""Button"",
                    ""id"": ""b94024b4-2b1a-4ca5-b9d1-86d211f19117"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4a43c60b-ce51-4783-8e32-78622a9d831b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Plant"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35ac90c5-6233-4cc7-88ab-fa655dc57324"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Harvest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""General"",
            ""id"": ""95de5ee6-8a69-4cd4-b73f-204531b0d65f"",
            ""actions"": [
                {
                    ""name"": ""MainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""b4291867-d481-49e5-b719-8b9c6ea6d7c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ResetPlayer"",
                    ""type"": ""Button"",
                    ""id"": ""52a03d8b-ee51-4e3d-acd3-05ab0a48b3db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AddExperience"",
                    ""type"": ""Button"",
                    ""id"": ""e1e153fe-8f00-49c7-b9b3-baca89c917ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1a7af81c-3f87-42ec-b151-e1e0f5ba1b2c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3792f6f-5e0c-441b-944d-d814b2f3a49c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetPlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8b73dde-5874-41aa-943a-5759d490ac8c"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddExperience"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        // Attack
        m_Attack = asset.FindActionMap("Attack", throwIfNotFound: true);
        m_Attack_ClickAttack = m_Attack.FindAction("ClickAttack", throwIfNotFound: true);
        // Dialogue
        m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
        m_Dialogue_Interact = m_Dialogue.FindAction("Interact", throwIfNotFound: true);
        // Farming
        m_Farming = asset.FindActionMap("Farming", throwIfNotFound: true);
        m_Farming_Plant = m_Farming.FindAction("Plant", throwIfNotFound: true);
        m_Farming_Harvest = m_Farming.FindAction("Harvest", throwIfNotFound: true);
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_MainMenu = m_General.FindAction("MainMenu", throwIfNotFound: true);
        m_General_ResetPlayer = m_General.FindAction("ResetPlayer", throwIfNotFound: true);
        m_General_AddExperience = m_General.FindAction("AddExperience", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Move;
    public struct MovementActions
    {
        private @PlayerActions m_Wrapper;
        public MovementActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Attack
    private readonly InputActionMap m_Attack;
    private List<IAttackActions> m_AttackActionsCallbackInterfaces = new List<IAttackActions>();
    private readonly InputAction m_Attack_ClickAttack;
    public struct AttackActions
    {
        private @PlayerActions m_Wrapper;
        public AttackActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ClickAttack => m_Wrapper.m_Attack_ClickAttack;
        public InputActionMap Get() { return m_Wrapper.m_Attack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackActions set) { return set.Get(); }
        public void AddCallbacks(IAttackActions instance)
        {
            if (instance == null || m_Wrapper.m_AttackActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AttackActionsCallbackInterfaces.Add(instance);
            @ClickAttack.started += instance.OnClickAttack;
            @ClickAttack.performed += instance.OnClickAttack;
            @ClickAttack.canceled += instance.OnClickAttack;
        }

        private void UnregisterCallbacks(IAttackActions instance)
        {
            @ClickAttack.started -= instance.OnClickAttack;
            @ClickAttack.performed -= instance.OnClickAttack;
            @ClickAttack.canceled -= instance.OnClickAttack;
        }

        public void RemoveCallbacks(IAttackActions instance)
        {
            if (m_Wrapper.m_AttackActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAttackActions instance)
        {
            foreach (var item in m_Wrapper.m_AttackActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AttackActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AttackActions @Attack => new AttackActions(this);

    // Dialogue
    private readonly InputActionMap m_Dialogue;
    private List<IDialogueActions> m_DialogueActionsCallbackInterfaces = new List<IDialogueActions>();
    private readonly InputAction m_Dialogue_Interact;
    public struct DialogueActions
    {
        private @PlayerActions m_Wrapper;
        public DialogueActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Dialogue_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
        public void AddCallbacks(IDialogueActions instance)
        {
            if (instance == null || m_Wrapper.m_DialogueActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DialogueActionsCallbackInterfaces.Add(instance);
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IDialogueActions instance)
        {
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(IDialogueActions instance)
        {
            if (m_Wrapper.m_DialogueActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDialogueActions instance)
        {
            foreach (var item in m_Wrapper.m_DialogueActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DialogueActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DialogueActions @Dialogue => new DialogueActions(this);

    // Farming
    private readonly InputActionMap m_Farming;
    private List<IFarmingActions> m_FarmingActionsCallbackInterfaces = new List<IFarmingActions>();
    private readonly InputAction m_Farming_Plant;
    private readonly InputAction m_Farming_Harvest;
    public struct FarmingActions
    {
        private @PlayerActions m_Wrapper;
        public FarmingActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Plant => m_Wrapper.m_Farming_Plant;
        public InputAction @Harvest => m_Wrapper.m_Farming_Harvest;
        public InputActionMap Get() { return m_Wrapper.m_Farming; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FarmingActions set) { return set.Get(); }
        public void AddCallbacks(IFarmingActions instance)
        {
            if (instance == null || m_Wrapper.m_FarmingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FarmingActionsCallbackInterfaces.Add(instance);
            @Plant.started += instance.OnPlant;
            @Plant.performed += instance.OnPlant;
            @Plant.canceled += instance.OnPlant;
            @Harvest.started += instance.OnHarvest;
            @Harvest.performed += instance.OnHarvest;
            @Harvest.canceled += instance.OnHarvest;
        }

        private void UnregisterCallbacks(IFarmingActions instance)
        {
            @Plant.started -= instance.OnPlant;
            @Plant.performed -= instance.OnPlant;
            @Plant.canceled -= instance.OnPlant;
            @Harvest.started -= instance.OnHarvest;
            @Harvest.performed -= instance.OnHarvest;
            @Harvest.canceled -= instance.OnHarvest;
        }

        public void RemoveCallbacks(IFarmingActions instance)
        {
            if (m_Wrapper.m_FarmingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFarmingActions instance)
        {
            foreach (var item in m_Wrapper.m_FarmingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FarmingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FarmingActions @Farming => new FarmingActions(this);

    // General
    private readonly InputActionMap m_General;
    private List<IGeneralActions> m_GeneralActionsCallbackInterfaces = new List<IGeneralActions>();
    private readonly InputAction m_General_MainMenu;
    private readonly InputAction m_General_ResetPlayer;
    private readonly InputAction m_General_AddExperience;
    public struct GeneralActions
    {
        private @PlayerActions m_Wrapper;
        public GeneralActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MainMenu => m_Wrapper.m_General_MainMenu;
        public InputAction @ResetPlayer => m_Wrapper.m_General_ResetPlayer;
        public InputAction @AddExperience => m_Wrapper.m_General_AddExperience;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void AddCallbacks(IGeneralActions instance)
        {
            if (instance == null || m_Wrapper.m_GeneralActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GeneralActionsCallbackInterfaces.Add(instance);
            @MainMenu.started += instance.OnMainMenu;
            @MainMenu.performed += instance.OnMainMenu;
            @MainMenu.canceled += instance.OnMainMenu;
            @ResetPlayer.started += instance.OnResetPlayer;
            @ResetPlayer.performed += instance.OnResetPlayer;
            @ResetPlayer.canceled += instance.OnResetPlayer;
            @AddExperience.started += instance.OnAddExperience;
            @AddExperience.performed += instance.OnAddExperience;
            @AddExperience.canceled += instance.OnAddExperience;
        }

        private void UnregisterCallbacks(IGeneralActions instance)
        {
            @MainMenu.started -= instance.OnMainMenu;
            @MainMenu.performed -= instance.OnMainMenu;
            @MainMenu.canceled -= instance.OnMainMenu;
            @ResetPlayer.started -= instance.OnResetPlayer;
            @ResetPlayer.performed -= instance.OnResetPlayer;
            @ResetPlayer.canceled -= instance.OnResetPlayer;
            @AddExperience.started -= instance.OnAddExperience;
            @AddExperience.performed -= instance.OnAddExperience;
            @AddExperience.canceled -= instance.OnAddExperience;
        }

        public void RemoveCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGeneralActions instance)
        {
            foreach (var item in m_Wrapper.m_GeneralActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GeneralActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IAttackActions
    {
        void OnClickAttack(InputAction.CallbackContext context);
    }
    public interface IDialogueActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IFarmingActions
    {
        void OnPlant(InputAction.CallbackContext context);
        void OnHarvest(InputAction.CallbackContext context);
    }
    public interface IGeneralActions
    {
        void OnMainMenu(InputAction.CallbackContext context);
        void OnResetPlayer(InputAction.CallbackContext context);
        void OnAddExperience(InputAction.CallbackContext context);
    }
}
