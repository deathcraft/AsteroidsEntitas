using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class CreateAsteroidsSystem : IInitializeSystem
    {
        private readonly Contexts contexts;

        public CreateAsteroidsSystem(Contexts contexts)
        {
            this.contexts = contexts;
            var asteroidsGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Asteroid, GameMatcher.GameObject, GameMatcher.AsteroidSize));
            asteroidsGroup.OnEntityAdded += RandomizeLines;
        }

        private void RandomizeLines(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
        {
            var instance = entity.gameObject.instance;
            var lineRenderer = instance.GetComponent<LineRenderer>();

            float angleStep = Mathf.PI / lineRenderer.positionCount * 2; 
            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                Vector3 pos = Vector3.zero;
                float size = entity.asteroidSize.value;
                pos.x = Mathf.Cos(angleStep * i) * size * Random.Range(0.4f, 1f);
                pos.y = Mathf.Sin(angleStep * i) * size * Random.Range(0.4f, 1f);
                lineRenderer.SetPosition(i, pos);
            }
        }

        private static float RandomAsteroidSize()
        {
            return Random.Range(GameConfiguration.INSTANCE.asteroidMinSize,
                GameConfiguration.INSTANCE.asteroidMaxSize);
        }

        public void Initialize()
        {
            for (int i = 0; i < GameConfiguration.INSTANCE.asteroidNum; i++)
            {
                var asteroid = contexts.game.CreateEntity();
                asteroid.isAsteroid = true;
                asteroid.AddGameAsset(GameConfiguration.INSTANCE.asteroidAssetPath);
                asteroid.AddPosition(RandomScreenPoistion());
                var initialSpeed = Random.insideUnitSphere * GameConfiguration.INSTANCE.asteroidSpeedCoeff;
                initialSpeed.z = 0;
                asteroid.AddGameSpeed(initialSpeed, 1f);
                asteroid.AddRotation(0f);
                asteroid.AddAcceleration(0);    
                asteroid.AddAsteroidSize(RandomAsteroidSize());
            }
        }

        private Vector3 RandomScreenPoistion()
        {
            Vector3 randomPoint = new Vector3(Random.value, Random.value);
            randomPoint.z = Camera.main.WorldToViewportPoint(Vector3.zero).z;
            var viewportToWorldPoint = Camera.main.ViewportToWorldPoint(randomPoint);
            viewportToWorldPoint.z = 0;
            return viewportToWorldPoint;
        }
    }
}