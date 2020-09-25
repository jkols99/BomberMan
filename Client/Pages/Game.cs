using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BomberMan.Client.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BomberMan.Client.Pages
{
    public partial class Game
    {
        [Parameter]
        public string UserNick { get; set; }
        
        [Parameter]
        public string Level { get; set; }
        
        [Inject] private IJSRuntime JSRuntime {get; set; }
        
        [Inject] private GameUniverse GameUniverse { get; set; }

        [Inject] private HttpClient Http { get; set; }
        
        private char[][] CharMap { get; set; }
        
        private List<GameElement> ToRender { get; set; } = new List<GameElement>();
        private string KeyPressed { set; get; } = "";
        
        protected ElementReference GameDiv;
        
        private bool _isFocusSet = false;

        private void Move(KeyboardEventArgs args)
        {
            KeyPressed = args.Code;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!_isFocusSet)
            {
                await JSRuntime.InvokeVoidAsync("SetFocusToElement", GameDiv);
                // set focus only once
                _isFocusSet = true;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            CharMap = await Http.GetFromJsonAsync<char[][]>("DataFetcher/LoadMap?level=" + Level);
            ToRender = GameLogic.CreateMap(CharMap);
        }
    }
}