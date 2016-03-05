# uJetSocial [![Build status](https://ci.appveyor.com/api/projects/status/ ?svg=true)](https://ci.appveyor.com/project/logikfabrik/ujetsocial)

Umbraco Jet Social (uJetSocial) is a developer tool for building social applications in Umbraco 7, released as Open Source (MIT).

uJetSocial is built on top of the Umbraco API services layer and accessible through the Umbraco back office. Its roadmap includes social features such as users, groups, blogs, and comments.

## Getting Started
uJetSocial is in its early stages. To get started with uJetSocial, do the following:

1. Download the source code and open it up in VS.
2. Open `Web.config` in the `Logikfabrik.Umbraco.Jet.Social.Demo` project and clear the key values for `umbracoConfigurationStatus` and `umbracoDbDSN`.
3. Compile and fire up the `Logikfabrik.Umbraco.Jet.Social.Demo` project with IIS Express.
4. Go through the Umbraco installer, and then enable uJetSocial in Members > Users > YOU > Sections. Refresh (or restart the application) and the uJetSocial section should now be available in the main menu.

uJetSocial is made up of one DLL and a `App_Plugins` folder. The `App_Plugins` folder is copied from `Logikfabrik.Umbraco.Jet.Social` to `Logikfabrik.Umbraco.Jet.Social.Demo` on build, as well as the DLL (through a project reference). The `Logikfabrik.Umbraco.Jet.Social.Demo` project is nothing more than a development project; all uJetSocial code should be placed in the `Logikfabrik.Umbraco.Jet.Social` project.

## Contributions
uJetSocial is Open Source (MIT), and you’re welcome to contribute!

If you have a bug report, feature request, or suggestion, please open a new issue. To submit a patch, please send a pull request.