using Game.Scripts.Menu.Game.Ended.Subscriber;
using Game.Scripts.MV.Quest.QuestData;
using Game.Scripts.MV.Quest.Type;
using Game.Scripts.Player.Coin;
using YG;

namespace Game.Scripts.Menu.Game.Ended
{
    public class AddingCoinQuestGameEnded : GameEndedSubscriber
    {
        private readonly QuestData[] _dates;
        private readonly ICoinData _coinData;

        public AddingCoinQuestGameEnded(IGame game, QuestData[] dates, ICoinData coinData)
            : base(game)
        {
            _dates = dates;
            _coinData = coinData;
        }

        protected override void OnGameEnded()
        {
            const QuestType type = QuestType.Money;

            foreach (var data in _dates)
            {
                if (data.Quests.ContainsKey(type))
                {
                    foreach (var coin in _coinData.Coins.Values)
                    {
                        data.Quests[type].Add(coin.Value);
                        YG2.saves.QuestStorage(data.Quests[type]);
                    }
                }
            }
        }
    }
}