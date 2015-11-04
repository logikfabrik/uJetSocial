. "$PSScriptRoot\trees-xml.ps1"

Function Add-Trees
{
	<#
	.SYNOPSIS
		Adds Umbraco back office trees.
	.DESCRIPTION
		Adds Umbraco back office trees.
	.PARAMETER umbConfigPath
		The Umbraco config directory path.
	.PARAMETER nugConfigPath
		The NuGet config directory path.
	#>

	Param($umbConfigPath, $nugConfigPath)

	$umbConfigFile = "$umbConfigPath\trees.config"
	$nugConfigFile = "$nugConfigPath\trees.config"

	if (-Not (Test-Path $umbConfigFile)) {
		return
	}

	if (-Not (Test-Path $nugConfigFile)) {
		return
	}
		
	$umbTreesXml = New-Object XML
	$umbTreesXml.Load("$umbConfigFile")
		
	$nugTreesXml = New-Object XML
	$nugTreesXml.Load("$nugConfigFile")
		
	foreach ($tree in Get-Trees $nugTreesXml) {
		Add-Tree $umbTreesXml $tree
	}
		
	$umbTreesXml.Save("$umbConfigFile")
}

Function Remove-Trees
{
	<#
	.SYNOPSIS
		Removes Umbraco back office trees.
	.DESCRIPTION
		Removes Umbraco back office trees.
	.PARAMETER umbConfigPath
		The Umbraco config directory path.
	.PARAMETER nugConfigPath
		The NuGet config directory path.
	#>

	Param($umbConfigPath, $nugConfigPath)

	$umbConfigFile = "$umbConfigPath\trees.config"
	$nugConfigFile = "$nugConfigPath\trees.config"

	if (-Not (Test-Path $umbConfigFile)) {
		return
	}

	if (-Not (Test-Path $nugConfigFile)) {
		return
	}
		
	$umbTreesXml = New-Object XML
	$umbTreesXml.Load("$umbConfigFile")
		
	$nugTreesXml = New-Object XML
	$nugTreesXml.Load("$nugConfigFile")
		
	foreach ($tree in Get-Trees $nugTreesXml) {
		Remove-Tree $umbTreesXml $tree
	}
		
	$umbTreesXml.Save("$umbConfigFile")
}