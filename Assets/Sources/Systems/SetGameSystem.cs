using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Systems
{
    public class SetGameSystem:IInitializeSystem
    {
        readonly GameContext _context;
        
        public SetGameSystem(Contexts contexts)
        {
            _context = contexts.game;
        }
        
        public void Initialize()
        {
            var e = _context.GetGroup(GameMatcher.CurrentSprite).GetEntities()[0];
            
            GameObject go = new GameObject("CurrentSprite");
            go.transform.SetParent(GameController.CurrentTransform);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            e.view.gameObject = go;
            go.Link(e);
            Image img = go.GetComponent<Image>();
            if (img == null) img = go.AddComponent<Image>();
            img.sprite = e.currentSprite.currentSprite;
            go.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        }
    }
}