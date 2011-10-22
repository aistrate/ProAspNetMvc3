using System.Threading;

namespace SpecialControllers.Models {
    public class RemoteService {

        public string GetRemoteData() {
            Thread.Sleep(10000);
            return "Hello from the other side of the world";
        }
    }
}