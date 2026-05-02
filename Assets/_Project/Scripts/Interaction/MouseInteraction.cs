using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class MouseInteraction : MonoBehaviour
{
    [SerializeField] private InputActionReference click;
    [SerializeField] private InputActionReference move;

    public bool showDebugRay;
    public float maxDistance;
    public Color debugRayColor;
    public RaycastHit _hitInfo;
    public LayerMask hitLayers;

    private void OnEnable()
    {
        click.action.performed += OnClickPerformed;
        click.action.Enable();
    }

    private void OnDisable()
    {
        click.action.performed -= OnClickPerformed;
        click.action.Disable();
    }
    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        Vector2 screenPos = move.action.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (showDebugRay)
            Debug.DrawRay(ray.origin, ray.direction * maxDistance, debugRayColor);

        bool hit = Physics.Raycast(ray, out _hitInfo, maxDistance, hitLayers);

        if(hit && _hitInfo.collider != null)
        {
            IClickable buttonController = _hitInfo.collider.GetComponent<IClickable>();
            if (buttonController != null) buttonController.OnClick();
        }
    }
}