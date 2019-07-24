using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public int currentTower;
   
    void Update()
    {
        // if mouse button pressed
        if (Input.GetMouseButtonDown(0))
        {
            // peform raycast
            RaycastHit hit;
            Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(MouseRay, out hit))
            {
                // if hit placeable and not taken
                Placeable p = hit.collider.GetComponent<Placeable>();
                if (p && !p.isOccupied)
                {
                    // place tower
                    SpawnTower(hit.transform.position);
                    p.isOccupied = true;

                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            currentTower++;
        }
    }
    public void SpawnTower(Vector3 position)
    {
       
        // load tower resource
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/Tower_"+ currentTower);
        // spawn a new instance of tower
        Instantiate(towerPrefab, position, Quaternion.identity);
        
    }
}
