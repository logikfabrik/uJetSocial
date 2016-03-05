# uJetSocial [![Build status](https://ci.appveyor.com/api/projects/status/ ?svg=true)](https://ci.appveyor.com/project/logikfabrik/ujetsocial)

Umbraco Jet Social (uJetSocial) is a developer tool for building social applications in Umbraco 7, released as Open Source (MIT).

uJetSocial is built on top of the Umbraco API services layer and accessible through the Umbraco back office. Its roadmap includes social features such as users, groups, blogs, and comments.

## Getting Started
uJetSocial is in its early stages. To get started with uJetSocial, do the following:

1. Download the source code and open it up in VS.
2. Compile and fire up the `Logikfabrik.Umbraco.Jet.Social.Demo` project with IIS Express.
3. Go through the Umbraco installer, and then enable uJetSocial under Users > Users > *your user* > Sections.
4. Refresh (or restart IIS Express) and the uJetSocial section should now be available.

uJetSocial is made up of one DLL and a `App_Plugins` folder. The `App_Plugins` folder is copied from `Logikfabrik.Umbraco.Jet.Social` to `Logikfabrik.Umbraco.Jet.Social.Demo` on build, as well as the DLL (through a project reference). The `Logikfabrik.Umbraco.Jet.Social.Demo` project is nothing more than a development project; all uJetSocial code should be placed in the `Logikfabrik.Umbraco.Jet.Social` project.

If you don't want the Umbraco installation to clutter up your environment with irrelevant changes, run the following for your local repo using Git Bash:

```bash
cd src/Logikfabrik.Umbraco.Jet.Social.Demo/
git update-index --assume-unchanged $(git ls-files | tr '\n' ' ')
```

## Contributions
uJetSocial is Open Source (MIT), and you’re welcome to contribute!

If you have a bug report, feature request, or suggestion, please open a new issue. To submit a patch, please send a pull request.