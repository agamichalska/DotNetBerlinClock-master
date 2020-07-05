using TinyIoC;

namespace BerlinClock
{
    public static class Container
    {
        public static void Register()
        {
            TinyIoCContainer.Current.Register<ITimeConverter, TimeConverter>().AsSingleton();
            TinyIoCContainer.Current.Register<IClock, Clock>().AsSingleton();
        }
    }
}
