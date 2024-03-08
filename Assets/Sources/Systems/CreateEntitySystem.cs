using Entitas;
using UI;
using UnityEngine;
using Zenject;

namespace Sources.Systems
{
    public class CreateEntitySystem:IInitializeSystem
    {
        readonly GameContext _context;
        
        public CreateEntitySystem(Contexts contexts)
        {
            _context = contexts.game;
        }
        
        public void Initialize()
        {
            for (int i = 0; i < 6; i++)
            {
                _context.CreateEntity().AddSprite(MenuController.IconPanel.iconSprites[i]);
            }
        }
    }
}