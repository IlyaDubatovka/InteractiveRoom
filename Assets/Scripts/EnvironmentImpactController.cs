
using UnityEngine;

public class EnvironmentImpactController : MonoBehaviour
{
    [SerializeField]private Camera _camera;
    [SerializeField] private Transform _inventoryHolder;
    private Outline _outline;
    private void Update()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray,out hitInfo))
        {
            if (hitInfo.transform.CompareTag(GlobalConstants.DOOR_TAG)&&Input.GetKeyDown(KeyCode.E))
            {
                var door = hitInfo.transform.GetComponent<Door>();
                door.SwitchDoorState();
                Debug.Log(hitInfo,gameObject);
            }

            // if (hitInfo.transform.CompareTag(GlobalConstants.INTERECTABLE_OBJECT))
            // {
            //     Debug.Log(hitInfo,gameObject);
            //     _outline = hitInfo.transform.GetComponent<Outline>();
            //     _outline.OutlineWidth = 5;
            // }
            // else
            // {
            //     _outline.OutlineWidth = 0;
            // }
        }
    }
}
