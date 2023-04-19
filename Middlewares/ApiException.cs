using System.Net;

namespace geo_service.Middlewares
{
    public class ApiException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="MsgKey">Ключ ошибки</param>
        /// <param name="message">Сообщение</param>
        /// <param name="httpStatusCode">Http статус</param>
        public ApiException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            this.StatusCode = httpStatusCode;
        }

        /// <summary>
        /// Http status
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}