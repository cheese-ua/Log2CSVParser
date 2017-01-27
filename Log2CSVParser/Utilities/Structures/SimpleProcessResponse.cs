namespace Log2CSVParser.Utilities.Structures
{
    public class SimpleProcessResponse
    {
        public string message { get; set; }
        public bool isOk { get; set; }

        private SimpleProcessResponse(string message, bool isOk)
        {
            this.isOk = isOk;
            this.message = message;
        }

        public static SimpleProcessResponse Success(string message)
        {
            return new SimpleProcessResponse(message, true);
        }

        public static SimpleProcessResponse Fail(string message)
        {
            return new SimpleProcessResponse(message, false);
        }

        public override string ToString()
        {
            return $"{isOk}: {message}";
        }
    }
}
