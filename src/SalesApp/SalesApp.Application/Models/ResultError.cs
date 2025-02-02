namespace SalesApp.Application.Models
{
    public class ResultError
    {
        public string type { get; set; }
        public string error { get; set; }
        public string detail { get; set; }

        public ResultError(string type, string error)
        {
            this.type = type;
            this.error = error;
        }

        public ResultError(string type, string error, string detail)
        {
            this.type = type;
            this.error = error;
            this.detail = detail;
        }

        public ResultError(Exception exception)
        {
            this.type = InternalServerError;
            this.error = exception.Message;
            this.detail = exception.StackTrace;
        }

        public ResultError AddDetail(string detail)
        {
            return new ResultError(this.type, this.error, detail);
        }



        public const string InternalServerError = "InternalServerError";
        public const string ResourceNotFound = "ResourceNotFound";
        public const string ValidationError = "ValidationError";
    }
}
