﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Tags
{
    public enum TagAttributes
    {
        [Description("id")]
        Id,

        [Description("name")]
        Name,

        [Description("class")]
        Class,

        [Description("value")]
        Value,

        [Description("onclick")]
        OnClick,

        [Description("src")]
        Src,

        [Description("title")]
        Title,

        [Description("href")]
        Href,

        [Description("type")]
        Type,

        [Description("style")]
        Style,

        [Description("rel")]
        Rel,

        [Description("ng-class")]
        NgClass,

        [Description("local-string")]
        LocalString,

        [Description("alt")]
        Alt
    }
}