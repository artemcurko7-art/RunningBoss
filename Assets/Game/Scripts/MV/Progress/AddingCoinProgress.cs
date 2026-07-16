public class AddingCoinProgress 
{
    private readonly Wallet _wallet;
    private readonly ProgressAddingReward _reward;
    
    public AddingCoinProgress(Wallet wallet, ProgressAddingReward reward)
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