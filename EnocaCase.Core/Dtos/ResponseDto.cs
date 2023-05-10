using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnocaCase.Core.Dtos
{
    public class ResponseDto<T>
    {

        public T Data { get; set; } 

        public List<string> Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public static ResponseDto<T> Success(T Data, int StatusCode) { 
        
        return new ResponseDto<T> { StatusCode= StatusCode, Data = Data, };    
        
        }


        public static ResponseDto<T>Fail(int  StatusCode, List<String>errors) {

            return new ResponseDto<T> { StatusCode = StatusCode, Errors = errors };
        }

       
        public static ResponseDto<T> Fail (int StatusCode, String errors) { 
        
        return new ResponseDto<T> { StatusCode=StatusCode, Errors = new List<String> { errors }};
        }

    }
}
