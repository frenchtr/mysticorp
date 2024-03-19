namespace MystiCorp.Runtime.Common
{
    public class ValueChangedArgs<TValue>
    {
        public TValue From { get; set; }
        public TValue To { get; set; }
    }
}