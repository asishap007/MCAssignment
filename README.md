# MCAssignment
This tool is used to track the animals over the period of time. It is used to keep an accurate account of their wildlife, and their movements. This tool is used to store the GPS coordinates for various wildlife to locate the animals over the period of time.

Detailed API information can be found in the following link
https://github.com/asishap007/MCAssignment/blob/master/WILDLIFE%20RESERVE%20TOOL_v1.docx

Also you can find the html generated Documentation in this repo.
https://github.com/asishap007/MCAssignment/tree/master/html_doc/html

Apart from that, there is two folders 
1. GameReserveApp : Client Desktop application
2. GameReserveService: Backed-Api written in C# WCF.

#Deployment Process

#Installation Process
1.	DB Setup
•	Mysql databse is used in this project.
•	The dump file would be provided named "game_reserve.sql"
•	Open MySQL Workbench, Select the local instance, and enter the root password if prompted.
•	Select Data Import option from Server>DataImport.
•	Select the "Import from Self-Contained file" option and browse to select the DB backup dump provided.
•	In the default Target Schema, select New and give the name of Schema that is to be created.
•	Click Start Import button.
•	Refresh the schemas at left hand side and the newly imported schema will be listed with all the tables and stored procedures.
•	Update the "connection string" setting in \Bin\WebServices\DBService\DBService\bin\web.config file. 
Change username, password and Database.
2.	Deployment Setup
	2.1 Backend:
	Installing IIS
•	In Windows, access the Control Panel and click Programs.
•	 In the Programs and Features window, click Turn Windows features on or off.
•	Select the Internet Information Services (IIS) check box, expand the node and ensure that the following items are selected.
•	Then click OK.
•	For the changes to take effect Restart PC.
		Deploying services in IIS
•	 Open IIS by giving “inetmgr” in Run Window.
•	Once IIS is opened, Expand the nodes in Connections panel (in left hand side of the window), to reach Default Web Site.
•	Right Click Default Web Site and select Add Application.
•	In Add Application pop-up window, give the folder name as alias name. For example, while hosting SomeService web service, give the alias name as SomeService.
•	Browse the physical path to point to \Bin\WebServices\SomeService
•	Click OK to complete adding the application to IIS.
		2.2 Client Application:
•	Go to visual studio and select the Release option from the drop down in the main menu.
•	After building .exe file will generate inside the project folder under the bin/Release directory



