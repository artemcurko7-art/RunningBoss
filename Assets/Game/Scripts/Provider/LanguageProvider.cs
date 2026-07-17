namespace Game.Scripts.Provider
{
    public class LanguageProvider
    {
        public bool IsAuto { get; private set; } = true;

        public void EnableAuto()
        {
            IsAuto = true;
        }

        public void DisableAuto()
        {
            IsAuto = false;
        }
    }
}