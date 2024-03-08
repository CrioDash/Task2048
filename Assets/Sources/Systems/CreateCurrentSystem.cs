using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Systems
{
    public class CreateCurrentSystem:IInitializeSystem
    {
        private readonly GameContext _context;
        
        public CreateCurrentSystem(Contexts context)
        {
            _context = context.game;
        }

        public void Initialize()
        {
                var e =  _context.CreateEntity();
                GameObject go = new GameObject("CurrentSprite");
                go.transform.SetParent(MenuController.IconPanel.currentTransform);
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = Vector3.zero;
                e.AddView(go);
                e.AddCurrentSprite(_context.GetGroup(GameMatcher.Sprite).GetEntities()[0].sprite.sprite);
                go.Link(e);
                
        }
    }
}