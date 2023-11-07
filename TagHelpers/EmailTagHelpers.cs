﻿
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KitsGade.TagHelpers
{
    [HtmlTargetElement("email")]
    public class EmailTagHelpers : TagHelper
    {
        public string Endereco { get; set; }
        public string Conteudo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Endereco);
            output.Content.SetContent(Conteudo);
        }
    }
}
