using UnityEngine;

public class ProtectorSpawner : MonoBehaviour
{
    const string PARENT_NAME = "Protectors";
    // [SerializeField] Protector protector;
    Protector protector;
    GameObject parent;

    private void Start()
    {
        CreateParent();
    }

    // called only when we are inside collider
    private void OnMouseDown()
    {
        // SpawnProtector(GetClickedSquare());
        // Debug.Log("Mouse clicked");
        placeProtectorAt(GetClickedSquare());
    }

    private void CreateParent()
    {
        parent = GameObject.Find(PARENT_NAME);
        if (!parent)
        {
            parent = new GameObject(PARENT_NAME);
        }
    }

    private void SpawnProtector(Vector2 roundedPos)
    {
        // "as" operator returns the object when they are compatible with the given type and return null if the conversion is not possible instead of raising an exception
        // GameObject newProtector = Instantiate(protector, transform.position, Quaternion.identity) as GameObject;
        if (!protector) return;
        Protector newProtector = Instantiate(protector, roundedPos, Quaternion.identity) as Protector;
        newProtector.transform.parent = parent.transform;
        // Debug.Log(worldPos);
    }

    private Vector2 GetClickedSquare()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        // convert screen position to world position
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    public void SetSelectedProtector(Protector protectorToSelect)
    {
        protector = protectorToSelect;
    }

    public void placeProtectorAt(Vector2 gridPos)
    {
        if (!protector) return;
        var resDisplay = FindObjectOfType<ResourceDisplay>();
        int protectorCost = protector.GetResCost();
        if (resDisplay.HaveEnoughRes(protectorCost))
        {
            SpawnProtector(gridPos);
            resDisplay.SpendRes(protectorCost);
        }
    }
}
