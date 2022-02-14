using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace RestAPIs.Hubs
{
    public class MyHub : Hub
    {
        public void SendMessage(string user, string message)
        {

            IObservable<string> ob =
        Observable.Create<string>(g =>
            {
                var cancel = new CancellationDisposable();
                var source = new List<string>()
                {
                    "Allen",
                    "Frank",
                    "Hellan"
                };
              
                source.ForEach(async g =>
                {
                    await Clients.All.SendAsync("ReceiveMessage", g, "sayHello");
                    Console.WriteLine(g + "sayHello");
                }
           );
                return cancel;
            });
            IDisposable subscription = ob.Subscribe(i => Console.WriteLine(i));
         
        }
        public class DemoObserver : IObserver<int>
        {
            public void OnCompleted()
            {
                Console.WriteLine("Observable is done sending all the data.");
            }

            public void OnError(Exception error)
            {
                Console.WriteLine($"Observable failed with error: {error.Message}");
            }

            public void OnNext(int value)
            {
                Console.WriteLine($"Observable emitted : {value}");
            }
        }
        public class DemoObservable : IObservable<int>
        {
            public IDisposable Subscribe(IObserver<int> observer)
            {
                observer.OnNext(1);
                observer.OnNext(2);
                observer.OnNext(3);
                observer.OnNext(4);
                observer.OnNext(5);
                observer.OnCompleted();
                return Disposable.Empty;
            }
        }
    }
}
