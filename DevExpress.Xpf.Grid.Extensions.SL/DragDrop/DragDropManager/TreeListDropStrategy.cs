#region Copyright (c) 2000-2012 Developer Express Inc.
/*
{*******************************************************************}
{                                                                   }
{       Developer Express .NET Component Library                    }
{                                                                   }
{                                                                   }
{       Copyright (c) 2000-2012 Developer Express Inc.              }
{       ALL RIGHTS RESERVED                                         }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }
{   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   }
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING .NET    }
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }
{                                                                   }
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }
{   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      }
{                                                                   }
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }
{   ADDITIONAL RESTRICTIONS.                                        }
{                                                                   }
{*******************************************************************}
*/
#endregion Copyright (c) 2000-2012 Developer Express Inc.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
#if SL
using DevExpress.Data.Browsing;
#endif
namespace DevExpress.Xpf.Grid.DragDrop {
	public class TreeListDropStrategy {
		public TreeListDropStrategy(TreeListView view) {
			this.TreeListView = view;
		}
		protected TreeListView TreeListView { get; set; }
		public virtual void DropObject(IList source, TreeListNode insertNode, DropTargetType dropTargetType, object obj) {
		}
		protected void SetPropertyValue(object obj, string propertyName, object value) {
			TypeDescriptor.GetProperties(obj)[propertyName].SetValue(obj, value);
		}
		protected object GetPropertyValue(object obj, string propertyName) {
			return TypeDescriptor.GetProperties(obj)[propertyName].GetValue(obj);
		}
	}
	public class SelfReferenceDropStrategy : TreeListDropStrategy {
		public SelfReferenceDropStrategy(TreeListView view)
			: base(view) {
		}
		public override void DropObject(IList source, TreeListNode insertNode, DropTargetType dropTargetType, object obj) {
			switch(dropTargetType) {
				case DropTargetType.InsertRowsAfter:
				case DropTargetType.InsertRowsBefore:
					SetPropertyValue(obj, TreeListView.ParentFieldName,
						GetPropertyValue(insertNode.Content, TreeListView.ParentFieldName));
					break;
				case DropTargetType.InsertRowsIntoNode:
					SetPropertyValue(obj, TreeListView.ParentFieldName,
						GetPropertyValue(insertNode.Content, TreeListView.KeyFieldName));
					break;
				case DropTargetType.DataArea:
					if(TreeListView.RootValue != null)
						SetPropertyValue(obj, TreeListView.ParentFieldName, TreeListView.RootValue);
					break;
				default:
					break;
			}
		}
	}
	public class EmptyDropStrategy : TreeListDropStrategy {
		public EmptyDropStrategy(TreeListView view) : base(view) { }
	}
}
