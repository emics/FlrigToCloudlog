# FlrigToCloudlog

[![GitHub Release][releases-shield]][releases]
[![License][license-shield]](LICENSE)
[![GitHub Activity][commits-shield]][commits]
[![Project Maintenance][maintenance-shield]][user_profile]

[![BuyMeCoffee][buymecoffeebadge]][buymecoffee]


## Introduction
This software for Windows require .NET Framework to run, allows you to read information from the **flrig** application connected to your ham radio and send the data to the **CloudLog** platform.

You can find all info about this fantastic project here (https://github.com/magicbug/Cloudlog/wiki).

This software also allows you to receive ADIF messages via UDP and automatically update your logbook on the **CloudLog** platform.

Simply configure the apikey and address of your **CloudLog** installation.

---
## Installation
### Manual installation

* Create a new direcory (folder) in your computer.
* Download file `FlrigToCloudlog.zip` from the [latest release section][releases-latest] in this repository.
* Extract _all_ files from this archive you downloaded in the directory (folder) you created.
* Run `FlrigToCloudlog.exe` and configure it.

![Folder](https://raw.githubusercontent.com/emics/FlrigToCloudlog/main/assets/folder.png)

## Configuration

Once run the application go to the Config Tab

![Config Tab](https://raw.githubusercontent.com/emics/FlrigToCloudlog/main/assets/config_tab.png)

In the configuration tab it is possible to enter the following values:

To enable transmission feature you must check **Enable Rig Data to CloudLog task**
**1. CloudLog Api Key** -  you can retrieve this key in the Menu -> API Keys in your CloudLog platform. 
   You can visit the official Wiki to generate new one (https://github.com/magicbug/Cloudlog/wiki/API).
**2. CloudLog Url** - is the address of your CloudLog installation.
**3. flrig Server Url** - is the address and port configured in the flrig, if flrig run on the same computer address is `127.0.0.1`.
**4. Update Delay (sec.)** - is the interval in seconds for reading data from flrig and sending it to CloudLog
   
This software can also send to CloudLog every QSO you register on your local Logbook. 

You can enable this feature checking **Enable ADIF Log to CloudLog task** and configuring these values:
**5. Listen UDP Port** - select the listening port
**6. ID Station Location** - you can retrieve this value in your CloudLog platform in Menu -> Station Location find the line of your QTH and read the blue ID number.

![Station Location](https://raw.githubusercontent.com/emics/FlrigToCloudlog/main/assets/station_location.png)

**7. Auto Start Minimized** - this feature reduce automaticaly the application to the tray bar at startup. 

## Run
Once the configuration has been completed, it is possible to start the program using the Start button and check the operation using the two traffic lights that indicate the status of the two different tasks (flrig and ADIF Log).
Similarly, to stop the service, simply press the Stop button

![Server Tab](https://raw.githubusercontent.com/emics/FlrigToCloudlog/main/assets/server_tab.png)


<p align="center">* * *</p>

## Contributions are welcome!

This is an active open-source project. We are always open to people who want to use the code or contribute to it.

We have set up a separate document containing our [contribution guidelines][contribution].

Thank you for being involved! :heart_eyes:

---

## Trademark Legal Notices

All product names, trademarks and registered trademarks in the images in this repository, are property of their respective owners.
All images in this repository are used by the author for identification purposes only.
The use of these names, trademarks and brands appearing in these image files, do not imply endorsement.

[commits-shield]: https://img.shields.io/github/last-commit/emics/FlrigToCloudlog?color=pink&style=for-the-badge
[commits]: https://github.com/emics/FlrigToCloudlog/commits/dev
[releases-shield]: https://img.shields.io/github/release/emics/FlrigToCloudlog.svg?style=for-the-badge
[releases]: https://github.com/emics/FlrigToCloudlog/releases
[releases-latest]: https://github.com/emics/FlrigToCloudlog/releases/latest
[user_profile]: https://github.com/emics
[license-shield]: https://img.shields.io/github/license/emics/FlrigToCloudlog.svg?color=yellow&style=for-the-badge
[maintenance-shield]: https://img.shields.io/badge/maintainer-%40emics-orange.svg?style=for-the-badge
[contribution]: https://github.com/emics/FlrigToCloudlog/blob/main/CONTRIBUTING.md


<!--- External Link -->
[hamqsl]: http://www.hamqsl.com/
[kc2g]: https://prop.kc2g.com/

[buymecoffee]: https://www.buymeacoffee.com/emics
[buymecoffeebadge]: https://img.buymeacoffee.com/button-api/?text=Buy%20me%20a%20coffee&emoji=&slug=emics&button_colour=FFDD00&font_colour=000000&font_family=Cookie&outline_colour=000000&coffee_colour=ffffff