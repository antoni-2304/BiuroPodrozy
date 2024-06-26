﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BiuroPodrozy.Data.Utilities.TagHelpers
{
    [HtmlTargetElement("input", Attributes = PlaceholderAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class InputPlaceholderTagHelper : TagHelper
    {
        private const string PlaceholderAttributeName = "asp-placeholder-for";

        public InputPlaceholderTagHelper(IHtmlGenerator generator) : base()
        {
        }

        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName(PlaceholderAttributeName)]
        public ModelExpression Placeholder { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            var placeholder = GetPlaceholder(Placeholder.ModelExplorer);
            TagHelperAttribute placeholderAttribute;

            if (!output.Attributes.TryGetAttribute("placeholder", out placeholderAttribute))
            {
                output.Attributes.Add(new TagHelperAttribute("placeholder", placeholder));
            }
        }

        private string GetPlaceholder(ModelExplorer modelExplorer)
        {
            string placeholder;
            placeholder = modelExplorer.Metadata.Placeholder;

            if (String.IsNullOrWhiteSpace(placeholder))
            {
                placeholder = modelExplorer.Metadata.GetDisplayName();
            }

            return placeholder;
        }
    }
}
