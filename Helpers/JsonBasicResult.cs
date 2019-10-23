namespace TEFL_App.Helpers
{
    internal class JsonBasicResult<T>
    {
        #region Public Properties

        public T data { get; set; }
        public string message { get; set; }
        public bool ok { get; set; }

        #endregion Public Properties
    }
}