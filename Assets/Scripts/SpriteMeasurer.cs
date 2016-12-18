using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMeasurer : MonoBehaviour
{
    void Start()
    {
        Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector3 world_size = local_sprite_size;
        world_size.x *= transform.lossyScale.x;
        world_size.y *= transform.lossyScale.y;
        Vector3 screen_size = 0.5f * world_size / Camera.main.orthographicSize;
        screen_size.y *= Camera.main.aspect;

        Vector3 in_pixels = new Vector3(screen_size.x * Camera.main.pixelWidth, screen_size.y * Camera.main.pixelHeight, 0) * 0.5f;

        Debug.Log(string.Format("World size: {0}, Screen size: {1}, Pixel size: {2}", world_size, screen_size, in_pixels));
    }
}
