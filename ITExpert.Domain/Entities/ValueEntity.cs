namespace ITExpert.Domain.Entities
{

    public class ValueEntity
    {
        // Не наследую сущность от базовой, так как по ТЗ она не имеет идентификатора

        private ValueEntity(string Value, int Code)
        {
            this.Value = Value;
            this.Code = Code;
        }

        public int Row { get; private set; }
        public int Code { get; private set; }
        public string Value { get; private set; }

        public static ValueEntity Create(int Code, string Value)
        {
            //TODO: добавить проверки
            ValueEntity entity = new ValueEntity(Value, Code);
            return entity;
        }

        public ValueEntity SetRow(int row)
        {
            this.Row = row;
            return this;
        }
    }
}
