using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace SpecialControllers.Models
{
    public class RemoteService
    {
        public string GetRemoteData()
        {
            Thread.Sleep(2000);
            return "Hello from the other side of the world";
        }

        public string GetOtherRemoteData()
        {
            Thread.Sleep(4000);
            return "Mary had a little lamb";
        }
    }
}