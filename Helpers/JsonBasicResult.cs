namespace TEFL_App.Helpers
{
    public class JsonBasicResult<T>
    {
        public JsonBasicResult() { }
        public JsonBasicResult(bool _ok, T _data, string _message)
        {
            this.data = _data;
            this.ok = _ok;
            this.message = _message;
        }
        #region Public Properties

        public T data { get; set; }
        public string message { get; set; }
        public bool ok { get; set; }

        #endregion Public Properties
    }
}