using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class BulletCollisionSystem : IExecuteSystem
    {
        private readonly Contexts contexts;
        private IGroup<GameEntity> asteroids;
        private IGroup<GameEntity> bullets;

        public BulletCollisionSystem(Contexts contexts)
        {
            this.contexts = contexts;

            asteroids = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Asteroid, GameMatcher.GameObject));
            bullets = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Bullet, GameMatcher.GameObject));
        }

        public void Execute()
        {
            foreach (var bullet in bullets)
            {
                foreach (var asteroid in asteroids)
                {
                    if (BulletHit(bullet, asteroid))
                    {
                        Split(asteroid);
                        Destroy(bullet);
                    }
                }
            }
        }

        private void Destroy(GameEntity bullet)
        {
            bullet.isDestroyed = true;
        }

        private void Split(GameEntity asteroid)
        {
            if (asteroid.asteroidSize.value / 2f > 0.2f)
            {
                var splitCoeff = GameConfiguration.INSTANCE.asteroidSplitCoeff;
                CreateAsteroid(asteroid.position.value, asteroid.asteroidSize.value * splitCoeff);
                CreateAsteroid(asteroid.position.value, asteroid.asteroidSize.value * splitCoeff);                
            }
            asteroid.isDestroyed = true;
        }

        private void CreateAsteroid(Vector3 pos, float size)
        {
            var newAsteroid = contexts.game.CreateEntity();
            newAsteroid.isAsteroid = true;
            newAsteroid.AddAsteroidSize(size);
            newAsteroid.AddPosition(pos);
        }

        private bool BulletHit(GameEntity bullet, GameEntity asteroid)
        {
            Vector3 bulletPosition = bullet.position.value;
            return asteroid.lineRenderer.lineRenderer.bounds.Contains(bulletPosition);
        }
    }
}