using System.Collections.Generic;
using UnityEngine;

public class OutlineWalls : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    static int outlineLayer;
    int deviceLayer;
    int layerMask;
    GameObject device;
    List<GameObject> devices;
    private void Awake()
    {
        outlineLayer = LayerMask.NameToLayer("Outlines");
        deviceLayer = LayerMask.NameToLayer("Devices");
        layerMask = 1 << deviceLayer;
    }
    public static void OutlineWall(MoveWall[] walls)
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].gameObject.layer = outlineLayer;
        }
    }
    public static void ResetWallsLayer(MoveWall[] walls)
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].gameObject.layer = 0;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (device != null)
            {
                device.GetComponent<IOutlineWalls>().StopOutline();
            }
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f, LayerMask.GetMask("Devices")))
            {
                device = raycastHit.collider.gameObject;
                if (device != null)
                {
                    device.GetComponent<IOutlineWalls>().OutlineWalls();
                }
            }
        }
    }

}
