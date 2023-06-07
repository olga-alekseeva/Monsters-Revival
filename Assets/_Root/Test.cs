using System.Collections.Generic;

namespace test
{
    public class Controller
    {

        public List<IHandler> handlers;

        public int a;
        public int b;
        public int c;

        public Controller(int a, int b, int c)
        {
            handlers = new List<IHandler>();
        }

        public void AddHandler(IHandler handler)
        {
            handlers.Add(handler);
        }

        private void Handle()
        {
            foreach (IHandler handler in handlers)
            {
                handler.Handle();
            }
        }

        public void Update()
        {
            if (a == b)
            {
                Handle();
            }
        }
    }

    public class Builder
    {
        public void Build()
        {
            Controller controller = new Controller(1, 2, 3);
            Handler1 handler1 = new Handler1(2, 3);
            controller.AddHandler(handler1);
            Handler1 handler2 = new Handler1(4, 4);
            controller.AddHandler(handler2);
        }
    }

    public interface IHandler
    {
        public void Handle();
    }

    public class Handler1 : IHandler
    {
        int b;
        int c;

        public Handler1(int b, int c)
        {

        }
        public void Handle()
        {
            b = b + c;
        }
    }
}