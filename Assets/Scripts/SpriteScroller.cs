using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{  
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;



    // ▬▬▬▬▬▬▬▬▬▬ "Awake()" Method d ▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Getting" the "Sprite Renderer" Component ▼
        material = GetComponent<SpriteRenderer>().material;
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Update()" Method d ▬▬▬▬▬▬▬▬▬▬
    void Update()
    {
        // ▼ "Setting" the "Material Offset" ▼
        offset = moveSpeed * Time.deltaTime;
        
        // ▼ "Moving" the "Material Offset" ▼
        material.mainTextureOffset += offset;
    }
}
