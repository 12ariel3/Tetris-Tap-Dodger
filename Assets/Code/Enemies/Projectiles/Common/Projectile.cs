namespace Assets.Code.Enemies.Projectiles.Common
{
    public interface Projectile
    {
        string Id { get; }

        void OnDamageReceived(bool isDeath);
    }
}