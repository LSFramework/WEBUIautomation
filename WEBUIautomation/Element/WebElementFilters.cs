using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Tags;
using WEBUIautomation.Extensions;
using OpenQA.Selenium;

namespace WEBUIautomation.WebElement
{
    internal class SearchProperty
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public bool ExactMatch { get; set; }
    }

    internal class TextSearchData
    {
        public string Text { get; set; }
        public bool ExactMatch { get; set; }
    }

    public partial class WebElement
    {
        private readonly IList<SearchProperty> _searchProperties = new List<SearchProperty>();
        private readonly IList<TagNames> _searchTags = new List<TagNames>();
        private bool _searchHidden;
        private int _index;
        private string _xPath;
        private TextSearchData _textSearchData;

        public WebElement ByAttribute(TagAttributes tagAttribute, string attributeValue, bool exactMatch = true)
        {
            return ByAttribute(tagAttribute.GetEnumDescription(), attributeValue, exactMatch);
        }

        public WebElement ByAttribute(TagAttributes tagAttribute, int attributeValue, bool exactMatch = true)
        {
            return ByAttribute(tagAttribute.GetEnumDescription(), attributeValue.ToString(), exactMatch);
        }

        public WebElement ById(string id, bool exactMatch = true)
        {
            return ByAttribute(TagAttributes.Id, id, exactMatch);
        }

        public WebElement ById(int id, bool exactMatch = true)
        {
            return ByAttribute(TagAttributes.Id, id.ToString(), exactMatch);
        }

        public WebElement ByName(string name, bool exactMatch = true)
        {
            return ByAttribute(TagAttributes.Name, name, exactMatch);
        }

        public WebElement ByClass(string className, bool exactMatch = true)
        {
            return ByAttribute(TagAttributes.Class, className, exactMatch);
        }

        public WebElement ByTagName(TagNames tagName)
        {
            var selector = By.TagName(tagName.GetEnumDescription());

            _firstSelector = _firstSelector ?? selector;
            _searchTags.Add(tagName);

            return this;
        }

        public WebElement ByXPath(string xPath)
        {
            Contract.Assume(_firstSelector == null,
                "XPath can be only the first search criteria.");

            _firstSelector = By.XPath(xPath);
            _xPath = xPath;

            return this;
        }

        public WebElement ByIndex(int index)
        {
            _index = index;

            return this;
        }

        public WebElement First()
        {
            _index = 0;

            return this;
        }

        public WebElement Last()
        {
            _index = -1;

            return this;
        }

        public WebElement IncludeHidden()
        {
            _searchHidden = true;

            return this;
        }

        public WebElement ByText(string text, bool exactMatch = true)
        {
            var selector = exactMatch ?
                By.XPath(string.Format("//*[text()=\"{0}\"]", text)) :
                By.XPath(string.Format("//*[contains(text(), \"{0}\")]", text));

            _firstSelector = _firstSelector ?? selector;
            _textSearchData = new TextSearchData { Text = text, ExactMatch = exactMatch };

            return this;
        }

        private WebElement ByAttribute(string tagAttribute, string attributeValue, bool exactMatch = true)
        {
            var xPath = exactMatch ?
                        string.Format("//*[@{0}=\"{1}\"]", tagAttribute, attributeValue) :
                        string.Format("//*[contains(@{0}, \"{1}\")]", tagAttribute, attributeValue);
            var selector = By.XPath(xPath);

            _firstSelector = _firstSelector ?? selector;

            _searchProperties.Add(new SearchProperty
            {
                AttributeName = tagAttribute,
                AttributeValue = attributeValue,
                ExactMatch = exactMatch
            });

            return this;
        }

        private string SearchCriteriaToString()
        {
            var result = _searchProperties.Select(searchProperty =>
                string.Format("{0}: {1} ({2})",
                    searchProperty.AttributeName,
                    searchProperty.AttributeValue,
                    searchProperty.ExactMatch ? "exact" : "contains")).ToList();

            result.AddRange(_searchTags.Select(searchTag =>
                string.Format("tag: {0}", searchTag)));

            if (_xPath != null)
            {
                result.Add(string.Format("XPath: {0}", _xPath));
            }

            if (_textSearchData != null)
            {
                result.Add(string.Format("text: {0} ({1})",
                    _textSearchData.Text,
                    _textSearchData.ExactMatch ? "exact" : "contains"));
            }

            return string.Join(", ", result);
        }

        public WebElement ByCriteria(By by)
        {
            _firstSelector = by;
            return this;

        }
    }
}
