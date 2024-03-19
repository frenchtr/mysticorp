namespace MystiCorp.Runtime
{
    public class MagicManager : GameManager.Manager
    {
        private float magicAmount;

        public event System.Action MagicAmountChanged;

        public float MagicAmount
        {
            get => magicAmount;
            set
            {
                magicAmount = value;
                MagicAmountChanged?.Invoke();
            }
        }
    }
}
