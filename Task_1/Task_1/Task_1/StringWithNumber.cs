namespace Task_1
{
    abstract class StringWithNumber
    {

        string _value = string.Empty;

        public string Value { get => _value; protected set => _value = value; }

        abstract public string Result();

    }
}
