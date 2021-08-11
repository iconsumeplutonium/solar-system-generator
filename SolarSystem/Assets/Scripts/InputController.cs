using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Controls controls;
    public UIManager manager;

    Vector2 mPos;


    private void Awake() {
        controls = new Controls();
    }

    private void OnEnable() {
        controls.User.Enable();
        controls.User.MouseX.performed += ctx => mPos.x = ctx.ReadValue<float>();
        controls.User.MouseY.performed += ctx => mPos.y = ctx.ReadValue<float>();

        controls.User.LeftClick.performed += ctx => manager.OnLeftClick(mPos);
    }

    private void Update() {
        manager.mousePos = mPos;
    }

}
