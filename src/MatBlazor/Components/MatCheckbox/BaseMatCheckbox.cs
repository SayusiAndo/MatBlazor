﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace MatBlazor.Components.MatCheckbox
{
    public class BaseMatCheckbox : BaseMatComponent
    {

        protected ElementRef MdcCheckBoxRef;
        protected ElementRef MdcFormFieldRef;

        public BaseMatCheckbox()
        {
            ClassMapper.Add("mdc-checkbox");
        }

        [Parameter]
        public bool Checked { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public Action<bool> CheckedChanged { get; set; }
//
//        [Parameter]
//        public bool Indeterminate { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string Value { get; set; }

        protected void ChangeHandler(UIChangeEventArgs e)
        {
            Checked = (bool) e.Value;
            CheckedChanged?.Invoke(this.Checked);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("mdc.checkbox.MDCCheckbox.attachTo", MdcCheckBoxRef);
            await Js.InvokeAsync<object>("mdc.formField.MDCFormField.attachTo", MdcFormFieldRef);
        }
    }
}