using System;

namespace Common.Utils
{
    /// <summary>
    /// Metodo result con dynamico
    /// </summary>
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public Exception Exception { get; set; }

        public Result()
        {
            Success = false;
            Message = string.Empty;
            Exception = null;
        }
    }

    /// <summary>
    /// Metodo result con genericos
    /// </summary>
    /// <typeparam name="T">tipo de dato que retornará</typeparam>
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
