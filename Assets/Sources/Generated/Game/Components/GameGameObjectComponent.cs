//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameObjectComponent gameObject { get { return (GameObjectComponent)GetComponent(GameComponentsLookup.GameObject); } }
    public bool hasGameObject { get { return HasComponent(GameComponentsLookup.GameObject); } }

    public void AddGameObject(UnityEngine.GameObject newInstance) {
        var index = GameComponentsLookup.GameObject;
        var component = CreateComponent<GameObjectComponent>(index);
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceGameObject(UnityEngine.GameObject newInstance) {
        var index = GameComponentsLookup.GameObject;
        var component = CreateComponent<GameObjectComponent>(index);
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveGameObject() {
        RemoveComponent(GameComponentsLookup.GameObject);
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

    static Entitas.IMatcher<GameEntity> _matcherGameObject;

    public static Entitas.IMatcher<GameEntity> GameObject {
        get {
            if (_matcherGameObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameObject = matcher;
            }

            return _matcherGameObject;
        }
    }
}
