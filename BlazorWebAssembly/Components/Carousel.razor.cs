using Microsoft.AspNetCore.Components;

namespace BlazorWebAssembly.Components
{
    public class CarouselBase : ComponentBase
    {

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
  
    }
}
