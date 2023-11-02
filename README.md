# RDK2_UM980_NTRIP_Client

This example demonstrates how to use the correction data sent by a NTRIP caster to enhance the accuracy of the position delivered by the UM980.

The raw correction data are directly sent to the UM980. The correction is performed directly inside the UM980.

<figure>
    <img src="pictures/overview.png"  style="zoom:100%;" alt="RDK2 + AMS OSRAM board">
</figure>

<figure>
    <img src="pictures/gui_screenshot.PNG"  style="zoom:50%;" alt="Screenshot GUI">
    <figcaption>Screenshot of the GUI. Sensor on a desk with ceiling at arround 2meters.</figcaption>
</figure>

## Requirements

- [ModusToolbox™ software](https://www.infineon.com/cms/en/design-support/tools/sdk/modustoolbox-software/) v3.x
- [RDK2](https://www.rutronik24.com/product/rutronik/rutdevkit-psoc62/16440182.html)
- [AMS OSRAM TMF8828 Arduino Shield](https://ams.com/tmf882x-mcu-shield-evm)


## Using the code example

This repository stores 2 directories:
- BSP: Contains a project that can be imported into Modus Toolbox. Follow the user manual to see how.
- GUI: Contains a Visual Studio project (C#). It also contains a binary data that can be executed if you do not want to compile the project yourself.

Once the BSP has been uploaded on the RDK2, start the GUI and choose the correct COM port. Then press the button USR_BTN1 to start generating data.

## Legal Disclaimer

The evaluation board including the software is for testing purposes only and, because it has limited functions and limited resilience, is not suitable for permanent use under real conditions. If the evaluation board is nevertheless used under real conditions, this is done at one’s responsibility; any liability of Rutronik is insofar excluded. 

<img src="pictures/rutronik.png" style="zoom:50%;" />



