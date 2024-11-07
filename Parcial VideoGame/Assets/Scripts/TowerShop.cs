using UnityEngine;

public class TowerShop : MonoBehaviour
{
    public GameObject towerPrefab; // Prefab de la torre a colocar
    public int towerCost = 50; // Costo de la torre
    private int playerMoney = 100; // Dinero inicial del jugador
    private bool isPlacingTower = false;

    void Update()
    {
        if (isPlacingTower && Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("BuildSpot"))
            {
                BuildSpot buildSpot = hit.collider.GetComponent<BuildSpot>();
                if (buildSpot != null && !buildSpot.IsOccupied())
                {
                    TryPlaceTower(hit.collider.gameObject);
                    buildSpot.SetOccupied(true);
                    isPlacingTower = false; // Desactiva el modo de colocación después de colocar la torre
                }
                else
                {
                    Debug.Log("El punto de construcción ya está ocupado.");
                }
            }
        }
    }

    public void StartPlacingTower()
    {
        if (playerMoney >= towerCost)
        {
            isPlacingTower = true;
            Debug.Log("Modo de colocación de torre activado. Haz clic en un punto de construcción.");
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar la torre.");
        }
    }

    public void TryPlaceTower(GameObject buildSpot)
    {
        playerMoney -= towerCost;
        Instantiate(towerPrefab, buildSpot.transform.position, Quaternion.identity);
    }
}
