using Microsoft.AspNetCore.Components;
using System.Timers;
using Timer = System.Timers.Timer;

namespace BlazorWebAssembly.Pages
{
    public class TimerExampleBase :ComponentBase
    {

        protected bool isBig = false;

        protected Timer firstAnimationTimer = null;
        protected bool isStarted = false;
        protected override void OnInitialized()
        {

            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Start();
            isStarted = true;
            firstAnimationTimer = timer;
            base.OnInitialized();
        }
        public void StartStop()
        {
            if (isStarted)
            {
                firstAnimationTimer.Stop();
                isStarted = false;
            }
            else
            {
                firstAnimationTimer.Start();
                isStarted = true;
            }
        }
        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            isBig = !isBig;
            StateHasChanged();
        }
    }
}
