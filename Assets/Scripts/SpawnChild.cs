using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChild : MonoBehaviour
{
    GameManager Manager;
    public GameObject Child;

    public void SetDirection(DIRECTION _direction)
    {
        transform.LookAt(transform.position + FacingDirection(_direction));
    }

    public static void CreateChild(GameObject _ObjectToSpawn, Transform _Parent, Vector3 _Location, DIRECTION _FacingDirection)
    {
        GameObject TempChildSpawner = Instantiate(_ObjectToSpawn, _Location, Quaternion.identity);
        TempChildSpawner.transform.position = _Location;
        print(TempChildSpawner.name + " Location: " + TempChildSpawner.transform.position);
        TempChildSpawner.transform.GetChild(0).GetComponent<SpawnChild>().SetDirection(_FacingDirection);
    }

    public Vector3 FacingDirection(DIRECTION _direction)
    {
        Vector3 Dir = Vector3.zero;

        switch (_direction)
        {
            case DIRECTION.Forward:
                Dir = Vector3.forward;
                break;
            case DIRECTION.Backward:
                Dir = -Vector3.forward;
                break;
            case DIRECTION.Right:
                Dir = Vector3.right;
                break;
            case DIRECTION.Left:
                Dir = -Vector3.right;
                break;
        }

        return Dir;
    }

    public void OnEnable()
    {
        Manager = GameManager.Manager;



        GameObject TempChild = Instantiate(Child, transform.parent.parent);
        TempChild.GetComponent<Children>().Target = Manager.Player;
        TempChild.transform.position = transform.GetChild(0).transform.position;
        Destroy(transform.parent.gameObject);
    }
}
