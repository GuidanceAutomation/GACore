namespace GACore.UI.Message
{
    public class DialogShutdownMessage<T> where T : System.Enum
    {
        public T DialogSource { get; }

        public DialogShutdownMessage(T dialogSource)
        {
            DialogSource = dialogSource;
        }
    }
}
