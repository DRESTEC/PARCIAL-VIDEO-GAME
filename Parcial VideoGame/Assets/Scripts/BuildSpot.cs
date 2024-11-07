using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    private bool isOccupied = false; // Variable para verificar si el punto está ocupado

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetOccupied(bool occupied)
    {
        isOccupied = occupied;
    }
}
