using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropItemTest : UIDragDropItem
{

    /// <summary>
    /// Prefab object that will be instantiated on the DragDropSurface if it receives the OnDrop event.
    /// </summary>


    //public UIAtlas atlas;
    //public UISprite sprite;

    //public UISprite targetSprite;

    /// <summary>
    /// Drop a 3D game object onto the surface.
    /// </summary>

    protected override void OnDragDropRelease(GameObject surface)
    {

        base.OnDragDropRelease(surface);
    }
}
