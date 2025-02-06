using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Common.Dto
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; } = false;

        public string Message { get; set; }
    }

    public class ResultDto<T> : ResultDto
    {
        public T Data { get; set; }
    }
}
