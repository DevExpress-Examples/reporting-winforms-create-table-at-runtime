<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1356)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [XtraReport1.cs](./CS/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/XtraReport1.vb))
<!-- default file list end -->
# Runtime table creation best practices (iterative approach)


<p>This example demonstrates the differences in runtime table creation between the newest XtraReports version and its prior versions.</p>
<p>Please note that it is always required to call the <strong>XRTable.BeginInit</strong> and <strong>XRTable.EndInit</strong> methods if you modify <strong>XRTable.Rows</strong> and <strong>XRTableRow.Cells</strong> collections at runtime.</p>
<p>As for the height of a table, explicitly specify it only if cells' content is not expected to stretch the cells (e.g. this may happen when their <strong>CanGrow</strong> property is enabled).<br><br><strong>See also</strong>:<br><a href="https://www.devexpress.com/Support/Center/p/E108">How to convert an XtraGrid to an XtraReport at runtime</a></p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-winforms-create-table-at-runtime&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-winforms-create-table-at-runtime&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
