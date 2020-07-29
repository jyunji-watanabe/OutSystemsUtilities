# OutSystemsUtilities
utility programs for OutSystems development or management

## OutDocExporter
Using Selenium ChromeDriver, save the OutDoc document of specified module as screenshots.
To be fixed: Combine screenshots to one file.

### Libraries
This programs uses ImageSharp which is licensed under the [Apache License, Version 2.0](https://opensource.org/licenses/Apache-2.0).

### Prerequisite
Place an appsettings.json file at the same place of your exe file.
Edit it to have your OutSystems environment information there.
The screen shots will be outputted in C:\\work\ss folder, so ensure that the folder exists or change the path.

### Command
Open up your console and type as follows:
OutSystemsUtilities.exe <your_module_name>