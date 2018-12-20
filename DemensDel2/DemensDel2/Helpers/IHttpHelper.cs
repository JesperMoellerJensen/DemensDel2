using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Helpers
{
    public interface IHttpHelper
    {
        Uri baseUri { get; set; }
        T Get<T>(string query);
        bool Post<T>(T data, string query);
        bool Delete(string query);
    }
}
