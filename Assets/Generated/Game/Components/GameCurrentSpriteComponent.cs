//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CurrentSpriteComponent currentSprite { get { return (CurrentSpriteComponent)GetComponent(GameComponentsLookup.CurrentSprite); } }
    public bool hasCurrentSprite { get { return HasComponent(GameComponentsLookup.CurrentSprite); } }

    public void AddCurrentSprite(UnityEngine.Sprite newCurrentSprite) {
        var index = GameComponentsLookup.CurrentSprite;
        var component = (CurrentSpriteComponent)CreateComponent(index, typeof(CurrentSpriteComponent));
        component.currentSprite = newCurrentSprite;
        AddComponent(index, component);
    }

    public void ReplaceCurrentSprite(UnityEngine.Sprite newCurrentSprite) {
        var index = GameComponentsLookup.CurrentSprite;
        var component = (CurrentSpriteComponent)CreateComponent(index, typeof(CurrentSpriteComponent));
        component.currentSprite = newCurrentSprite;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentSprite() {
        RemoveComponent(GameComponentsLookup.CurrentSprite);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCurrentSprite;

    public static Entitas.IMatcher<GameEntity> CurrentSprite {
        get {
            if (_matcherCurrentSprite == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentSprite);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentSprite = matcher;
            }

            return _matcherCurrentSprite;
        }
    }
}
