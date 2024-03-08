using System.Collections.Generic;
using Entitas;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Systems
{
    public class RenderImageSystem:ReactiveSystem<GameEntity>
    {
        public RenderImageSystem(Contexts context) : base(context.game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Sprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSprite && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                GameObject go = e.view.gameObject;
                
                Image img = go.GetComponent<Image>();
                if (img == null) img = go.AddComponent<Image>();
                
                go.AddComponent<IconMouseEvents>();
                
                img.sprite = e.sprite.sprite;
                go.GetComponent<RectTransform>().sizeDelta = new Vector2(240, 240);
            }
        }
    }
}