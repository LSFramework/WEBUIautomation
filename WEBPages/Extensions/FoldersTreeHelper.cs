using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;
using WEBUIautomation.WebElement;

namespace WEBPages.Extensions
{
    internal class FoldersTreeHelper
    {
        public static WebElement GetRootNode(IWebDriverExt driver)
        {
            return driver.GetElement()
                .ByTagName(WEBUIautomation.Tags.TagNames.Li)
                .ByClass(ContentLocators.Locators.TreeHelperLocators.rootFolderClassValue);
        }

        public static List<WebElement> GetSubNodes(IWebDriverExt driver)
        {
            List<WebElement> list = new List<WebElement>();
            ///

            ///
            return list;
        }

    }


    internal static class TreeLocators
    {
        public static readonly string xpExpander = @".//div/span[2]";
        public static readonly string xpImage = @".//div/img";
        public static readonly string xpTextContainer = @".//div/span[@class='rtIn']";
        public static readonly string xpDivState = @".//div";
        public static readonly string xpChildrenListContainer = @".//ul";
        public static readonly string xpChildrenListItem = @".//ul/li";
        public static readonly string xpEditField = @".//div/span[@class='rtIn']/input";

        public static readonly string valExpanded = "rtMinus";
        public static readonly string valSelected = "rtSelected";
        public static readonly string vaEditable = "rtEdit";
        public static readonly string vaInnerText = "rtIn";

    }


    internal class WebFolderNode
    {
        private WebElement liNodeElement;

        private WebElement expander
        { get { return this.liNodeElement.FindRelative().ByXPath(TreeLocators.xpExpander); } }

        private WebElement image
        { get { return this.liNodeElement.FindRelative().ByXPath(TreeLocators.xpImage); } }

        private WebElement txtContainer
        { get { return this.liNodeElement.FindRelative().ByXPath(TreeLocators.xpTextContainer); } }

        private WebElement divState
        { get { return this.liNodeElement.FindRelative().ByXPath(TreeLocators.xpDivState); } }

        private WebElement childrenListContainer
        { get { return this.liNodeElement.FindRelative().ByXPath(TreeLocators.xpChildrenListContainer); } }

        private WebElement editField
        { get { return this.txtContainer.FindRelative().ByTagName(WEBUIautomation.Tags.TagNames.Input); } }

        public WebFolderNode(WebElement nodeElement)
        {
            this.liNodeElement = nodeElement;
        }

        public string NodeName  
        { get { return txtContainer.Text; 
        } }
        
        public bool Expanded
        {
            get 
            {
                string classValue = this.expander.GetAttribute(WEBUIautomation.Tags.TagAttributes.Class);
                
                return classValue.Contains(TreeLocators.valExpanded);
            }
        }

        private bool hasChildren
        {
            get
            {
                return this.childrenListContainer.Exists();
            }
        }

        public bool Selected
        {
            get
            {
                return this.divState
                .GetAttribute(WEBUIautomation.Tags.TagAttributes.Class)
                .Contains(TreeLocators.valSelected);
            }
        }

        private bool Editable
        { 
            get 
            {
                return this.divState
                   .GetAttribute(WEBUIautomation.Tags.TagAttributes.Class)
                   .Contains(TreeLocators.vaEditable);
            } 
        }

        private List<WebFolderNode> children
        {
            get
            {
                if (this.hasChildren)
                {
                    List<WebFolderNode> list = new List<WebFolderNode>();
                    list =this.liNodeElement
                        .FindRelative()
                        .ByXPath(TreeLocators.xpChildrenListItem)
                        .Select(((e) => new WebFolderNode(e))  );     
             

                        List<string> strList = new List<string>();
                    strList = list.Select((n)=>n.NodeName).ToList(); 

                
                    return list;
                }

                return new List<WebFolderNode>();
            }
        }

        public WebFolderNode Expand()
        {
            if (!this.Expanded)
                this.expander.Click();

            return this;
        }

        public WebFolderNode SelectFolder()
        {
            if (!this.Selected)
                this.txtContainer.Click();
            return this;
        }

        public WebFolderNode Collapse()
        {
            if (this.Expanded)
                this.expander.Click();
            return this;
        }

        public WebElement FindFolder(string folderName)
        {
            return FindWebFolderNode(folderName).divState;            
        }

        public WebFolderNode FindWebFolderNode (string folderName)
        {
            this.Expand();

            List<WebFolderNode> found = new List<WebFolderNode>();

            foreach (WebFolderNode n in children)
            {
                if (n.NodeName == folderName)
                    found.Add(n);
            }


            if (found.Any())
                return found.First();

            throw new WebElementNotFoundException(string.Format("Couldn't find any folder with name {0}", folderName));
        }

        public WebFolderNode Rename(string newName)
        {
            if (!this.Selected)
                this.txtContainer.Click();

            if (!this.Editable)
                this.txtContainer.Click();

            this.editField.Text = newName;
           
            return this;
        }
        
    }

    internal class WebTree
    {
        public WebTree(WebElement treeContainer)
        { 
            WebElement rootNode = treeContainer.FindRelative()
                .ByTagName(WEBUIautomation.Tags.TagNames.Li)
                .ByClass(ContentLocators.Locators.TreeHelperLocators.rootFolderClassValue);

            this.Root = new WebFolderNode(rootNode);
        }

        public WebFolderNode Root;
    }

}
