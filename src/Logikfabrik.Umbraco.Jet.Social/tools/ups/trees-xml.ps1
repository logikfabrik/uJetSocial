Function Get-Trees
{
	<#
	.SYNOPSIS
		Gets trees from a Umbraco trees config file.
	.DESCRIPTION
		Gets trees from a Umbraco trees config file.
	.PARAMETER xml
		The Umbraco trees config file to get trees from.
	#>

	Param($xml)
		
	$nodes = $xml.SelectNodes("//add")
		
	if ($nodes.Count -eq 0) { 
		return @{}
	}
		
	return $nodes
}

Function Add-Tree
{
	<#
	.SYNOPSIS
		Adds a tree to a Umbraco trees config file.
	.DESCRIPTION
		Adds a tree to a Umbraco trees config file.
	.PARAMETER xml
		The Umbraco trees config file to add a tree to.
	.PARAMETER tree
		The tree to add.
	#>

	Param($xml, $tree)

	if (Test-Tree $xml $tree) {
		return
	}

	$node = $xml.ImportNode($tree, $false)

	$xml.DocumentElement.AppendChild($node)
}

Function Remove-Tree
{
	<#
	.SYNOPSIS
		Removes a tree from a Umbraco trees config file.
	.DESCRIPTION
		Removes a tree from a Umbraco trees config file.
	.PARAMETER xml
		The Umbraco trees config file to remove a tree from.
	.PARAMETER tree
		The tree to remove.
	#>

	Param($xml, $tree)

	if (-Not (Test-Tree $xml $tree)) {
		return
	}

	$alias = $tree.Attributes["alias"].Value
	$nodes = $xml.SelectNodes("//add[@alias='$alias']")

	foreach ($node in $nodes) {
		$xml.DocumentElement.RemoveChild($node)
	}
}

Function Test-Tree
{
	Param($xml, $tree)

	$alias = $tree.Attributes["alias"].Value
	$nodes = $xml.SelectNodes("//add[@alias='$alias']")
		
	return -Not ($nodes.Count -eq 0)
}