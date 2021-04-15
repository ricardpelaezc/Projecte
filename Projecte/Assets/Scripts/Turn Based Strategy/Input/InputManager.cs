using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Entity SelectedEntity;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var entity = SelectEntity();
            if (!(entity is null))
            {
                if (IsEntityInList(EntityManager.GetActiveAllies(entity), entity))
                    SelectedEntity = entity;
            }
        }
    }

    private static Entity SelectEntity()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        var hitCollider = hit.collider;
        if (hitCollider != null)
        {
            var gameObject = hitCollider.gameObject;
            if (!(gameObject.GetComponent("Entity") as Entity is null))
            {
                return gameObject.GetComponent<Entity>();
            }
        }
        return null;
    }
}
