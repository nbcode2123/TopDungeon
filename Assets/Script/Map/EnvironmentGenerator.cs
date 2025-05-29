using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public void CreateArchitecture(GameObject roomObject, GameObject architecture, Vector2 centerRoomPosition)
    {
        GameObject _tempObject = Instantiate(architecture, new Vector3(centerRoomPosition.x, centerRoomPosition.y, 0), Quaternion.identity);
        _tempObject.transform.SetParent(roomObject.transform);
    }
    public void RandomArchitectureCreate(GameObject roomObject, Vector2 centerRoomPosition)
    {
        var _architecture = EnvironmentManager.Instance.TilemapAssetConcept.RandomArchitecture();
        CreateArchitecture(roomObject, _architecture, centerRoomPosition);
    }
}
