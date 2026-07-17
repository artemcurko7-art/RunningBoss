using Game.Scripts.MV.Progress.Type;

namespace Game.Scripts.MV.Progress
{
    public class AddingCoinProgress
    {
        private readonly Wallet.Wallet _wallet;
        private readonly ProgressAddingReward _reward;

        public AddingCoinProgress(Wallet.Wallet wallet, ProgressAddingReward reward)
        {
            _wallet = wallet;
            _reward = reward;
        }

        public void Add(ProgressType type, int reward)
        {
            if (_reward.ReceivedData[type] == false)
            {
                _wallet.AddCoin(reward);
                _reward.Receive(type);
            }
        }
    }
}