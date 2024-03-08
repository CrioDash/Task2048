using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class IconMouseEvents:MonoBehaviour,IPointerClickHandler
    {
        
        public void OnPointerClick(PointerEventData eventData)
        {
            var e =Contexts.sharedInstance.game.GetGroup(GameMatcher.CurrentSprite).GetEntities()[0];
            e.ReplaceCurrentSprite(eventData.pointerClick.GetComponent<Image>().sprite);
            
        }
        
    }
}