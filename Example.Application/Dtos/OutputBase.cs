namespace Example.Application.Dtos
{
    public class OutputBase
    {
        /// <summary>
        /// Error or Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// StateCode
        /// </summary>
        public int StateCode { get; set; }
    }
}