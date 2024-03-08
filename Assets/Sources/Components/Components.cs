using Entitas;
using UnityEngine;

    [Game]
    public class ViewComponent : IComponent
    {
        public GameObject gameObject;
    }

    [Game]
    public class SpriteComponent : IComponent
    {
        public Sprite sprite;
    }

    [Game]
    public class CurrentSpriteComponent : IComponent
    {
        public Sprite currentSprite;
    }


   
    