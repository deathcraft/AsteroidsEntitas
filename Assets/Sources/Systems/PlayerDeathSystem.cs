using Entitas;

namespace Sources.Systems
{
    public class PlayerDeathSystem : IExecuteSystem
    {
        private readonly Contexts contexts;
        private IGroup<GameEntity> asteroids;
        private IGroup<GameEntity> players;


        public PlayerDeathSystem(Contexts contexts)
        {
            this.contexts = contexts;
            asteroids = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Asteroid, GameMatcher.GameObject));
            players = contexts.game.GetGroup(GameMatcher.Player);
        }

        public void Execute()
        {
            foreach (var asteroid in asteroids)
            {
                foreach (var player in players)
                {
                    if (CollisionWithPlayer(player, asteroid))
                    {
                        contexts.game.playerEntity.isDestroyed = true;
                    }
                }
            }
        }

        private bool CollisionWithPlayer(GameEntity player, GameEntity asteroid)
        {
            var playerPosition = player.position.value;
            var asteroidLines = asteroid.lineRenderer.lineRenderer;
            return asteroidLines.bounds.Contains(playerPosition);
        }
    }
}