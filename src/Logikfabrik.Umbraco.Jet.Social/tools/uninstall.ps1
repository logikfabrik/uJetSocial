param($installPath, $toolsPath, $package, $project)

. "$PSScriptRoot\ups\lang-nuget.ps1"
. "$PSScriptRoot\ups\trees-nuget.ps1"

Function Uninstall-Langs() {
	Param($projectPath, $toolsPath)

	$umbLangPath = "$projectPath\Umbraco\Config\Lang"
	$nugLangPath = "$toolsPath\lang"

	if (-Not (Test-Path $umbLangPath)) {
		return
	}

	if (-Not (Test-Path $nugLangPath)) {
		return
	}

	Remove-Langs $umbLangPath $nugLangPath
}

Function Uninstall-Trees() {
	Param($projectPath, $toolsPath)

	$umbConfigPath = "$projectPath\config"
	$nugConfigPath = "$toolsPath\config"

	if (-Not (Test-Path $umbConfigPath)) {
		return
	}

	if (-Not (Test-Path $nugConfigPath)) {
		return
	}

	Remove-Trees $umbConfigPath $nugConfigPath
}

$projectPath = (Get-Item $project.FullName).Directory.FullName

Uninstall-Langs $projectPath $toolsPath
Uninstall-Trees $projectPath $toolsPath