using UnityEngine;

public class BoardDraggable : MonoBehaviour
{
    public float moveForwardBy;
    public float deadZone;

    private bool _lockX;
    private bool _lockY;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnMouseDown()
    {
        _transform.position -= new Vector3(0, 0, moveForwardBy);
    }

    private void OnMouseDrag()
    {
        if (Camera.main == null) return;
        var screenToWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!_lockX && IsBetweenRange(screenToWorldPoint.x, _transform.position.x, deadZone))
        {
            _lockY = true;
        }
        else if (!_lockY && IsBetweenRange(screenToWorldPoint.y, _transform.position.y, deadZone))
        {
            _lockX = true;
        }

        if (_lockX == false && _lockY == false) return;

        var position = _transform.position;
        var xPosition = _lockX ? position.x : screenToWorldPoint.x;
        var yPosition = _lockY ? position.y : screenToWorldPoint.y;

        transform.position = new Vector3(xPosition, yPosition, position.z);
    }

    private bool IsBetweenRange(float point, float relativeTo, float range)
    {
        return point > relativeTo + range || point < relativeTo - range;
    }

    private void OnMouseUp()
    {
        _transform.position += new Vector3(0, 0, moveForwardBy);
        _lockX = false;
        _lockY = false;
    }
}