﻿#region Copyright (c) 2000-2012 Developer Express Inc.
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

using System.Windows;
using DevExpress.Xpf.Grid.TreeList;
namespace DevExpress.Xpf.Grid {
	abstract class FindTableElementHitTestVisitorBase : TableViewHitTestVisitorBase {
		protected readonly DataViewDragDropManager dragDropManager;
		public FrameworkElement StoredHitElement { get; protected set; }
		protected FindTableElementHitTestVisitorBase(DataViewDragDropManager dragDropManager) {
			this.dragDropManager = dragDropManager;
		}
		protected void StoreHitElement() {
			StoredHitElement = HitElement as FrameworkElement;
		}
	}
	internal class FindTableViewRowElementHitTestVisitor : FindTableElementHitTestVisitorBase {
		public FindTableViewRowElementHitTestVisitor(DataViewDragDropManager dragDropManager)
			: base(dragDropManager) {
		}
		public override void VisitRow(int rowHandle) {
			StoreHitElement();
		}
		public override void VisitGroupRow(int rowHandle) {
			StoreHitElement();
			StopHitTesting();
		}
	}
	internal class FindTableViewDataAreaElementHitTestVisitor : FindTableElementHitTestVisitorBase {
		public FindTableViewDataAreaElementHitTestVisitor(DataViewDragDropManager dragDropManager)
			: base(dragDropManager) {
		}
		public override void VisitDataArea() {
			StoreHitElement();
		}
	}
	abstract class FindTreeListViewElementHitTestVisitorBase : TreeListViewHitTestVisitorBase {
		protected readonly DataViewDragDropManager dragDropManager;
		public FrameworkElement Row { get; protected set; }
		public FrameworkElement DataArea { get; set; }
		protected FindTreeListViewElementHitTestVisitorBase(DataViewDragDropManager dragDropManager) {
			this.dragDropManager = dragDropManager;
		}
	}
	internal class FindTreeListViewRowElementHitTestVisitor : FindTreeListViewElementHitTestVisitorBase {
		public FindTreeListViewRowElementHitTestVisitor(DataViewDragDropManager dragDropManager)
			: base(dragDropManager) {
		}
		public override void VisitRow(int rowHandle) {
			Row = HitElement as FrameworkElement;
			StopHitTesting();
		}
	}
	internal class FindTreeListViewDataAreaElementHitTestVisitor : FindTreeListViewElementHitTestVisitorBase {
		public FindTreeListViewDataAreaElementHitTestVisitor(DataViewDragDropManager dragDropManager)
			: base(dragDropManager) {
		}
		public override void VisitDataArea() {
			DataArea = HitElement as FrameworkElement;
			StopHitTesting();
		}
	}
}
