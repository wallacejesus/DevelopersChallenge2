using System;
using System.Collections.Generic;
using System.Text;

namespace NIBO.Challenge.Infra.Helpers
{
    public class MessageReturn<TEntity>
    {
        public TypeReturn Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public TEntity Data { get; set; }

        public MessageReturn(TypeReturn typeReturn,string message,TEntity data, string title = null)
        {
            this.Type = typeReturn;
            this.Message = message;
            this.Data = data;
            this.Title = title;
        }
    }
    public class MessageReturn
    {
        public TypeReturn Type { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public MessageReturn(TypeReturn typeReturn, string message, string title = null)
        {
            this.Type = typeReturn;
            this.Message = message;
            this.Title = title;
        }
    }
    public enum TypeReturn
    {
        SUCCESS = 1,
        WARNING = 2,
          ERROR = 3
    }
}
