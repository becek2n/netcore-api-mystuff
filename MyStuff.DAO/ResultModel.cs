using System;

namespace MyStuff.DAO
{
    public class ResultModel<T>
    {
        public ResultModel()
        {

        }
        public ResultModel(bool IsSuccess)
        {
            this.ResponseCode = (IsSuccess) ? "200" : "400";
            this.ResponseMessage = (IsSuccess) ? "success" : "failed";
        }

        public ResultModel<T> SetSuccess(string message, T value = default(T))
        {
            this.ResponseCode = "200";
            this.ResponseMessage = message != null ? message : "success";
            this.ResponseData = value;
            return this;
        }

        public ResultModel<T> SetFailed(string message, string statusCode = "400", T value = default(T), Exception Ex = null)
        {
            this.ResponseCode = "400";
            this.ResponseMessage = message != null ? message.Replace("'", "") : "failed";
            this.ResponseData = value;
            //this.ValException = Ex;
            return this;
        }

        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public T ResponseData { get; set; }
        //public Exception ValException { get; set; }
    }

    public class APIPaging<T>
    {
        public int recordTotal { get; set; }
        public int totalPage { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public T data { get; set; }
    }
}
