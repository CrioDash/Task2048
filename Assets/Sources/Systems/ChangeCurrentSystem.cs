using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Systems
{
    public class ChangeCurrentSystem:ReactiveSystem<GameEntity>
    {
        public ChangeCurrentSystem(Contexts context) : base(context.game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CurrentSprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCurrentSprite && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameObject go = entities[0].view.gameObject;
            Image img = go.GetComponent<Image>();
            if (img == null)
            {
                img = go.AddComponent<Image>();
                img.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 350);
            }
            img.sprite = entities[0].currentSprite.currentSprite;
        }
    }
}