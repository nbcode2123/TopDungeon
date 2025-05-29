
using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public KeyCode ActiveObject = KeyCode.H;
    public KeyCode Attack = KeyCode.Mouse0;
    public KeyCode ChangeWeapon = KeyCode.G;
    public KeyCode TakeWeapon = KeyCode.F;
    public KeyCode ActiveSkill = KeyCode.R;

    public event Action OnAttack;
    public event Action OnChangeWeapon;
    public event Action OnSkill;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)

        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Attack))
        {
            OnAttack?.Invoke();
        }
        if (Input.GetKey(ChangeWeapon))
        {
            OnChangeWeapon?.Invoke();
        }
        if (Input.GetKey(ActiveSkill))
        {
            OnSkill?.Invoke();
        }


    }
    public void RegisterOnAttack(Action callback)
    {
        OnAttack += callback;
    }
    public void RegisterOnChangeWeapon(Action callback)
    {
        OnChangeWeapon += callback;
    }
    public void RegisterOnSkill(Action callback)
    {
        OnSkill += callback;
    }
    public void UnRegisterOnAttack(Action callback)
    {
        OnAttack -= callback;
    }
    public void UnRegisterOnChangeWeapon(Action callback)
    {
        OnChangeWeapon -= callback;
    }
    public void UnRegisterOnSkill(Action callback)
    {
        OnSkill -= callback;
    }

}
