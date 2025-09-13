<img width="553" height="274" alt="Screenshot 2024-03-27 100345" src="https://github.com/user-attachments/assets/262eb52a-242d-4b80-8bea-b39238a9bdd5" />

<img width="361" height="270" alt="Screenshot 2024-03-22 083725" src="https://github.com/user-attachments/assets/9f41cd23-6b2b-467d-b8fb-3174c9d40d22" />



The first time you run it, enter your latitude and longitude coordinates... you can get these by right clicking on you location in google maps... after entering these, you should see correct sunrise/sunset times for the current date/location...

enter your camera's username and password... enter an IP address and port number for a camera you want to add... for cameras on the LAN, the port number will most likely be 80... for cameras connected to NVR PoE ports, use the NVR IP address and 65001, 65002, etc. as the port number... "virtual host" must be enabled on the NVR for this to work...

hit the add button... the utility will then send a http get "/ISAPI/Streaming/channels/101/capabilities" request to the camera to see that it exists and get the camera name... if it is found, it then sends a http get "/ISAPI/Image/Channels/1/displayParamSwitch" request to check which version of the image parameters switch the camera uses...

the camera is then added to the camera list... you can use the edit button to change the sunrise/sunset scenes or minute offsets from sunrise/sunset you would like to use... while in edit mode, you may also delete any cameras that have been added... add as many cameras as you like... then hit the "IPS On" button and http put requests will be sent to each camera to set the image parameter switch schedules.

The utility uses the sunrise/sunset times for 15th day of each month to set the schedule. Older cameras only have one setting (not 12 months) so the 15th of the current month is used to set those... I have two older cameras like this, so I intend to run the utility once a month to keep these updated.

On first use, the utility will create a configuration file (.ini) that saves the username, latitude, longitude, and camera information for subsequent runs. The configuration file is updated anytime changes are made... the camera password is not saved and will need to be entered each time the utility is run... one limitation is that all cameras must be using the same username and password.
