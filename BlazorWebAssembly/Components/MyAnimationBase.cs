using BlazorAnimation;
using BlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor.Interop;

namespace BlazorWebAssembly.Components
{
    public class MyAnimationBase : ComponentBase
    {
        [Inject]
        public IScrollInfoService ScrollInfoService { get; set; } = default!;
        [Inject]
        public IJSRuntime JSRuntime { get; set; } = default!;
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public AnimationEffect VisualEffect { get; set; } = Effect.BounceIn;
        [Parameter]
        public string Style { get; set; } = "";
        public bool Enabled { get; set; } = false;
        public BoundingClientRect? BoundingClientRect { get; set; } = default;
        protected ElementReference? ElementReference { get; set; }

        protected override void OnInitialized()
        {
            EventHandler<int> eventHandler = new EventHandler<int>(async (s, e) => await ScrollInfoService_OnScroll(s, e));
            ScrollInfoService.OnScroll += eventHandler;
            base.OnInitialized();
            
        }

        private async Task<int> ScrollInfoService_OnScroll(object? sender, int e)
        {

            BoundingClientRect = await JSRuntime.InvokeAsync<BoundingClientRect>("MyDOMGetBoundingClientRect", new object[] { ElementReference });
            if (BoundingClientRect == null)
            {
                return default;
            }
            var yValue = ScrollInfoService.YValue;
            if (yValue > BoundingClientRect.Top - 600)
            {
                Enabled = true;
            }
            await InvokeAsync(() => StateHasChanged());
            return default;
        }
        public void Dispose()
        {
            //ScrollInfoService.OnScroll -= ScrollInfoService_OnScroll;
        }
    }


}
