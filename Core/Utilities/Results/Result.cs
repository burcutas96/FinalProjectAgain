using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success) 
        {
            Success = success; //Succes'i set etme işini bu metoda veriyoruz.
                             //Eğer yukarıdaki constructor çalıştırılırsa this(succes) sayesinde bu constructor da çalıştırılacak.
        }

        public bool Success { get; } //Sadece get metodu olan propertylere constructor'da değer verebiliriz, set edebiliriz.

        public string Message { get; }  //Böylelikle constructor dışında set edemeyeceğiz.
    }
}
