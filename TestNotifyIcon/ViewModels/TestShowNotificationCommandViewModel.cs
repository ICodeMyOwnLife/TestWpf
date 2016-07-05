using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Threading;
using CB.Model.Prism;
using CB.Prism.Interactivity;
using CB.WPF.NotificationIcon;
using Hardcodet.Wpf.TaskbarNotification;
using Prism.Commands;


namespace TestNotifyIcon.ViewModels
{
    public class TestShowNotificationCommandViewModel: PrismViewModelBase, IDisposable
    {
        #region Fields
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        private static readonly string[] _sounds = Directory.GetFiles(@"Resources\Sounds");
        private readonly DispatcherTimer _timer;
        #endregion


        #region  Constructors & Destructor
        public TestShowNotificationCommandViewModel()
        {
            Disposer = new Disposer(this);
            _timer = new DispatcherTimer(TimeSpan.FromSeconds(10), DispatcherPriority.Normal, Timer_Tick,
                Dispatcher.CurrentDispatcher);
            StartTimerCommand =
                new DelegateCommand(StartTimer, () => !IsTimerEnabled).ObservesProperty(() => IsTimerEnabled);
            StopTimerCommand =
                new DelegateCommand(StopTimer, () => _timer.IsEnabled).ObservesProperty(() => IsTimerEnabled);
        }
        #endregion


        #region  Commands
        public ICommand StartTimerCommand { get; }
        public ICommand StopTimerCommand { get; }
        #endregion


        #region  Properties & Indexers
        public Disposer Disposer { get; }

        public bool IsTimerEnabled
        {
            get { return _timer.IsEnabled; }
            set { _timer.IsEnabled = value; }
        }

        public BalloonNotifyRequestProvider NotifyRequestProvider { get; } = new BalloonNotifyRequestProvider();

        public double Seconds
        {
            get { return _timer.Interval.TotalSeconds; }
            set { _timer.Interval = TimeSpan.FromSeconds(value); }
        }

        public WindowRequestProvider WindowRequestProvider { get; } = new WindowRequestProvider();
        #endregion


        #region Methods
        public void Dispose()
        {
            _timer.Stop();
        }

        public void StartTimer()
            => EnableTimer(true);

        public void StopTimer()
            => EnableTimer(false);
        #endregion


        #region Event Handlers
        private void Timer_Tick(object sender, EventArgs e)
            =>
                NotifyRequestProvider.Notify("Alarm", $"It's {DateTime.Now.ToShortTimeString()}", GetRandomSymbol(),
                    GetRandomSound());
        #endregion


        #region Implementation
        private void EnableTimer(bool isEnabled)
        {
            _timer.IsEnabled = isEnabled;
            NotifyPropertiesChanged(nameof(IsTimerEnabled));
        }

        private static string GetRandomSound()
            => _sounds[_random.Next(_sounds.Length)];

        private static BalloonIcon GetRandomSymbol()
        {
            switch (_random.Next(3))
            {
                case 0:
                    return BalloonIcon.Error;
                case 1:
                    return BalloonIcon.Info;
                default:
                    return BalloonIcon.Warning;
            }
        }
        #endregion
    }
}