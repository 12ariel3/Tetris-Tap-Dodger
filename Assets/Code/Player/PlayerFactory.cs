namespace Assets.Code.Player
{
    public class PlayerFactory
    {
        private readonly PlayersConfiguration _configuration;


        public PlayerFactory(PlayersConfiguration configuration)
        {
            _configuration = configuration;

        }

        public PlayerBuilder Create(string id)
        {
            var prefab = _configuration.GetPlayerById(id);

            return new PlayerBuilder().FromPrefab(prefab);
        }
    }
}