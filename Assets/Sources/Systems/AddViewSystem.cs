using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sources.Systems
{
    public class AddViewSystem:ReactiveSystem<GameEntity>
    {
        public AddViewSystem(Contexts context) : base(context.game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Sprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSprite && !entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            
            for (int i = 0; i < entities.Count; i++)
            {
                GameObject go = new GameObject("Icon View");
                go.transform.SetParent(MenuController.IconPanel.iconTransforms[i]);
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = Vector3.zero;
                entities[i].AddView(go);
                go.Link(entities[i]);

            }
        }
    }
}