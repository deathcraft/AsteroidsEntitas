using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Sources.Systems
{
    public class InstantiateAssetSystem : ReactiveSystem<GameEntity>
    {
        private Contexts contexts;

        public InstantiateAssetSystem(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameAsset.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameAsset;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                Object prefab = Resources.Load(entity.gameAsset.resourceLocation);
                GameObject instance = (GameObject) GameObject.Instantiate(prefab);
                instance.Link(entity, contexts.game);
                entity.AddGameObject(instance);
            }
        }
    }
}