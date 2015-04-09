// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="TreeNode.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="TreeNode.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows.Media;
using EFC.Client.Common.Collection;

namespace EFC.Client.Common.Tree
{
    /// <summary>
    /// TreeNode.
    /// </summary>
    public class TreeNode : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public TreeNode Parent { get; set; }

        /// <summary>
        /// The name{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// The tool tip{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private string toolTip;

        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        /// <value>
        /// The tool tip.
        /// </value>
        public string ToolTip
        {
            get { return toolTip; }
            set
            {
                toolTip = value;
                OnPropertyChanged("ToolTip");
            }
        }

        /// <summary>
        /// The image name{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private string imageName;

        /// <summary>
        /// Gets or sets the name of the image.
        /// </summary>
        /// <value>
        /// The name of the image.
        /// </value>
        public string ImageSource
        {
            get { return imageName; }
            set
            {
                imageName = value;
                OnPropertyChanged("ImageSource");
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }


        public bool IsItemsLoaded { get; set; }

        private bool isExpanded;

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                if (isExpanded)
                    ExpandParents();
                OnPropertyChanged("IsExpanded");
            }
        }

        private SolidColorBrush background;

        public SolidColorBrush Background
        {
            get { return background; }
            set
            {
                background = value;
                OnPropertyChanged("Background");
            }
        }


        private NotifiableCollection<TreeNode> treeItems;

        public NotifiableCollection<TreeNode> TreeItems
        {
            get { return treeItems; }
            set
            {
                treeItems = value;
                OnPropertyChanged("TreeItems");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class.
        /// </summary>
        /// <param name="Name">The name.</param>
        public TreeNode(string Name)
        {
            if (Name == null) throw new ArgumentNullException("Name");
            // TODO: Complete member initialization
            this.Name = Name;
            this.IsExpanded = false;
            this.IsSelected = false;
            Background = new SolidColorBrush(Colors.White);
            TreeItems = new NotifiableCollection<TreeNode>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="node">Tree node. </param>
        public TreeNode(TreeNode node)
        {
            // TODO: Complete member initialization
            this.Name = node.Name;
            ToolTip = node.ToolTipText;
            this.IsExpanded = node.IsExpanded;
            this.IsSelected = node.IsSelected;
            this.Background = node.Background;
            this.Id = node.Id;
            this.Parent = node.Parent;
            Background = new SolidColorBrush(Colors.White);
            TreeItems = new NotifiableCollection<TreeNode>();
            foreach (var item in node.TreeItems)
                TreeItems.Add(new TreeNode(item));
        }

        private string toolTipText;

        public string ToolTipText
        {
            get { return toolTipText; }
            set
            {
                toolTipText = value;
                OnPropertyChanged("ToolTipText");
            }
        }

        public int Id { get; set; }

        /// <summary>
        /// Expands the parents.
        /// </summary>
        private void ExpandParents()
        {
            if (Parent != null)
                Parent.IsExpanded = true;
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            IsExpanded = false;
            Background = new SolidColorBrush(Colors.White);
            IsSelected = false;
            foreach (var item in TreeItems)
                item.Reset();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}