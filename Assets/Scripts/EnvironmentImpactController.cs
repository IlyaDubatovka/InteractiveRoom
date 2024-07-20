using UnityEngine;

public class EnvironmentImpactController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _inventoryHolder;
    private InteractableItem _interactableItem;
    private InteractableItem _activeItem;

    private void Update()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.CompareTag(GlobalConstants.DOOR_TAG) && Input.GetKeyDown(KeyCode.E))
            {
                var door = hitInfo.transform.GetComponent<Door>();
                door.SwitchDoorState();
            }

            if (hitInfo.transform.CompareTag(GlobalConstants.INTERECTABLE_OBJECT))
            {
                var currentTransform = hitInfo.transform;
                _interactableItem = currentTransform.GetComponent<InteractableItem>();
                _interactableItem.SetFocus();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (_activeItem!=null)
                    {
                        _activeItem.ChangeLiftedStatus();
                        _activeItem = null;
                    }
                    _activeItem = _interactableItem;
                    _activeItem.ChangeLiftedStatus();
                }
            }

            else if (_interactableItem != null)
            {
                _interactableItem.RemoveFocus();
            }
        }

        if (_activeItem != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            var rb = _activeItem.GetComponent<Rigidbody>();
            _activeItem.ChangeLiftedStatus();
            rb.AddForce(_camera.transform.forward * 20,ForceMode.Impulse);
            _activeItem = null;
        }
    }
}