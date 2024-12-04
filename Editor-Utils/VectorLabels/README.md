<h1>Vector Labels Attribute</h1>

<p>Vector Labels Attribute allows you to modify the name of the vector axes displayed in the Unity inspector.</p>

<h3>Importing</h3>
<p>To import Vector Lables to your Unity project follow the next steps: </p>
<ul>
  <li>Download all C# scripts from this folder</li>
  <li>Import them into your Unity project</li>
  <li><strong>IMPORTANT</strong>Add the VectorLabelsAttribute.cs script to your scripts folder</li>
  <li><strong>IMPORTANT</strong>Add the VectorLabelsAttributeDrawer.cs script to a folder called <strong>Editor</strong></li>
</ul>

<h3>Usage</h3>
<p>To change the name of the axes of a vector in the inspector, you must add above your variable of type Vector (2, 3 or 4) the following attribute:</p>

<p>[VectorLabels(XAxisName : string, YAxisName : string, ZAxisName : string, WAxisName : string)]</p>
