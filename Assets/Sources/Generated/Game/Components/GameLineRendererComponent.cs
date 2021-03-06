//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LineRendererComponent lineRenderer { get { return (LineRendererComponent)GetComponent(GameComponentsLookup.LineRenderer); } }
    public bool hasLineRenderer { get { return HasComponent(GameComponentsLookup.LineRenderer); } }

    public void AddLineRenderer(UnityEngine.LineRenderer newLineRenderer) {
        var index = GameComponentsLookup.LineRenderer;
        var component = CreateComponent<LineRendererComponent>(index);
        component.lineRenderer = newLineRenderer;
        AddComponent(index, component);
    }

    public void ReplaceLineRenderer(UnityEngine.LineRenderer newLineRenderer) {
        var index = GameComponentsLookup.LineRenderer;
        var component = CreateComponent<LineRendererComponent>(index);
        component.lineRenderer = newLineRenderer;
        ReplaceComponent(index, component);
    }

    public void RemoveLineRenderer() {
        RemoveComponent(GameComponentsLookup.LineRenderer);
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

    static Entitas.IMatcher<GameEntity> _matcherLineRenderer;

    public static Entitas.IMatcher<GameEntity> LineRenderer {
        get {
            if (_matcherLineRenderer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LineRenderer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLineRenderer = matcher;
            }

            return _matcherLineRenderer;
        }
    }
}
