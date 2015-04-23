using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using WEBUIautomation.Extensions;

namespace WEBUIautomation.WebElement
{
    public partial class WebElement
    {
        private IEnumerable<IWebElement> FilterByVisibility(IEnumerable<IWebElement> result)
        {
            return !_searchHidden ? result.Where(item => item.Displayed) : result;
        }

        private IEnumerable<IWebElement> FilterByTagNames(IEnumerable<IWebElement> elements)
        {
            return _searchTags.Aggregate(elements, (current, tag) => current.Where(item => item.TagName == tag.GetEnumDescription()));
        }

        private IEnumerable<IWebElement> FilterByText(IEnumerable<IWebElement> result)
        {
            if (_textSearchData != null)
            {
                result = _textSearchData.ExactMatch
                    ? result.Where(item => item.Text == _textSearchData.Text)
                    : result.Where(item => item.Text.Contains(_textSearchData.Text, StringComparison.InvariantCultureIgnoreCase));
            }

            return result;
        }

        private IEnumerable<IWebElement> FilterByTagAttributes(IEnumerable<IWebElement> elements)
        {
            return _searchProperties.Aggregate(elements, FilterByTagAttribute);
        }

        private static IEnumerable<IWebElement> FilterByTagAttribute(IEnumerable<IWebElement> elements, SearchProperty searchProperty)
        {
            return searchProperty.ExactMatch ?
                elements.Where(item => item.GetAttribute(searchProperty.AttributeName) != null && item.GetAttribute(searchProperty.AttributeName).Equals(searchProperty.AttributeValue)) :
                elements.Where(item => item.GetAttribute(searchProperty.AttributeName) != null && item.GetAttribute(searchProperty.AttributeName).Contains(searchProperty.AttributeValue));
        }
    }
}
